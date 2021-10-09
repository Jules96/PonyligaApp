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

        public async void btn_deleteTeam_Clicked(object sender, EventArgs e)
        {
            /*   if(TeamPicker.SelectedIndex != -1)
               {
                   string name = TeamPicker.Items[TeamPicker.SelectedIndex];

                   Team team = new Team();

                   int teamId = taskTeam.Find(t => t.name == name).id;
                   team.id = teamId;

                   ApiService apiService = new ApiService();
                   Team teams = new Team { id = teamId, groupId = null };
                   await apiService.UpdateTeam(teamId.ToString(), team);

                   var results = await apiService.GetResultSummary();

                       foreach (var group in results)
                       {
                           if (group.id == teamId)
                           {
                               foreach (var resu in group.results)
                               {
                                   await apiService.DeleteResult(resu.id.ToString());
                               }
                           }

                       }



                   var allTeamMember = await apiService.GetAllTeamMembers();

                   foreach(var teammember in allTeamMember)
                   {
                       if (teamId == teammember.teamId)
                       {
                           await apiService.DeleteTeammeber(teammember.id.ToString());
                       }



                   }


                   var result = await apiService.DeleteTeam(team.id.ToString());
                   if (result)
                   {
                       DisplayAlert("Warnung", "Team wird gelöscht!", "OK");
                   }


                   FillTeamList();
                   TeamPicker.SelectedIndex = -1;
               }*/
            if (TeamPicker.SelectedIndex != -1)
            {
                string name = TeamPicker.Items[TeamPicker.SelectedIndex];

                Team team = new Team();

                int teamId = taskTeam.Find(t => t.name == name).id;
                team.id = teamId;

                ApiService apiService = new ApiService();             
                

                var result = await apiService.DeleteTeam(team.id.ToString());
                TeamPicker.SelectedIndex = -1;
                if(result)
                {
                    DisplayAlert("Achtung", "Team wurd gelöscht", "OK");
                }
                

            }
        }

    }
}