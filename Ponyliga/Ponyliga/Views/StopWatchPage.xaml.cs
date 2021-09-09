using Newtonsoft.Json;
using Ponyliga.Models;
using Ponyliga.Services;
using Ponyliga.ViewModels;
using System;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Ponyliga.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StopWatchPage : ContentPage
    {
        StopWatch stopWatch;

        ObservableCollection<Team> Teams = new ObservableCollection<Team>();
        ObservableCollection<Team> Team { get { return Teams; } }

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

        // wahl des Teams get all Teams

        public async void FillTeamList()
        {
            ApiService apiService = new ApiService();
            var taskTeam = await apiService.GetAllTeams();

            TeamPicker.ItemsSource = Teams;
      //      var response = JsonConvert.DeserializeObject<Team>(taskTeam);

            foreach (var team in taskTeam)
                Teams.Add(new Team() { name = team.name });
                //TeamPicker.ItemsSource.Add(new Team() { name = team.firstName });
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

        private void btn_ManuelResult_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new TimeInputPage());
        }
    }
}