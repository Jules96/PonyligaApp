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
    public partial class TeamsPage : ContentPage
    {

        ObservableCollection<Team> Teams = new ObservableCollection<Team>();
        ObservableCollection<Team> Team { get { return Teams; } }

        public TeamsPage()
        {
            InitializeComponent();
            FillUserList();

            /*listViewn.ItemsSource = MyItems;

            MyItems.Add(new Team() { name = "Herzlake II", teamSize = 5, consultor = "Harald" });
            MyItems.Add(new Team() { name = "Herzlake I", teamSize = 5, consultor = "Achim" });
            MyItems.Add(new Team() { name = "Haselünne", teamSize = 5, consultor = "Timon" });
            MyItems.Add(new Team() { name = "Meppen", teamSize = 5, consultor = "Die Jungs von der Straße" });*/
        }

        async void Handle_ItemTappedn(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
                return;

            await DisplayAlert("Item Tapped", "An item was tapped.", "OK");

            //Deselect Item
            ((ListView)sender).SelectedItem = null;
        }



        private void btn_createTeam_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new TeamCreationPage());
        }

        private void btn_addMembers_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new TeamAddingPage());
        }

        private void btn_updateListOfTeams_Clicked(object sender, EventArgs e)
        {
            //iwie Liste aktualisieren
        }

        private void btn_editExistingTeam_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new TeamEditingPage());
        }

        private void btn_deleteExistingTeam_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new TeamDeletionPage()); //getrennt von TeamEditingPage um versehentliches Löschen zu vermeiden
        }

        public async void FillUserList()
        {
            ApiService apiService = new ApiService();
            //Task<List<User>> task = apiService.GetAllUser(); 
            var taskTeam = await apiService.GetAllTeams();

            listViewTeams.ItemsSource = Teams;

            if (taskTeam != null)
            {
                foreach (var team in taskTeam)
                    Teams.Add(new Team() { name = team.name, teamSize = team.teamSize, consultor = team.consultor });
            }
           /* else
            {
                DisplayAlert("Achtung!", "Es sind keine Teams vorhanden!", "OK");

            }*/

           

        }
    }
}

