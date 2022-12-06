using RuneSharp.Utils;

namespace RuneSharpTest.Tests.Utils
{
    public class QueryStringBuilderTests
    {
        [Fact]
        void Add()
        {
            QueryStringBuilder sb = new QueryStringBuilder();

            sb.Add("key", "value");
            sb.Add("int", 10);

            Assert.Equal("?key=value&int=10", sb.ToString());
        }

        [Fact]
        void Add_ExistingKey()
        {
            QueryStringBuilder sb = new QueryStringBuilder();

            sb.Add("key", "value");
            sb.Add("key", "updated value");

            Assert.Equal("?key=value", sb.ToString());
        }

        [Fact]
        void Remove()
        {
            QueryStringBuilder sb = new QueryStringBuilder();

            sb.Add("key", "value");
            sb.Add("int", 10);
            sb.Remove("int");

            Assert.Equal("?key=value", sb.ToString());
        }

        [Fact]
        void Remove_MissingKey()
        {
            QueryStringBuilder sb = new QueryStringBuilder();

            sb.Add("key", "value");
            sb.Remove("int");

            Assert.Equal("?key=value", sb.ToString());
        }

        [Fact]
        void ToString_Empty()
        {
            QueryStringBuilder sb = new QueryStringBuilder();

            Assert.Equal(string.Empty, sb.ToString());
        }
    }
}
