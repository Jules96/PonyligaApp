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

namespace Ponyliga.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserPage : ContentPage
    {

        ObservableCollection<User> MyItems = new ObservableCollection<User>();
        ObservableCollection<User> Item { get { return MyItems; } }

        public UserPage()
        {
            InitializeComponent();

            listViewn.ItemsSource = MyItems;

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
    }
}

