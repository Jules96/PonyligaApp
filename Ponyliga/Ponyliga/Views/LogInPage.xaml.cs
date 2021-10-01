using Ponyliga.Models;
using Ponyliga.Services;
using System;

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
            //User user = new User();
            //user.id = default;
            //user.firstName = default;
            //user.surName = default;
            //user.loginName = username.Text;
            //user.passwordHash = password.Text;
            //user.userPrivileges = default;
            string userName = username.Text;
            GetUsermame();

            //ApiService apiService = new ApiService();
            //bool result = apiService.LogInUser(user).Result;


            //if (result)
            //{
            //    Navigation.PushAsync(new MainPageAfterLogin());
            //}
            //else
            //{
            //    DisplayAlert("Fehler", "Passwort oder Benutzername ist falsch!", "ok");
            //}
            Navigation.PushAsync(new MainPageAfterLogin(userName));
        }

        private void btn_Register_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new CreateUserPage());
        }


        private void btn_LandingPage_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }

        string userName = "";
        public string GetUsermame()
        {
            
            if (userName != null)
            {
                userName = username.Text;
            }
            return userName;
        }
    }
}