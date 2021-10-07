using Ponyliga.Services;
using Ponyliga.Models;
using Xunit.Priority;
using Xunit;

namespace Ponyliga.Test
{
    public class URLTest
    {
        [Fact]
        public void GetUrlTest()
        {
            ApiService apiService = new ApiService();
            string url = apiService.GetUrl("user");
            Assert.Equal("https://ponyliga.azurewebsites.net/api/user", url);
        }
        [Fact]
        public void GetUrlID()
        {
            ApiService apiService = new ApiService();
            string url = apiService.GetUrlID("user","1");
            Assert.Equal("https://ponyliga.azurewebsites.net/api/user/1", url);
        }
        [Fact]
        public void GetUrlByOtherID()
        {
            ApiService apiService = new ApiService();
            string url = apiService.GetUrlByOtherID("user","1","data");
            Assert.Equal("https://ponyliga.azurewebsites.net/api/user/1/data", url);
        }
    }
}
