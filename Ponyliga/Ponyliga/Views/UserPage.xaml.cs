using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ponyliga.ViewModels;
using Ponyliga.Models;
using System.Collections.ObjectModel;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Ponyliga.Services;

namespace Ponyliga.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserPage : ContentPage
    {

        ObservableCollection<User> Users = new ObservableCollection<User>();
        ObservableCollection<User> User { get { return Users; } }
    

        public UserPage()
        {
            InitializeComponent();
            FillUserList();


            //MyItems.Add(new Team() { name = "Herzlake II", teamSize = 5, consultor = "Harald" });
            //MyItems.Add(new Team() { name = "Herzlake I", teamSize = 5, consultor = "Achim" });
            //MyItems.Add(new Team() { name = "Haselünne", teamSize = 5, consultor = "Timon" });
            //MyItems.Add(new Team() { name = "Meppen", teamSize = 5, consultor = "Die Jungs von der Straße" });
        }

        async void Handle_ItemTappedn(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
                return;

            await DisplayAlert("Item Tapped", "An item was tapped.", "OK");

            //Deselect Item
            ((ListView)sender).SelectedItem = null;
        }

        private void btn_updateListOfUsers_Clicked(object sender, EventArgs e)
        {
            //iwie Liste aktualisieren
        }

        private void btn_edUser_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new UserEditingPage());
        }

        private void btn_delUser_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new UserDeletionPage());
        }

        private void btn_Register_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new CreateUserPage());
        }

        public async void FillUserList()
        {
            ApiService apiService = new ApiService();
            //Task<List<User>> task = apiService.GetAllUser(); 
            var taskUser = await apiService.GetAllUser();

            listViewUser.ItemsSource = Users;

            foreach (var user in taskUser)
                Users.Add(new User() {firstName = user.firstName, surName = user.surName, loginName = user.loginName, userPrivileges = user.userPrivileges });

        }
    }
}

