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

namespace Ponyliga.Views.Admin
{
    [XamlCompilation(XamlCompilationOptions.Compile)]

    public partial class UserDeletionPage : ContentPage
    {
        public List<User> taskUser;
        public UserDeletionPage()
        {
            InitializeComponent();

            FillUserList();
        }

        Dictionary<string, string> Users = new Dictionary<string, string>();

        Picker picker = new Picker
        {
            Title = "User",
            VerticalOptions = LayoutOptions.CenterAndExpand
        };

        public async void FillUserList()
        {
            ApiService apiService = new ApiService();
            taskUser = await apiService.GetAllUser();
            /*
            foreach (var User in taskUser)
            {
                Users.Add(User.id.ToString(), User.loginName);
                foreach (string user in Users.Keys)
                {
                    picker.Items.Add(user);
                }
            }

            BoxView boxView = new BoxView
            {
                WidthRequest = 150,
                HeightRequest = 150,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };

            picker.SelectedIndexChanged += (sender, args) =>
            {
                if (picker.SelectedIndex == -1)
                {
                    boxView.Color = Color.Default;
                }
                else
                {
                    string loginName = picker.Items[picker.SelectedIndex];
                    //boxView.Color = Users[userName];
                }
            };
            */

            var listOfUsers = new ArrayList();
            string username;



            foreach (var user in taskUser)
            {
                //Users.Add(user.loginName, user.id.ToString());
                listOfUsers.Add(user.loginName);
                
            }
            if (App.Current.Properties.ContainsKey("userName"))
            {
                username = App.Current.Properties["userName"] as string;
                int index = listOfUsers.IndexOf(username);
                listOfUsers.RemoveAt(index);
            }
            
            UserPicker.ItemsSource = listOfUsers;
        }

        public void UserPicker_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            var user = UserPicker.SelectedIndex;
            if (user >= 0)
            {
                string loginName = UserPicker.Items[UserPicker.SelectedIndex];
            }
                
            //DisplayAlert(loginName, "wurde als User ausgewählt", "OK");
        }

        private void btn_deleteUser_Clicked(object sender, EventArgs e)
        {
            if(UserPicker.SelectedIndex != -1)
            {
                string loginName = UserPicker.Items[UserPicker.SelectedIndex];

                User user = new User();

                int userId = taskUser.Find(u => u.loginName == loginName).id;
                user.id = userId;

                ApiService apiService = new ApiService();
                LogInPage logInPage = new LogInPage();


                apiService.DeleteUser(user.id.ToString());
                DisplayAlert("Warnung", "User wird gelöscht!", "OK");


                FillUserList();
                UserPicker.SelectedIndex = -1;
            }
           
          

            

           


        }
    }
}