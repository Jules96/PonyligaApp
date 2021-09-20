using Ponyliga.Models;
using Ponyliga.Services;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Ponyliga.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CreateGroup : ContentPage
    {
        ObservableCollection<RandomizeGroup> Users = new ObservableCollection<RandomizeGroup>();
        ObservableCollection<RandomizeGroup> User { get { return Users; } }
        public List<String> BackgroundList = new List<String>();
        public CreateGroup()
        {
            InitializeComponent();
            this.BindingContext = this;
            FillBackgroundList();

        }
        private void btn_Randomize_Clicked(object sender, EventArgs e)
        {

            /*if(groupSize != null)
            {
                DisplayAlert("Fehler!", "Das Feld Gruppengröße ist leer", "ok");
                
            }
            else
            {
                GetGroupListAsync();
            }*/
            GetGroupListAsync();
        }


        public async Task GetGroupListAsync()
        {

            ApiService apiService = new ApiService();
            var taskTeam = await apiService.GetAllTeams();

            List<string> teamList = new List<string>();

            //List<string> teamList = new List<string>();

            foreach (var team in taskTeam)
                teamList.Add(team.name);

            randomizeList(teamList);



        }

        public void randomizeList(List<string> teamList)
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
           
            int num_groups = int.Parse(groupSize.Text);

            int group_num = 0;

            

            for (int i = 0; i < teamCount; i++)
            {
                Users.Add(new RandomizeGroup { groupNr = group_num, groupName = shuffledcards[i], Bande= "r", BackColour = BackgroundList [i]});
                group_num = ++group_num % num_groups;
            }
            ArrayList arrayList = new ArrayList(listSorted);
            listViewRandomTeam.ItemsSource = Users;


            
        }

        async void Handle_ItemiTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
                return;

            await DisplayAlert("", "An item was tapped.", "OK");

            //Deselect Item
            ((ListView)sender).SelectedItem = null;
        }

        public void FillBackgroundList()
        {
           List<String> BackgroundList = new List<String>();

            BackgroundList.Add("Red");
            BackgroundList.Add("Blue");
            BackgroundList.Add("Green");
            BackgroundList.Add("Purple");
            BackgroundList.Add("Pink");
        }
    }
}