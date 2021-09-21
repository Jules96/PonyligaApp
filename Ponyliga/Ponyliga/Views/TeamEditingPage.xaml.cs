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
    public partial class TeamEditingPage : ContentPage
    {
        public List<Team> taskTeam;
        public TeamEditingPage()
        {
            InitializeComponent();
            FillTeamList();
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
            string name = TeamPicker.Items[TeamPicker.SelectedIndex];

            Team team = taskTeam.Find(t => t.name == name);
            teamClubname.Text = team.club;
            //teamTeamname.Text = team.name;
            teamConsultor.Text = team.consultor;
            //
        }

        private void btn_editTeam_Clicked(object sender, EventArgs e)
        {
            if (TeamPicker.SelectedIndex != -1)
            {
                string name = TeamPicker.Items[TeamPicker.SelectedIndex];
                Team listTeam = taskTeam.Find(t => t.name == name);

                Team team = new Team();
                team.id = listTeam.id;
                team.club = teamClubname.Text;
                team.name = listTeam.name;
                team.consultor = teamConsultor.Text;
                team.teamSize = +0;
                team.groupId = +0;
                //team.group = ;

                ApiService apiService = new ApiService();
                apiService.UpdateTeam(team.id.ToString(), team);

                Navigation.PushAsync(new MainPageAfterLogin());
            }
            else
            {
                DisplayAlert("Fehler", "Es wurden nicht alle Felder ausgefüllt!", "OK");
            }
        }
    }
}