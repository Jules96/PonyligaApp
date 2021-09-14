using Ponyliga.Services;
using Ponyliga.Models;
using Ponyliga.ViewModels;
using System;
using System.Collections;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Ponyliga.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StopWatchPage : ContentPage
    {
        StopWatch stopWatch;

        public StopWatchPage()
        {
            FillTeamList();
            InitializeComponent();

            stopWatch = new StopWatch();

            // shows the correct time formatting
            BindingContext = stopWatch;
            stopWatch.Time = "00:00:00.00";

            btn_Continue.IsEnabled = false;
            btn_Stop.IsEnabled = false;
            btn_Reset.IsEnabled = false;
        }

        private void btn_LogOut_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new LogInPage());
        }

        // fills the picker with the registered teams
        public async void FillTeamList()
        {
            ApiService apiService = new ApiService();
            var taskTeam = await apiService.GetAllTeams();

            ArrayList teamList = new ArrayList();

            foreach (var team in taskTeam)
                teamList.Add(team.name);

            TeamPicker.ItemsSource = teamList;
        }

        public void TeamPicker_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            //int teamID = TeamPicker.SelectedIndex;
            string team = TeamPicker.Items[TeamPicker.SelectedIndex];
            DisplayAlert(team, "wurde als Team ausgewählt", "OK");
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

        private async void btn_TransmitResults_Clicked(object sender, EventArgs e)
        {
            var stoppedTime = stopWatch.Time;
            // convert stoppedTime into a string
            string test = stoppedTime.ToString();

            string selectedTeam = TeamPicker.Items[TeamPicker.SelectedIndex];

            if (selectedTeam != null && stoppedTime != null)
            {
                Result result = new Result();
                result.time = test;

                ApiService apiService = new ApiService();
                await apiService.AddResult(result);

            }
            else
            {
                DisplayAlert("Achtung", "Es wurde kein Team ausgewählt.", "OK");
            }

            // label to make stopped time visible
            label_getTime.Text = test;
        }

        private void btn_TimeInputPage_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new TimeInputPage());
        }
    }
}