using Ponyliga.Models;
using Ponyliga.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Ponyliga.Test
{
    public class PonyTest
    {

        [Fact]
        public async void GetAllPonies()
        {
            ApiService apiService = new ApiService();
            //var = System.Threading.Tasks.Task<System.Collections.Generic.List<Models.User>>
            var result = await apiService.GetAllPonies();

            Assert.NotEmpty(result);

        }
        [Fact]
        public string AddPony()
        {
            Random rnd = new Random();
            int month = rnd.Next(1, 1000);

            Pony pony = new Pony();
            pony.id = default;
            pony.name = "HelmutKohl" + month;
            pony.race = "Schetty";
            
            ApiService apiService = new ApiService();
            var result = apiService.AddPony(pony);

            Assert.NotNull(result);
            return pony.name;
        }

        [Fact]
        public void AddPony_False()
        {
            Random rnd = new Random();
            int month = rnd.Next(1, 1000);

            Pony pony = new Pony();
            pony.id = 1;
            pony.name = "HelmutKohl" + month;
            pony.race = "Schetty";

            ApiService apiService = new ApiService();
            var result = apiService.AddPony(pony);

            Assert.False(result.Result);
        }

        [Fact]
        public async void UpdatePony()
        {
            string name = AddPony();
            ApiService apiService = new ApiService();
            var allPonies = await apiService.GetAllPonies();
            Random rnd = new Random();
            int month = rnd.Next(10000, 100000000);  // creates a number between 1 and 12

            var pony = allPonies.Find(f => f.name == name);
            pony.name = "HelmutKohl" + month;
            pony.race = "Schetty";
            pony.age = "30";

            var result = apiService.UpdatePony(pony.id.ToString(), pony);
            Assert.True(result.Result);
            apiService.DeleteUser(pony.id.ToString());

        }
        [Fact]
        public async void UpdatePony_False()
        {
            string name = AddPony();
            ApiService apiService = new ApiService();
            var allPonies = await apiService.GetAllPonies();
            Random rnd = new Random();
            int month = rnd.Next(10000, 100000000);  // creates a number between 1 and 12

            var pony = allPonies.Find(f => f.name == name);
            pony.id = 100;
            pony.name = "HelmutKohl" + month;
            pony.race = "Schetty";

            var result = apiService.UpdatePony(pony.id.ToString(), pony);
            Assert.False(result.Result);
            

        }

        [Fact]
        public async void DeletePony()
        {
            string userName = AddPony();
            ApiService apiService = new ApiService();
            var allponies = await apiService.GetAllPonies();

            var pony = allponies.Find(f => f.name == userName);

            var result = apiService.DeleteUser(pony.id.ToString());
            Assert.True(result.Result);
        }

        [Fact]
        public async void DeletePony_False()
        {
            
            ApiService apiService = new ApiService();        
                      

            var result = apiService.DeleteUser("100000");
            Assert.True(result.Result);
        }

    }
}
