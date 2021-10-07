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
        public string AddGroup()
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
            var result = apiService.AddGroup(group);

            Assert.NotNull(result);
            return group.name;

        }

        public string AddGroup_False()
        {
            Random rnd = new Random();
            int month = rnd.Next(10000, 100000000);  // creates a number between 1 and 12

            Group group = new Group();
            group.id = 1;
            group.name = "ponyGroup" + month;
            group.rule = 1;
            group.groupSize = 4;
            group.participants = "Merle, Jonas";


            ApiService apiService = new ApiService();
            var result = apiService.AddGroup(group);

            Assert.Null(result);
            return group.name;

        }


        [Fact]
        public async void UpdateGroup()
        {
            string name = AddGroup();
            ApiService apiService = new ApiService();
            var allGroup = await apiService.GetAllGroups();

            Random rnd = new Random();
            int month = rnd.Next(10000, 100000000);  // creates a number between 1 and 12

            var group = allGroup.Find(f => f.name == name);
            group.id = 2;
            group.name = "ponyGroup" + month;
            group.rule = 1;
            group.groupSize = 4;
            group.participants = "Merle, Jonas";


            var result = apiService.UpdateGroup(group.id, group);

            Assert.True(result.Result);
            apiService.DeleteUser(group.id.ToString());


        }

        [Fact, Priority(25)]
        public async Task UpdateGroup_FalseAsync()
        {
            string name = AddGroup();
            ApiService apiService = new ApiService();
            var allGroup = await apiService.GetAllGroups();

            var group = allGroup.Find(f => f.name == name);

            group.name = group.name;
            group.rule = 0;
            group.groupSize = 4;
            group.participants = "Merle, Jonas";


            var result = apiService.UpdateGroup(group.id, group);

            Assert.True(result.Result);
            apiService.DeleteUser(group.id.ToString());
        }

        [Fact]
        public async void DeleteGroup()
        {
            string userName = AddGroup();
            ApiService apiService = new ApiService();
            var allGroups = await apiService.GetAllGroups();

            var group = allGroups.Find(f => f.name == userName);

            var result = apiService.DeleteGroup(group.id.ToString());
            Assert.True(result.Result);

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