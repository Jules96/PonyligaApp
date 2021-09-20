using Ponyliga.Services;
using Ponyliga.Models;
using Ponyliga.ViewModels;
using System;
using System.Collections;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Collections.Generic;

namespace Ponyliga.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StopWatchPage : ContentPage
    {
        StopWatch stopWatch;

        public List<Team> taskTeam;

        public StopWatchPage()
        {
            InitializeComponent();

            FillTeamList();

            stopWatch = new StopWatch();

            BindingContext = stopWatch;
            // shows the correct time formatting at the beginning
            stopWatch.Time = "00:00:00.00";

            btn_Continue.IsEnabled = false;
            btn_Stop.IsEnabled = false;
            btn_Reset.IsEnabled = false;
        }

        private void btn_LogOut_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new LogInPage());
        }

        // API Request lagged
        // fills the picker with the registered teams
        public async void FillTeamList()
        {
            ApiService apiService = new ApiService();
            taskTeam = await apiService.GetAllTeams();

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
            //DisplayAlert(team, "wurde als Team ausgewählt", "OK");
        }

        public void GamePicker_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            string game = GamePicker.Items[GamePicker.SelectedIndex];
            //DisplayAlert(game, "wurde als Spiel ausgewählt", "OK");
        }

        private void btn_Start_Clicked(object sender, EventArgs e)
        {
            stopWatch.StartStopWatch();

            BindingContext = stopWatch;

            btn_Start.IsEnabled = false;
            btn_Stop.IsEnabled = true;
            btn_Continue.IsEnabled = false;
            btn_Reset.IsEnabled = true;
        }

        private void btn_Stop_Clicked(object sender, EventArgs e)
        {
            stopWatch.StopStopWatch();

            BindingContext = stopWatch;

            btn_Start.IsEnabled = false;
            btn_Continue.IsEnabled = true;
            btn_Stop.IsEnabled = false;
            btn_Reset.IsEnabled = true;
        }

        private void btn_Continue_Clicked(object sender, EventArgs e)
        {
            stopWatch.ContinueStopWatch();

            btn_Start.IsEnabled = false;
            btn_Continue.IsEnabled = false;
            btn_Stop.IsEnabled = true;
            btn_Reset.IsEnabled = true;
        }

        private void btn_Reset_Clicked(object sender, EventArgs e)
        {
            stopWatch.ResetStopWatch();

            btn_Start.IsEnabled = true;
            btn_Continue.IsEnabled = false;
            btn_Stop.IsEnabled = false;
            btn_Reset.IsEnabled = false;
        }

        private void btn_TransmitResults_Clicked(object sender, EventArgs e)
        {
            var stoppedTime = stopWatch.Time;
            string convertedTime = stoppedTime.ToString();
            
            if (TeamPicker.SelectedIndex > -1 && GamePicker.SelectedIndex > -1 && stoppedTime != null)
            {
                string selectedTeam = TeamPicker.Items[TeamPicker.SelectedIndex];
                var teams = taskTeam;
                int teamId = teams.Find(t => t.name == selectedTeam).id;
                string selectedGame = GamePicker.Items[GamePicker.SelectedIndex];

                Result result = new Result();
                result.gameDate = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss");
                result.id = default;
                result.game = selectedGame;
                result.time = convertedTime;
                result.teamId = teamId;

                ApiService apiService = new ApiService();
                apiService.AddResult(result);

                DisplayAlert("Übermittelt!", "Die Zeit für "+ selectedTeam + " wurde hinzugefügt.", "OK");

                Navigation.PushAsync(new StopWatchPage());
            }
            else
            {
                DisplayAlert("Fehler", "Mit * markierte Felder wurden nicht oder fehlerhaft ausgefüllt.", "OK");
            }

            // label to make stopped time visible
            // label_getTime.Text = convertetTime;
        }

        private void btn_TimeInputPage_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new TimeInputPage());
        }
    }
}