using Ponyliga.Models;
using Ponyliga.Services;
using Ponyliga.Views.Users;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Ponyliga.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LogInPage : ContentPage
    {
        public LogInPage()
        {
            InitializeComponent();   
        }

        private async void btn_LogIn_Clicked(object sender, EventArgs e)
        {
            User user = new User();
            user.id = default;
            user.firstName = default;
            user.surName = default;
            user.loginName = username.Text;
            user.passwordHash = password.Text;
            user.userPrivileges = default;
            string userName = username.Text;
            

            ApiService apiService = new ApiService();
            bool result = apiService.LogInUser(user).Result;          


            if (result)
            {
                var userPrivileges = await GetUsernameAsync();
                if (App.Current.Properties.ContainsKey("userName"))
                    App.Current.Properties["userName"] = username.Text;
                else
                    App.Current.Properties.Add("userName", username.Text);
                if (userPrivileges.userPrivileges == 0)
                {
                    await Navigation.PushAsync(new MainPageAfterLogin(userName));
                }
                else if (userPrivileges.userPrivileges == 1)
                        {
                    await Navigation.PushAsync(new MainPagerAfterLoginUser(userName));
                }                                  
                
            }
            else
            {
                await DisplayAlert("Fehler", "Passwort oder Benutzername ist falsch!", "ok");
            }

            
        }

        public async Task<User> GetUsernameAsync()
        {
            
            ApiService apiService = new ApiService();
            var allusers = await apiService.GetAllUser();
            var user = allusers.Find(f => f.loginName == (username.Text));

            return user;
        }

       /* private void btn_Register_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new CreateUserPage());
        }*/
       
        private void btn_LandingPage_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }


    }
}