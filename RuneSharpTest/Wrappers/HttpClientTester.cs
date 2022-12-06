using RuneSharp.Utils;

namespace RuneSharpTest.Wrappers
{
    /// <summary>
    /// Test class. Wraps HttpClientWrapper to expose HttpMessageHandler for mocking.
    /// </summary>
    internal class HttpClientTester : HttpClientWrapper
    {
        public HttpClientTester(HttpMessageHandler handler) : base(handler)
        {
        }
    }
}
