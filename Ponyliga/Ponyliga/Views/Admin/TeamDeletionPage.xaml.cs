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
    public partial class TeamDeletionPage : ContentPage
    {
        public List<Team> taskTeam;
        public TeamDeletionPage()
        {
            InitializeComponent();

            FillTeamList();
        }

        Dictionary<string, string> Teams = new Dictionary<string, string>();

        Picker picker = new Picker
        {
            Title = "Team",
            VerticalOptions = LayoutOptions.CenterAndExpand
        };

        public async void FillTeamList()
        {
            ApiService apiService = new ApiService();
            taskTeam = await apiService.GetAllTeams();

            var listOfTeams = new ArrayList();

            foreach (var team in taskTeam)
            {
                listOfTeams.Add(team.name);
            }

            TeamPicker.ItemsSource = listOfTeams;
        }

        public void TeamPicker_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            var team = TeamPicker.SelectedIndex;
            if (team >= 0)
            {
                string name = TeamPicker.Items[TeamPicker.SelectedIndex];
            }
            //DisplayAlert(name, "wurde als Team ausgewählt", "OK");
        }

        public void btn_deleteTeam_Clicked(object sender, EventArgs e)
        {
            string name = TeamPicker.Items[TeamPicker.SelectedIndex];

            Team team = new Team();

            int teamId = taskTeam.Find(t => t.name == name).id;
            team.id = teamId;

            ApiService apiService = new ApiService();
            apiService.DeleteTeam(team.id.ToString());

            DisplayAlert("Warnung", "Team wird gelöscht!", "OK");
            FillTeamList();
            TeamPicker.SelectedIndex = -1;
        }

    }
}