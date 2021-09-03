using Ponyliga.Model;
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
            /*User user = new User();
            user.id = default;
            user.firstName = default;
            user.surName = default;
            user.loginName = loginName.Text;
            user.passwordHash = password.Text;
            user.userPrivileges = default;
            Console.WriteLine("HALLO");



            ApiService apiService = new ApiService();
            var b = apiService.AddData("userlogin", user);

            if (b.Result)
            {
                
            }
            //apiService.AddData("user", user);*/
            Navigation.PushAsync(new MainPageAfterLogin());
        }

       
      

        private void btn_Register_Clicked(object sender, EventArgs e)
        {
            //Navigation.PushAsync(new RegPage());
        }

        private void btn_MainPage_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new LandingPage());
        }
    }
}