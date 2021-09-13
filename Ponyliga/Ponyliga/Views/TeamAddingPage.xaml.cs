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
    public partial class TeamAddingPage : ContentPage
    {
        public List<Team> taskTeam;
        public TeamAddingPage()
        {
            InitializeComponent();

            FillTeamList();
            /*TeamPicker.Items.Add("Die Bifis");
            TeamPicker.Items.Add("Team 2: Electric Boogaloo");
            TeamPicker.Items.Add("Teamname 3");
            TeamPicker.Items.Add("OMEGALUL");*/

        }
       
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
            int team = TeamPicker.SelectedIndex;
            string teamName = TeamPicker.Items[TeamPicker.SelectedIndex];
            DisplayAlert(teamName, "wurde als Team ausgewählt", "OK");
        }

        private void btn_AddPerson_Clicked(object sender, EventArgs e)
        {
            if (TeamPicker.SelectedIndex > -1 && TeamMemberFirstName.Text != null && TeamMemberLastName.Text != null) 
            {
                var teams = taskTeam;
                string teamName = TeamPicker.Items[TeamPicker.SelectedIndex];
                int teamId = teams.Find(t => t.name == teamName).id;

                TeamMember teammember = new TeamMember();
                teammember.id = default;
                teammember.teamId = teamId;
                teammember.firstName = TeamMemberFirstName.Text;
                teammember.surName = TeamMemberLastName.Text;

                ApiService apiService = new ApiService();
                apiService.AddTeamMember(teammember);

                DisplayAlert(TeamMemberFirstName.Text + " " + TeamMemberLastName.Text, " wurde dem Team " + teamName + " hinzugefügt.", "OK");

                Navigation.PushAsync(new TeamsPage());
            }
            else
            {
                DisplayAlert("Fehler", "Mit * markierte Felder wurden nicht oder fehlerhaft ausgefüllt.", "OK");
            }
        }

        private void btn_AddPony_Clicked(object sender, EventArgs e)
        {
            if (TeamPicker.SelectedIndex >= 0 && PonyName.Text != null)
            {
                //int team = TeamPicker.SelectedIndex;
                var teams = taskTeam;
                string teamName = TeamPicker.Items[TeamPicker.SelectedIndex];
                //int teamId = teams.Find(t => t.name == teamName).id;

                Pony pony = new Pony();
                pony.id = default;
                pony.name = PonyName.Text;
                if (PonyBreed.Text != null)
                    pony.race = PonyBreed.Text;
                else pony.race = "";
                if (PonyAge.Text != null)
                    pony.age = PonyAge.Text;
                else pony.age = "";

                ApiService apiService = new ApiService();
                apiService.AddPony(pony);

                DisplayAlert(PonyName.Text, "wurde dem Team " + teamName + " hinzugefügt.", "OK");

                Navigation.PushAsync(new TeamsPage());
            }
            else
            {
                DisplayAlert("Fehler", "Mit * markierte Felder wurden nicht oder fehlerhaft ausgefüllt.", "OK");
            }
        }

    }
}
