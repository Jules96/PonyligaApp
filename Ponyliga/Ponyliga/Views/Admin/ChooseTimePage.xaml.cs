using Ponyliga.Models;
using Ponyliga.Services;
using Ponyliga.Views.Admin;
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
    public partial class ChooseTimePage : ContentPage
    {
        public List<Team> taskTable;
        public List<User> taskUser;
        public TeamResult result;
        ObservableCollection<TeamResult> MyItems = new ObservableCollection<TeamResult>();
        ObservableCollection<TeamResult> Item { get { return MyItems; } }

        ApiService apiService = new ApiService();

        bool isGamePickerPicked;
        bool isTeamPickerPicked;

        public ChooseTimePage()
        {

            InitializeComponent();
            FillTeamPicker();
            GetAllUserNameAsync();
            //GetAllUserName();

        }
        public ChooseTimePage(TeamResult teamResults)
        {

            InitializeComponent();
            FillTeamPicker();
            GetAllUserNameAsync();
            //GetAllUserName();

        }

        public async Task GetAllUserNameAsync()
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

        public async void FillTeamPicker()
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
            string team = TeamPicker.Items[TeamPicker.SelectedIndex];
            isTeamPickerPicked = true;            
            FillResultTable();
           
        }

        public void GamePicker_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            string game = GamePicker.Items[GamePicker.SelectedIndex];
            isGamePickerPicked = true;
            Item.Clear();
            FillResultTable();

        }



        public async void FillResultTable()
        {
            ApiService apiService = new ApiService();
            System.Collections.Generic.List<Models.Team> taskResultSum = await apiService.GetResultSummary();


            listViewTable.ItemsSource = MyItems;
            string teamString;
            string gameString;

            if (isTeamPickerPicked)
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
                List<TeamResult> SortedListByNumberNr = new List<TeamResult>(); 
                List<TeamResult> randomizeSortList = new List<TeamResult>();
                foreach (var resultSum in taskResultSum)
                {

                    foreach (var resultSums in resultSum.results)
                    {
                        if (resultSums.game == gameString && resultSum.name == teamString  )
                        {
                            MyItems.Clear();
                            if (String.IsNullOrEmpty(resultSums.penaltyTime))
                            {
                                TeamResult team = new TeamResult();
                                resultSums.penaltyTime = "0";
                            }
                            randomizeSortList.Add(new TeamResult { id = resultSums.id, name = resultSum.name, 
                                                                   score = resultSums.score, time = resultSums.time, 
                                                                   penaltyTime = resultSums.penaltyTime + " sek." , game=resultSums.game});
                        }
                        else if(resultSum.name == teamString &&  gameString =="")
                        {
                            MyItems.Clear();

                            if (String.IsNullOrEmpty(resultSums.penaltyTime))
                            {
                                TeamResult team = new TeamResult();
                                resultSums.penaltyTime = "0";
                            }
                            randomizeSortList.Add(new TeamResult { id = resultSums.id, name = resultSum.name, 
                                                                   score = resultSums.score, time = resultSums.time, 
                                                                   penaltyTime = resultSums.penaltyTime + " sek.", game = resultSums.game });

                        }
                        else if (resultSums.game == gameString && teamString == "")
                        {
                            MyItems.Clear();
                            if (String.IsNullOrEmpty(resultSums.penaltyTime))
                            {
                                TeamResult team = new TeamResult();
                                resultSums.penaltyTime = "0";
                            }
                            randomizeSortList.Add(new TeamResult { id = resultSums.id, name = resultSum.name,
                                                                   score = resultSums.score, time = resultSums.time,
                                                                   penaltyTime = resultSums.penaltyTime + " sek.", game = resultSums.game });

                        }
                    }
                }
                       SortedListByNumberNr = randomizeSortList.OrderBy(randomizeList => randomizeList.position).ToList();

                foreach (var item in SortedListByNumberNr)
                {
                    MyItems.Add(item);
                }
            }
        }




        private void Handle_SelectedItem(object sender, SelectedItemChangedEventArgs e)
        {

            if (e.SelectedItem != null )
            {
                var item = (TeamResult)e.SelectedItem;
                
                {
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
}