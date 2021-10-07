using Ponyliga.Models;
using Ponyliga.Services;
using Ponyliga.Views.Admin;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Ponyliga.Views.Admin
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GroupPage : ContentPage
    {
        ObservableCollection<RandomizeGroup> Groups = new ObservableCollection<RandomizeGroup>();
        ObservableCollection<RandomizeGroup> User { get { return Groups; } }
        public GroupPage()
        {
            InitializeComponent();
            FillGroupList();
        }

        public async void FillGroupList()
        {
            ApiService apiService = new ApiService();
            //Task<List<User>> task = apiService.GetAllUser(); 


            listViewRandomTeam.ItemsSource = Groups;
            int p = 0;
            int c = 1;

            List<string> position = new List<string>();
            position.Add("rechts");
            position.Add("mitte");
            position.Add("links");

            List<String> BackgroundList = new List<String>();
            BackgroundList.Add("Red");
            BackgroundList.Add("Blue");
            BackgroundList.Add("Green");
            BackgroundList.Add("Purple");
            BackgroundList.Add("Pink");

            var taskGroup = await apiService.GetAllGroups();

            if (taskGroup != null)
            {

                foreach (var group in taskGroup)
                {
                    foreach (var groups in group.teams)
                    {
                        Groups.Add(new RandomizeGroup() {    namegroup=group.name, groupName = groups.name, startingPosition = position[p], BackColour = BackgroundList[c] });

                        if (p >= 2)
                        {
                            p = 0;
                            c++;
                        }
                        else
                        {
                            p++;
                        }
                        
                    }
                }

            }
 

        }

        private void btn_createGroup_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new CreateGroup());
        }

        private void btn_delGroup_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new DeleteGroup());
        }

        private void btn_updateListOfUsers_Clicked(object sender, EventArgs e)
        {
            Groups.Clear();
            FillGroupList();
            DisplayAlert("Liste der Teams", "wurde aktualisiert.", "OK");

        }
    }
}