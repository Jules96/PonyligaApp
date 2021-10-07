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
    public partial class TeamCreationPage : ContentPage
    {
        public TeamCreationPage()
        {
            InitializeComponent();
        }



        // bei Creation muss name auf Vorhandensein in DB geprüft werden
        // Namen müssen 
        private void btn_CreateTeam_Clicked(object sender, EventArgs e)
        {
            /* string selectedTeamName = TeamName.Text;
             string selectedClubName = ClubName.Text;
             string selectedConsultor = ConsultorName.Text;*/
            if (TeamName.Text != null && ClubName.Text != null && ConsultorName.Text != null)
            {
                Team team = new Team();
                team.club = ClubName.Text;
                team.name = TeamName.Text;
                team.place = default;
                team.consultor = ConsultorName.Text;
                team.teamSize = 0;
                team.groupId = default;
                // team.ponyId = default;  <-- steht in API-Doku drin aber geht nicht?
                // team.teamId = default;  <-- steht in API-Doku drin aber geht nicht?

                ApiService apiService = new ApiService();
                apiService.AddTeam(team);

                if (true)
                {
                    DisplayAlert("Das Team " + TeamName.Text, "wurde erstellt. Ihm können nun Mitglieder hinzugefügt werden.", "OK");

                    Navigation.PushAsync(new TeamsPage());
                }
                else
                {
                    DisplayAlert("Achtung", "Bitte nochmal versuchen. Fehler bei der Datenübergabe.", "OK");
                }
                //DisplayAlert("Das Team " + TeamName.Text, "wurde erstellt. Ihm können nun Mitglieder hinzugefügt werden.", "OK");

                //Navigation.PushAsync(new TeamsPage());
            }
            else
            {
                DisplayAlert("Fehler", "Mit * markierte Felder wurden nicht oder fehlerhaft ausgefüllt.", "OK");
            }
        }

    }

}