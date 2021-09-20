using Newtonsoft.Json;
using Ponyliga.Models;
using Ponyliga.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        private void btn_LogIn_Clicked(object sender, EventArgs e)
        {
            User user = new User();
            user.id = default;
            user.firstName = default;
            user.surName = default;
            user.loginName = username.Text;
            user.passwordHash = password.Text;
            user.userPrivileges = default;


            ApiService apiService = new ApiService();
            bool result = apiService.LogInUser(user).Result;


            if (result)
            {
                Navigation.PushAsync(new MainPageAfterLogin());
            }
            else
            {
                DisplayAlert("Fehler", "Passwort oder Benutzername ist falsch!", "ok");
            }
        }

        private void btn_Register_Clicked(object sender, EventArgs e)
        {
           /* User user = new User();
            user.id = default;
            user.firstName = default;
            user.surName = default;
            user.loginName = username.Text;
            user.passwordHash = password.Text;
            user.userPrivileges = default;


            ApiService apiService = new ApiService();
            bool result = apiService.LogInUser(user).Result;

            
            if(result)
            {
                Navigation.PushAsync(new CreateUserPage());
            }*/

            Navigation.PushAsync(new CreateUserPage());
        }

        private void btn_MainPage_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new LandingPage());
        }
    }
}