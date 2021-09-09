using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Ponyliga.Models;

namespace Ponyliga.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TeamAddingPage : ContentPage
    {
        public TeamAddingPage()
        {
            InitializeComponent();

            TeamPicker.Items.Add("Die Bifis");
            TeamPicker.Items.Add("Team 2: Electric Boogaloo");
            TeamPicker.Items.Add("Teamname 3");
            TeamPicker.Items.Add("OMEGALUL");
        }

        public void TeamPicker_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            int team = TeamPicker.SelectedIndex;
            string teamName = TeamPicker.Items[TeamPicker.SelectedIndex];
            DisplayAlert(teamName, "wurde als Team ausgewählt", "OK");
        }

        private void btn_AddPerson_Clicked(object sender, EventArgs e)
        {

            int team = TeamPicker.SelectedIndex;
            string teamName = "";
            if ((TeamPicker.SelectedIndex) >= 0) 
            {
                teamName = TeamPicker.Items[TeamPicker.SelectedIndex];
            }
            
            
            string firstNameOfMember = TeamMemberFirstName.Text;
            string lastNameOfMember = TeamMemberLastName.Text;

            /*List<TeamMember> teammember = new List<TeamMember>();
            teammember.Add(new TeamMember()
            {
                //id = default, nein
                firstName = firstNameOfMember,
                surName = lastNameOfMember,
                //teamId = , ja
                //team = team ???????? nein
            }
                );*/

            TeamMember teammember = new TeamMember();
            teammember.id = default;
            teammember.firstName = firstNameOfMember;
            teammember.surName = lastNameOfMember;
            //teammember.teamId = default; ??
            //teammember.team = team;


            
            if (TeamPicker.SelectedIndex != -1 || firstNameOfMember != "" || lastNameOfMember != "") 
            {
                //var dataForPerson = new List<string> { team, firstNameOfMember, lastNameOfMember };
                //dataForPerson iwie an DB
                DisplayAlert(firstNameOfMember + " " + lastNameOfMember, " wurde dem Team " + teamName + " hinzugefügt.", "OK");
            }
            else
            {
                DisplayAlert("Fehler", "Mit * markierte Felder wurden nicht oder fehlerhaft ausgefüllt.", "OK");
            }
        }

        private void btn_AddPony_Clicked(object sender, EventArgs e)
        {

            int team = TeamPicker.SelectedIndex;
            string teamName = "";
            if ((TeamPicker.SelectedIndex) >= 0)
            {
                teamName = TeamPicker.Items[TeamPicker.SelectedIndex];
            }
            string nameOfPony = PonyName.Text;
            string breedOfPony = PonyBreed.Text;
            string ageOfPony = /*Int16.Parse(*/PonyAge.Text/*)*/; //wenn ich das int mache (statt var), gibts ne Fehlermeldung bei Nicht-Eintragung

            /*List<Pony> pony = new List<Pony>();
            pony.Add(new Pony()
            {
                //teamId = default, ja
                //id = default, nein
                name = nameOfPony,
                race = breedOfPony,
                age = ageOfPony
            }
                ); */

            Pony pony = new Pony();
            pony.id = default;
            pony.name = nameOfPony;
            pony.race = breedOfPony;
            pony.age = ageOfPony;
            //pony.teams = team; 
            //pony.teamPonies = ???

           /* List<TeamPony> teampony = new List<TeamPony>();
            teampony.Add(new TeamPony()
            {
                //teamId = default, ja
                //team = team, ?????? nein
                //ponyId = default, ja
                //pony = ???? nein
            }
                ) ; */

            if (TeamPicker.SelectedIndex != -1 || nameOfPony != "")
            {
                //var dataForPony = new List<string> { team, nameOfPony, breedOfPony, ageOfPony};
                //dataForPony iwie an DB
                DisplayAlert(nameOfPony, "wurde dem Team " + teamName + " hinzugefügt.", "OK");
            }
            else
            {
                DisplayAlert("Fehler", "Mit * markierte Felder wurden nicht oder fehlerhaft ausgefüllt.", "OK");
            }
        }

    }
}
