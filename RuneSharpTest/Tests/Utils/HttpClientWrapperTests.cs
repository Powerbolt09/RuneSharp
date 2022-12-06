using Moq;
using Moq.Protected;
using Newtonsoft.Json;
using RuneSharpTest.Wrappers;
using System.Net;

namespace RuneSharpTest.Tests.Utils
{
    public class HttpClientWrapperTests
    {
        private static readonly Uri REQUEST_URI = new UriBuilder("http://127.0.0.1/").Uri;

        private HttpClientTester _httpClientTester;

        private Mock<HttpMessageHandler> _mockHandler;

        public HttpClientWrapperTests()
        {
            _mockHandler = new Mock<HttpMessageHandler>();
            _httpClientTester = new HttpClientTester(_mockHandler.Object);
        }

        [Fact]
        void Send_Success()
        {
            _mockHandler.Protected()
                .Setup<HttpResponseMessage>("Send", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
                .Returns(
                    new HttpResponseMessage()
                    {
                        StatusCode = HttpStatusCode.OK,
                        Content = new StringContent("[\"first\", \"second\", \"third\", \"fourth\", \"fifth\"]")
                    }
                );

            List<string> result = _httpClientTester.Send<List<string>>(
                new HttpRequestMessage()
                {
                    Method = HttpMethod.Get,
                    RequestUri = REQUEST_URI
                }
            );

            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Equal(5, result.Count);
        }

        [Fact]
        void Send_Failure_UnmarshallException()
        {
            _mockHandler.Protected()
                .Setup<HttpResponseMessage>("Send", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
                .Returns(
                    new HttpResponseMessage()
                    {
                        StatusCode = HttpStatusCode.OK,
                        Content = new StringContent(string.Empty)
                    }
                );

            HttpRequestException ex = Assert.Throws<HttpRequestException>(() =>
                _httpClientTester.Send<object>(
                    new HttpRequestMessage()
                    {
                        Method = HttpMethod.Get,
                        RequestUri = REQUEST_URI
                    }
                )
            );

            Assert.True(ex.InnerException is JsonSerializationException);
            Assert.True(ex.StatusCode == HttpStatusCode.OK);
        }

        [Theory]
        [InlineData(HttpStatusCode.NotFound)]
        [InlineData(HttpStatusCode.Unauthorized)]
        [InlineData(HttpStatusCode.InternalServerError)]
        void Send_Failure_NonSuccessStatusCodes(HttpStatusCode statusCode)
        {
            _mockHandler.Protected()
                .Setup<HttpResponseMessage>("Send", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
                .Returns(
                    new HttpResponseMessage()
                    {
                        StatusCode = statusCode
                    }
                );

            HttpRequestException ex = Assert.Throws<HttpRequestException>(() =>
                _httpClientTester.Send<object>(
                    new HttpRequestMessage()
                    {
                        Method = HttpMethod.Get,
                        RequestUri = REQUEST_URI
                    }
                )
            );

            Assert.Equal(ex.Message, $"Call \"{HttpMethod.Get} {REQUEST_URI}\" failed.");
            Assert.True(ex.InnerException == null);
            Assert.True(ex.StatusCode == statusCode);
        }

        [Fact]
        async void SendAsync_Success()
        {
            _mockHandler.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(
                    new HttpResponseMessage()
                    {
                        StatusCode = HttpStatusCode.OK,
                        Content = new StringContent("[\"first\", \"second\", \"third\", \"fourth\", \"fifth\"]")
                    }
                );

            List<string> result = await _httpClientTester.SendAsync<List<string>>(
                new HttpRequestMessage()
                {
                    Method = HttpMethod.Get,
                    RequestUri = REQUEST_URI
                }
            );

            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Equal(5, result.Count);
        }

        [Fact]
        void SendAsync_Failure_UnmarshallException()
        {
            _mockHandler.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(
                    new HttpResponseMessage()
                    {
                        StatusCode = HttpStatusCode.OK,
                        Content = new StringContent(string.Empty)
                    }
                );

            HttpRequestException ex = Assert.ThrowsAsync<HttpRequestException>(() =>
                _httpClientTester.SendAsync<object>(
                    new HttpRequestMessage()
                    {
                        Method = HttpMethod.Get,
                        RequestUri = REQUEST_URI
                    }
                )
            ).Result;

            Assert.True(ex.InnerException is JsonSerializationException);
            Assert.True(ex.StatusCode == HttpStatusCode.OK);
        }

        [Theory]
        [InlineData(HttpStatusCode.NotFound)]
        [InlineData(HttpStatusCode.Unauthorized)]
        [InlineData(HttpStatusCode.InternalServerError)]
        void SendAsync_Failure_NonSuccessStatusCodes(HttpStatusCode statusCode)
        {
            _mockHandler.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(
                    new HttpResponseMessage()
                    {
                        StatusCode = statusCode
                    }
                );

            HttpRequestException ex = Assert.ThrowsAsync<HttpRequestException>(() =>
                _httpClientTester.SendAsync<object>(
                    new HttpRequestMessage()
                    {
                        Method = HttpMethod.Get,
                        RequestUri = REQUEST_URI
                    }
                )
            ).Result;

            Assert.Equal(ex.Message, $"Call \"{HttpMethod.Get} {REQUEST_URI}\" failed.");
            Assert.True(ex.InnerException == null);
            Assert.True(ex.StatusCode == statusCode);
        }

        [Fact]
        void Unmarshall_Success()
        {
            List<string> result = _httpClientTester.Unmarshall<List<string>>(
                new StringContent("[\"first\", \"second\", \"third\", \"fourth\", \"fifth\"]"));

            Assert.NotNull(result);
            Assert.True(result.Any());
            Assert.Equal(5, result.Count());
        }

        [Theory]
        [InlineData(null)]
        [MemberData(nameof(UnmarshallFailArgs))]
        void Unmarshall_Fail_InvalidStreamContent(StringContent content)
        {
            JsonSerializationException ex = Assert.Throws<JsonSerializationException>(() => _httpClientTester.Unmarshall<List<string>>(content));

            Assert.Equal("Error unmarshalling content from stream.", ex.Message);
        }

        public static IEnumerable<object[]> UnmarshallFailArgs()
        {
            return new List<object[]>()
            {
                new object[] { new StringContent(string.Empty) },
                new object[] { new StringContent("      ") }
            };
        }

        [Fact]
        void Unmarshall_Fail_MalformattedJson()
        {
            JsonSerializationException ex = Assert.Throws<JsonSerializationException>(() => _httpClientTester.Unmarshall<List<string>>(
                new StringContent("\"first\", \"second\", \"third\", \"fourth\", \"fifth\"")));
        }
    }
}
