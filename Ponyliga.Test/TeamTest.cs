using Ponyliga.Services;
using Ponyliga.Models;
using Xunit.Priority;
using Xunit;
using System.Threading.Tasks;
using System;

namespace Ponyliga.Test
{
    public class TeamTest
    {
        [Fact]

        public async void GetAllTeams()
        {
            ApiService apiService = new ApiService();
            //var = System.Threading.Tasks.Task<System.Collections.Generic.List<Models.User>>
            var result = await apiService.GetAllTeams();

            Assert.NotEmpty(result);

        }
        [Fact]
        public async Task<int> AddTeamAsync()
        {
            Random rnd = new Random();
            int month = rnd.Next(10000, 100000000);  // creates a number between 1 and 12

            Team team = new Team();
            team.id = default;
            team.club = "RuV Herzlake";
            team.name = "Herzlake" + month;
            team.consultor = "Helmut Kohl";

            ApiService apiService = new ApiService();
            var result = await apiService.AddTeam(team);

            Assert.NotNull(result);
            return result.id;

        }
        [Fact]
        public string AddTeam_False()
        {
            Team team = new Team();
            team.id = 3;
            team.club = "RuV Herzlake";
            team.name = "Herzlake";
            team.consultor = "Helmut Kohl";


            ApiService apiService = new ApiService();
            var result = apiService.AddTeam(team);

            Assert.Contains("WaitingForActivation", result.Status.ToString());
            return team.name;

        }


        [Fact]
        public async void UpdateTeam()
        {
            int id = await AddTeamAsync();
            ApiService apiService = new ApiService();
            Random rnd = new Random();
            int month = rnd.Next(10000, 100000000);


            Team team = new Team { id = id, name = "HelloWorld"+month };
            
            var result = apiService.UpdateTeam(team.id.ToString(), team);

            Assert.True(result.Result);
            //apiService.DeleteTeam(team.id.ToString());


        }

        

        [Fact]
        public async void DeleteTeam()
        {
            int id = await AddTeamAsync();
            ApiService apiService = new ApiService();


            var result = await apiService.DeleteTeam(id.ToString());
            Assert.True(result);

        }

        [Fact, Priority(35)]
        public async void DeleteTeam_False()
        {
            ApiService apiService = new ApiService();

            var result = apiService.DeleteTeam("100000");
            Assert.False(result.Result);
        }


    }
}