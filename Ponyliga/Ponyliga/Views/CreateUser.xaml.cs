using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
//using Ponyliga.Models;
using Ponyliga.ViewModels;
using Ponyliga.Model;

namespace Ponyliga.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CreateUser : ContentPage
    {
        public CreateUser()
        {
            InitializeComponent();

            userRightsPicker.Items.Add("Rechte 1");
            userRightsPicker.Items.Add("Rechte 2");
            userRightsPicker.Items.Add("Rechte 3");
            userRightsPicker.Items.Add("Rechte 4");
        }

        public void btn_newUser_Clicked(object sender, EventArgs e)
        {
            string firstName = userFirstName.Text;
            string lastName = userLastName.Text;
            string rights = userRightsPicker.Items[userRightsPicker.SelectedIndex];
            string loginName = userLoginName.Text;
            string password = userPassword.Text;
            string id = userId.Text;


            
                
            
            List<User> user = new List<User>();
            user.Add(new User()
            {
                firstName = firstName,
                surName = lastName,
                loginName = loginName,
                passwordHash = password,
                userPrivileges = Int16.Parse(rights)
            });




            Navigation.PushAsync(new MainPageAfterLogin());
        }


    }
}