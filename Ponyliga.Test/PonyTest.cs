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
        public async System.Threading.Tasks.Task<int> AddPonyAsync()
        {
            Random rnd = new Random();
            int month = rnd.Next(1, 1000);

            Pony pony = new Pony();
            pony.id = default;
            pony.name = "HelmutKohl" + month;
            pony.race = "Schetty";
            
            ApiService apiService = new ApiService();
            var result = await apiService.AddPony(pony);

            Assert.NotNull(result);
            return result.id;
        }

        [Fact]
        public async void UpdatePony()
        {
            int id = await AddPonyAsync();
            ApiService apiService = new ApiService();

            Pony pony = new Pony { id = id, name = "HelmutKohl"};

            var result = await apiService.UpdatePony(pony.id.ToString(), pony);
            Assert.True(result);
            apiService.DeletePony(pony.id.ToString());

        }
        [Fact]
        public async void UpdatePony_False()
        {

            ApiService apiService = new ApiService();

            Pony pony = new Pony { id = 1000, name = "HelmutKohl"};

            var result = await apiService.UpdatePony(pony.id.ToString(), pony);
            Assert.False(result);
            

        }

        [Fact]
        public async void DeletePony()
        {
            int id = await AddPonyAsync();
            ApiService apiService = new ApiService();
            var result = await apiService.DeletePony(id.ToString());
            Assert.True(result);
        }

        [Fact]
        public async void DeletePony_False()
        {
            
            ApiService apiService = new ApiService();  
                      
            var result = await apiService.DeletePony("100000");
            Assert.False(result);
        }

    }
}
