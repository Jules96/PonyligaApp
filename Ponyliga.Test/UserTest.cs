using System;
using Xunit;
using Ponyliga.Services;
using Ponyliga.Models;
using Xunit.Priority;

namespace Ponyliga.Test
{
    [Collection("Sequential")]
    [TestCaseOrderer(PriorityOrderer.Name, PriorityOrderer.Assembly)]
    public class UserTest
    {



        [Fact, Priority(-15)]
        public async void GetAllUser()
        {
            ApiService apiService = new ApiService();
            //var = System.Threading.Tasks.Task<System.Collections.Generic.List<Models.User>>
            var result = await apiService.GetAllUser();

            Assert.NotEmpty(result);     
      
            
        }


        

        [Fact, Priority(-5)]
        public string AddUser()
        {
            Random rnd = new Random();
            int month = rnd.Next(10000, 100000000);  // creates a number between 1 and 12

            User user = new User();
            user.id = default;
            user.firstName = "Hanse";
            user.surName = "Peter";
            user.loginName = "lustig" + month.ToString();
            user.passwordHash = "123";

            ApiService apiService = new ApiService();
            var result = apiService.AddUser(user);

            Assert.True(result.Result);
            return user.loginName;

        }

        [Fact, Priority(0)]
        public void AddUser_False()
        {
            Random rnd = new Random();
            int month = rnd.Next(1, 10000);  // creates a number between 1 and 12

            User user = new User();
            user.id = default;
            user.firstName = "Hanse";
            user.surName = "Peter";
            user.loginName = "admin";
            user.passwordHash = "123";

            ApiService apiService = new ApiService();
            var result = apiService.AddUser(user);

            Assert.False(result.Result);

        }

        [Fact, Priority(10)]
        public void LogInUser()
        {
            User user = new User();
            user.loginName = "admin";
            user.passwordHash = "admin123";

            ApiService apiService = new ApiService();
            var result = apiService.LogInUser(user);

            Assert.True(result.Result);

        }

        [Fact, Priority(15)]
        public void LogInUser_False()
        {
            User user = new User();
            user.loginName = "admin";
            user.passwordHash = "123";

            ApiService apiService = new ApiService();
            var result = apiService.LogInUser(user);

            Assert.False(result.Result);
            

        }

        [Fact]
        public async void UpdateUser()
        {
            string name = AddUser();
            ApiService apiService = new ApiService();
            var allUser = await apiService.GetAllUser();

            Random rnd = new Random();
            int month = rnd.Next(10000, 100000000);  // creates a number between 1 and 12

            var users = allUser.Find(f => f.loginName == name);

                users.firstName = "Peter";
                users.surName = "Lustig";
                users.loginName = "Bauwagen" + month;
                users.passwordHash = "admin123";


                var result = apiService.UpdateUser(users.id.ToString(), users);

                Assert.True(result.Result);
                apiService.DeleteUser(users.id.ToString());






        }

        [Fact, Priority(25)]
        public void UpdateUser_False()
        {

            User user = new User();
            user.id = 100;
            user.firstName = "El Mino";
            user.surName = "admin";
            user.loginName = "admin";
            user.passwordHash = "admin123";

            ApiService apiService = new ApiService();
            var result = apiService.UpdateUser("1", user);

            Assert.False(result.Result);
        }

        [Fact]
        public async void DeleteUser()
        {
            string userName = AddUser();
            ApiService apiService = new ApiService();
            var allUser = await apiService.GetAllUser();

                var user = allUser.Find(f => f.loginName == userName);

                var result = apiService.DeleteUser(user.id.ToString());
                Assert.True(result.Result);
     

        }
        
        [Fact, Priority(35)]
        public async void DeleteUser_False()
        {
            ApiService apiService = new ApiService();
                      

            var result = apiService.DeleteUser("100000");
            Assert.False(result.Result);
        }


    }
}
