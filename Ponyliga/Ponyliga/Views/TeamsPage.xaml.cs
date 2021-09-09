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
    public partial class TeamsPage : ContentPage
    {
        public TeamsPage()
        {
            InitializeComponent();
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
            //wahrscheinlich neue Page dafür?
        }

        private void btn_deleteExistingTeam_Clicked(object sender, EventArgs e)
        {
            //auch neue Page; getrennt von edit-Page um versehentliches Löschen zu vermeiden?
        }
    }
}