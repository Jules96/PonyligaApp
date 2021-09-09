using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Ponyliga.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TeamCreationPage : ContentPage
    {
        public TeamCreationPage()
        {
            InitializeComponent();
        }

        private void btn_CreateTeam_Clicked(object sender, EventArgs e)
        {
            string selectedTeamName = TeamName.Text;
            if (selectedTeamName != "" || selectedTeamName != "Teamnamen eingeben")
            {
                DisplayAlert("Das Team " + selectedTeamName, "wurde erstellt. Ihm können nun Mitglieder hinzugefügt werden.", "OK");
            }
            else
            {
                DisplayAlert("Achtung", "Es wurde kein Teamname ausgewählt.", "OK");
                selectedTeamName = "";
            }
        }

    }
}