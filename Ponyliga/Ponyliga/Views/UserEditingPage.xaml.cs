using System;
using System.Collections;
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
        public List<User> taskUser;
        public UserEditingPage()
        {
            InitializeComponent();
            FillUserList();

            userRightsPicker.Items.Add("User");
            userRightsPicker.Items.Add("Admin");
        }

        public async void FillUserList()
        {
            ApiService apiService = new ApiService();
            taskUser = await apiService.GetAllUser();

            var listOfUsers = new ArrayList();

            foreach (var user in taskUser)
            {
                listOfUsers.Add(user.loginName);
            }

            UserPicker.ItemsSource = listOfUsers;
        }

        public void UserPicker_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            string loginName = UserPicker.Items[UserPicker.SelectedIndex];
            User user = taskUser.Find(u => u.loginName == loginName);
            userFirstName.Text = user.firstName;
            userLastName.Text = user.surName;
            userPassword.Text = user.passwordHash;
            userRightsPicker.SelectedIndex = user.userPrivileges;
        }

        private void btn_editUser_Clicked(object sender, EventArgs e)
        {
            if (UserPicker.SelectedIndex != -1)
            {
                string loginName = UserPicker.Items[UserPicker.SelectedIndex];
                User listUser = taskUser.Find(u => u.loginName == loginName);

                if (userRightsPicker.SelectedIndex != -1)
                {
                    User user = new User();
                    user.id = listUser.id;
                    user.firstName = userFirstName.Text;
                    user.loginName = listUser.loginName;
                    user.surName = userLastName.Text;
                    user.passwordHash = userPassword.Text;
                    user.userPrivileges = userRightsPicker.SelectedIndex;

                    ApiService apiService = new ApiService();
                    apiService.UpdateUser(user.id.ToString(), user);

                    Navigation.PushAsync(new MainPageAfterLogin());
                }
                else
                {
                    DisplayAlert("Fehler", "Es wurden nicht alle Felder ausgefüllt!", "OK");
                }
            }
        }
    }
}