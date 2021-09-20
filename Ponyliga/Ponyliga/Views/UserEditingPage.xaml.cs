using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Ponyliga.Models;
using Ponyliga.Services;

namespace Ponyliga.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserEditingPage : ContentPage
    {
        public UserEditingPage()
        {
            InitializeComponent();

            userRightsPicker.Items.Add("Admin");
            userRightsPicker.Items.Add("User");
            /*userRightsPicker.Items.Add("Rechte 3");
            userRightsPicker.Items.Add("Rechte 4");*/
        }

        private void btn_newUser_Clicked(object sender, EventArgs e)
        {
            string firstName = userFirstName.Text;
            string lastName = userLastName.Text;
            int rights = userRightsPicker.SelectedIndex;


            string loginName = userLoginName.Text;
            string password = userPassword.Text;

            //Liste


            if (rights != -1)
            {
                User user = new User();
                user.id = default;
                user.firstName = firstName;
                user.loginName = loginName;
                user.surName = lastName;
                user.passwordHash = password;
                user.userPrivileges = rights;

               

                Navigation.PushAsync(new MainPageAfterLogin());
            }
            else
            {
                DisplayAlert("Fehler", "Es wurden nicht alle Felder ausgefüllt!", "OK");
            }
        }
    }
}