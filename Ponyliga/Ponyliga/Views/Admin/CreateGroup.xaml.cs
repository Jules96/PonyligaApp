using Ponyliga.Models;
using Ponyliga.Services;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
 
namespace Ponyliga.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CreateGroup : ContentPage
    {
        // List<RandomizeGroup> Users = new List<RandomizeGroup>();
      
        ObservableCollection<RandomizeGroup> Users = new ObservableCollection<RandomizeGroup>();
        ObservableCollection<RandomizeGroup> User { get { return Users; } }
        public List<String> BackgroundList = new List<String>();
        public List<Team> taskTeam;


        public CreateGroup()
        {
            InitializeComponent();
            this.BindingContext = this;
            

        }
        private async void btn_Randomize_Clicked(object sender, EventArgs e)
        {
            ApiService api = new ApiService();
            var group = await api.GetAllGroups();
            if(group.Count == 0)
            {
                await GetGroupListAsync();
            }
            else
            {
                await DisplayAlert("Vorsicht", "Gruppeneinteilung wurden bereits erstellt. Falls Sie eine neue Gruppeneinteilung erstellen möchten, löschen Sie die aktuelle Gruppen", "OK");
            }
        }


        public async Task GetGroupListAsync()
        {

            ApiService apiService = new ApiService();
            taskTeam = await apiService.GetAllTeams();

            List<string> teamList = new List<string>();

            foreach (var team in taskTeam)
                teamList.Add(team.name);

            randomizeList(teamList);
        }

        public async void randomizeList(List<string> teamList)
        {
            List<String> BackgroundList = new List<String>();
            BackgroundList.Add("Red");
            BackgroundList.Add("Blue");
            BackgroundList.Add("Green");
            BackgroundList.Add("Purple");
            BackgroundList.Add("Pink");

            List<RandomizeGroup> listSorted = new List<RandomizeGroup>();
            int teamCount = teamList.Count;

            

            var shuffledcards = teamList.OrderBy(a => Guid.NewGuid()).ToList();
           
            int num_groups = 3;
            decimal g = Convert.ToDecimal(teamCount)/Convert.ToDecimal(num_groups);
            int totalGroups = Convert.ToInt32(Math.Ceiling(g));
            int moduloGroup = teamCount % num_groups;
            ApiService apiService = new ApiService();
            List<Group> groupIds = new List<Group>();

            for (int i = 0; i < totalGroups; i++)
            {
                var response = await apiService.AddGroup(new Group
                {
                    id = default,
                    name = "Gruppe" + (i + 1),
                    rule = 0,
                    groupSize = totalGroups,
                    participants = "name1, name2",
                    teams = default
                });
                groupIds.Add(response);

            }

            int group_num = 0;
            


            List<RandomizeGroup> randomizeSortList = new List<RandomizeGroup>();
            for (int i = 0; i < teamCount; i++)
            {               

                    randomizeSortList.Add(new RandomizeGroup { groupNr = group_num +1 , groupName = shuffledcards[i], BackColour = BackgroundList[group_num]});
                    group_num = ++group_num % totalGroups;

                
            }


            List<RandomizeGroup>  SortedListByNumberNr = randomizeSortList.OrderBy(randomizeGroup => randomizeGroup.groupNr).ToList();

            foreach (var item in SortedListByNumberNr)
            {
               Users.Add(item);
               Team team = taskTeam.Find(t => t.name == item.groupName);
               team.groupId = groupIds[item.groupNr.Value - 1 ].id;
               //team.group.name = "Gruppe"; // +  groupIds[item.groupNr.Value - 1].name
                var b = await apiService.UpdateTeam(team.id.ToString(), team);

            }
            listViewRandomTeam.ItemsSource = Users;

        }


    }
   
}