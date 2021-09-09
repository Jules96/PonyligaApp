using Ponyliga.Models;
using Ponyliga.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Ponyliga.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserTablePage : ContentPage
    {
        ObservableCollection<User> Users = new ObservableCollection<User>();
        ObservableCollection<User> User { get { return Users; } }

        public UserTablePage()
        {

            FillUserList();
            UpdateUser();
            InitializeComponent();
        }

        //GET all Data
        public async void FillUserList()
        {
            ApiService apiService = new ApiService();
            //Task<List<User>> task = apiService.GetAllUser();
            var taskUser = await apiService.GetAllUser();

            listViewUser.ItemsSource = Users;

            foreach (var user in taskUser)
                Users.Add(new User() { id = user.id, firstName = user.firstName, surName = user.surName, loginName = user.loginName, userPrivileges = user.userPrivileges });

        }

        async void Handle_ItemiTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
                return;

            await DisplayAlert("", "An item was tapped.", "OK");

            //Deselect Item
            ((ListView)sender).SelectedItem = null;
        }

        private void btn_Update_Clicked(object sender, EventArgs e)
        {
            User user = new User();
            user.id = 1;
            user.firstName = "Homer";
            user.surName = "Simpson";
            user.loginName = "HOMSIM";
            user.passwordHash = "123123";
            user.userPrivileges = 1;
            ApiService apiService = new ApiService();
            apiService.UpdateUser("1", user);
        }

        public async void UpdateUser()
        {
            User user = new User();
            user.id = 1;
            user.firstName = "Homer";
            user.surName = "Simpson";
            user.loginName = "HOMSIM";
            user.passwordHash = "123123";
            user.userPrivileges = 1;

            ApiService apiService = new ApiService();
            apiService.UpdateUser("1", user);

        }

        public async void AddUser()
        {
            // FALSCH
            //List<User> user = new List<User>();
            //user.Add(new User() { firstName = "Homer", surName = "Simpson", loginName = "HOSIM", passwordHash = "123123", userPrivileges = 1 });

            //RICHTIG 
            User user = new User();
            user.id = default;
            user.firstName = "Homer";
            user.surName = "Simpson";
            user.loginName = "HOMSIM";
            user.passwordHash = "123123";
            user.userPrivileges = 1;



            ApiService apiService = new ApiService();
            apiService.AddUser(user);

            //foreach (var users in user)
            //  Users.Add(new Model.User() { id = users.id, firstName = users.firstName, surName = users.surName, loginName = users.loginName, userPrivileges = users.userPrivileges });


        }
    }
}