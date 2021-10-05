using Ponyliga.Models;
using Ponyliga.Services;
using Ponyliga.ViewModels;
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
	public partial class TableDeleteEdete : ContentPage
	{
        public List<Team> taskTable;
        public List<User> taskUser;
        public TeamResult result;
        ObservableCollection<TeamResult> MyItems = new ObservableCollection<TeamResult>();
        ObservableCollection<TeamResult> Item { get { return MyItems; } }

        ApiService apiService = new ApiService();

        bool isGamePickerPicked;
        bool isTeamPickerPicked;
        public TableDeleteEdete (TeamResult teamResults)
		{
            
            InitializeComponent ();
            FillTeamList();
            GetAllUserNameAsync();
            //GetAllUserName();

        }

        public async Task  GetAllUserNameAsync()
        {
            taskTable = await apiService.GetResultSummary();                
                      
           
            if (taskTable != null)
            {
                foreach (var table in taskTable)
                {                    
                    if (table.game == GamePicker.SelectedItem.ToString() && table.name == TeamPicker.SelectedItem.ToString())
                    {
                        
                        foreach (var tables in table.results)
                        {
                            result = new TeamResult() { id = tables.id, penaltyTime = tables.penaltyTime, score = tables.score, time = tables.time, gameDate = tables.gameDate };
                           
                        }

                    }

                }
            }

        }

        public async void FillTeamList()
        {
            ApiService apiService = new ApiService();
            var taskTeam = await apiService.GetAllTeams();

            ArrayList teamList = new ArrayList();

            foreach (var team in taskTeam)
            {
                teamList.Add(team.name);
            }

            TeamPicker.ItemsSource = teamList;
        }


        public void TeamPicker_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            //int teamID = TeamPicker.SelectedIndex;
            
            string team = TeamPicker.Items[TeamPicker.SelectedIndex];
            
            isTeamPickerPicked = true;
            //Item.Clear();
            FillResultTable();
            //DisplayAlert(team, "wurde als Team ausgewählt", "OK");
        }

        public void GamePicker_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            string game = GamePicker.Items[GamePicker.SelectedIndex];
            isGamePickerPicked = true;
            Item.Clear();
            FillResultTable();

            //DisplayAlert(game, "wurde als Spiel ausgewählt", "OK");
        }

        public void hh()
        {

            if (GamePicker.SelectedIndex != -1 && TeamPicker.SelectedIndex != -1)
            {
                string loginName = TeamPicker.Items[TeamPicker.SelectedIndex];
                User listUser = taskUser.Find(u => u.loginName == loginName);
                StopWatch stopWatch = new StopWatch();

                if (TeamPicker.SelectedIndex != -1 && GamePicker.SelectedIndex != -1 )
                {

                    Result teamresult = new Result();
                    teamresult.id = listUser.id;
                    teamresult.gameDate = result.gameDate;
                    teamresult.game = GamePicker.SelectedItem.ToString();
                    teamresult.time = result.time;
                    teamresult.penaltyTime = result.penaltyTime;
                    teamresult.score = result.score;
                    

                    ApiService apiService = new ApiService();
                    apiService.UpdateResult(listUser.id.ToString(), teamresult);

                    Navigation.PushAsync(new MainPageAfterLogin());
                }
                else
                {
                    DisplayAlert("Fehler", "Es wurden nicht alle Felder ausgefüllt!", "OK");
                }
            }
        }

        public async void FillResultTable()
        {
                        ApiService apiService = new ApiService();
            System.Collections.Generic.List<Models.Team> taskResultSum = await apiService.GetResultSummary();


            listViewTable.ItemsSource = MyItems;
            string teamString;
            string gameString;
            
            if(isTeamPickerPicked)
            {
                teamString = TeamPicker.SelectedItem.ToString();
            }
            else
            {
                teamString = "";
            }

            if (isGamePickerPicked)
            {
                gameString = GamePicker.SelectedItem.ToString();
            }
            else
            {
                gameString = "";
            }


            if (taskResultSum != null)
            {

                List<TeamResult> randomizeSortList = new List<TeamResult>();
                foreach (var resultSum in taskResultSum)
                {

                    foreach (var resultSums in resultSum.results)
                    {
                        if (resultSums.game == gameString || resultSum.name == teamString)
                        {
                            //int penaltyTimeInt = Int16.Parse(resultSums.penaltyTime);
                            if (String.IsNullOrEmpty(resultSums.penaltyTime))
                            {
                                TeamResult team = new TeamResult();
                                resultSums.penaltyTime = "0";
                            }
                            randomizeSortList.Add(new TeamResult { id = resultSums.id, name = resultSum.name, score = resultSums.score, time = resultSums.time, penaltyTime = resultSums.penaltyTime + " sek." });
                        }
                    }
                }
                List<TeamResult> SortedListByNumberNr = randomizeSortList.OrderBy(randomizeList => randomizeList.position).ToList();

                foreach (var item in SortedListByNumberNr)
                {
                    MyItems.Add(item);


                }
            }
        }

  
    

        private void Handle_SelectedItem(object sender, SelectedItemChangedEventArgs e)
        {
            if(e.SelectedItem != null)
            {
                var item = (TeamResult)e.SelectedItem;
                DisplayAlert("ItemSelected", item.name, "Ok");

                
                TeamResult teamResults = new TeamResult();
                teamResults.time = item.time;
                teamResults.penaltyTime = item.penaltyTime;
                teamResults.gameDate = item.gameDate;
                teamResults.game = item.game;
                teamResults.name = item.name;
                teamResults.id = item.id;
                teamResults.teamId = item.teamId;

                Navigation.PushAsync(new TableDeleteEditPage(teamResults));
                    
            }
            
      

        }
       




}
}