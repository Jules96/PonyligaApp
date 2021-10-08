using Ponyliga.Services;
using Ponyliga.Models;
using Xunit.Priority;
using Xunit;
using System.Threading.Tasks;
using System;

namespace Ponyliga.Test
{
   public class GroupTest
    {
        [Fact]

        public async void GetAllGroups()
        {
            ApiService apiService = new ApiService();
            //var = System.Threading.Tasks.Task<System.Collections.Generic.List<Models.User>>
            var result = await apiService.GetAllGroups();

            Assert.NotEmpty(result);

        }
        [Fact]
        public async Task<int> AddGroupAsync()
        {
            Random rnd = new Random();
            int month = rnd.Next(10000, 100000000);  // creates a number between 1 and 12

            Group group = new Group();
            group.id = default;
            group.name = "ponyGroup" + month;
            group.rule = 1;
            group.groupSize = 4;
            group.participants = "Merle, Jonas";


            ApiService apiService = new ApiService();
            var result = await apiService.AddGroup(group);

            Assert.NotNull(result);
            return result.id;

        }
        [Fact]
        public string AddGroup_False()
        {
            Group group = new Group();
            group.id = 1;
            group.name = "ponyGroup" ;
            group.rule = 1;
            group.groupSize = 4;
            group.participants = "Merle, Jonas";


            ApiService apiService = new ApiService();
            var result = apiService.AddGroup(group);

            Assert.Contains("WaitingForActivation", result.Status.ToString());
            return group.name;

        }


        [Fact]
        public async void UpdateGroup()
        {
            int id = await AddGroupAsync();
            ApiService apiService = new ApiService();

            Group group = new Group { id = id,name="Timons"};         

            var result = await apiService.UpdateGroup(group.id, group);

            Assert.NotNull(result);
            await apiService.DeleteGroup(group.id.ToString());


        }



        [Fact]
        public async void DeleteGroup()
        {
            ApiService apiService = new ApiService();
            var groups = await apiService.GetAllGroups();
            var result = false;

            foreach (var group in groups)
            {
                foreach (var team in group.teams)
                {
                    team.groupId = null;

                     await apiService.UpdateTeam(team.id.ToString(), team);
                }
                result = await apiService.DeleteGroup(group.id.ToString());

            }
            Assert.True(result);

        }

        [Fact, Priority(35)]
        public async void DeleteGroup_False()
        {
            ApiService apiService = new ApiService();

            var result = apiService.DeleteGroup("100000");
            Assert.False(result.Result);
        }


    }
}