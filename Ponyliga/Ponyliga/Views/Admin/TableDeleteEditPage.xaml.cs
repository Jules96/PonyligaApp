using Ponyliga.Models;
using Ponyliga.Services;
using Ponyliga.ViewModels;
using Ponyliga.Views.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Ponyliga.Views.Admin
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TableDeleteEditPage : ContentPage
    {
        TeamResult teamResult;
        StopWatch stopWatch;

        private string labelName;
        public string LabelName
        {
            get { return labelName; }
            set
            {
                labelName = value;
                OnPropertyChanged(nameof(LabelName)); // Notify that there was a change on this property
            }
        }

        private string labelGame;
        public string LabelGame
        {
            get { return labelGame; }
            set
            {
                labelGame = value;
                OnPropertyChanged(nameof(LabelGame));
            }
        }
        public TableDeleteEditPage(Models.TeamResult teamResults)
        {
            teamResult = teamResults;
            BindingContext = this;
            LabelName = teamResults.name;
            LabelGame = teamResults.game;
            InitializeComponent();
        }
       

        private void edit_Clicked(object sender, EventArgs e)
        {

            var stoppedTime = timeInputHour.Text + ":" + timeInputMin.Text + ":" + timeInputSec.Text + "." + timeInputMsec.Text;
            var penTime = penaltyTime.Text;

            stopWatch = new StopWatch();

            if (String.IsNullOrEmpty(timeInputHour.Text) | String.IsNullOrEmpty(timeInputMin.Text) | String.IsNullOrEmpty(timeInputSec.Text) | String.IsNullOrEmpty(timeInputMsec.Text))
            {
                DisplayAlert("Achtung", "Es sind nicht alle Zeitfelder ausgefüllt!", "OK");
            }
            else
            {
                // with penalty time
                if (penaltyTime.Text != null)
                {
                    double pentime = Convert.ToDouble(penTime);

                   

                    if ( stoppedTime != null)
                    {                        
                        Result result = new Result();
                        result.gameDate = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss");
                        result.id = teamResult.id;
                        result.game = teamResult.game;
                        result.time = stopWatch.AddPenaltyTime(stoppedTime, pentime).ToString();
                        result.teamId = teamResult.teamId;
                        result.penaltyTime = penTime.ToString();


                        ApiService apiService = new ApiService();
                        apiService.AddResult(result);

                        DisplayAlert("Übermittelt!", "Die Zeit für " + teamResult.name + " wurde hinzugefügt.", "OK");

                        Navigation.PushAsync(new StopWatchPage());
                    }
                    else
                    {
                        DisplayAlert("Fehler", "Mit * markierte Felder wurden nicht oder fehlerhaft ausgefüllt.", "OK");
                    }
                }
                else
                {
                    string convertedTime = stoppedTime.ToString();

                    // without penalty time
                    if (stoppedTime != null)
                    {
                        //string selectedTeam = TeamPicker.Items[TeamPicker.SelectedIndex];
                        //var teams = taskTeam;
                        //int teamId = teams.Find(t => t.name == selectedTeam).id;
                        //string selectedGame = GamePicker.Items[GamePicker.SelectedIndex];

                        Result result = new Result();
                        result.gameDate = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss");
                        result.id = teamResult.id;
                        result.game = teamResult.game;
                        result.time = convertedTime;
                        result.teamId = teamResult.teamId;
                        result.penaltyTime = 0.ToString();

                        ApiService apiService = new ApiService();
                        apiService.AddResult(result);

                        DisplayAlert("Übermittelt!", "Die Zeit für " + teamResult.name + " wurde hinzugefügt.", "OK");

                        
                    }
                    else
                    {
                        DisplayAlert("Fehler", "Mit * markierte Felder wurden nicht oder fehlerhaft ausgefüllt.", "OK");
                    }
                }
            }
        }
        private void delelte_Clicked(object sender, EventArgs e)
        {
            ApiService apiService = new ApiService();
            //apiService.DeleteResult(id);
            
        }

        public class MaxHourAmountEntryBehavior : Behavior<Entry>
        {
            protected Action<Entry, string> AdditionalCheck;

            public int MaximumAmount { get; set; } = 23;

            public MaxHourAmountEntryBehavior()
            {
                // check if the new value of the entry is greater than the requirement
                AdditionalCheck = (args, oldValue) =>
                {
                    args.Text = Convert.ToInt32(args.Text) > MaximumAmount ? oldValue : args.Text.ToString();
                };
            }

            protected override void OnAttachedTo(Entry bindable)
            {
                bindable.TextChanged += NumberValidation;

                base.OnAttachedTo(bindable);
            }

            protected override void OnDetachingFrom(Entry bindable)
            {
                base.OnDetachingFrom(bindable);
            }

            void NumberValidation(object sender, TextChangedEventArgs args)
            {
                string result = "";
                if (string.IsNullOrWhiteSpace(args.NewTextValue))
                {
                    ((Entry)sender).Text = result.ToString();
                }
                else
                    AdditionalCheck?.Invoke(((Entry)sender), args.OldTextValue);
            }
        }

        // Check for minutes
        public class MaxMinuteAmountEntryBehavior : Behavior<Entry>
        {
            protected Action<Entry, string> AdditionalCheck;

            public int MaximumAmount { get; set; } = 59;

            public MaxMinuteAmountEntryBehavior()
            {
                // check if the new value of the entry is greater than the requirement
                AdditionalCheck = (args, oldValue) =>
                {
                    args.Text = Convert.ToInt32(args.Text) > MaximumAmount ? oldValue : args.Text.ToString();
                };
            }

            protected override void OnAttachedTo(Entry bindable)
            {
                bindable.TextChanged += NumberValidation;

                base.OnAttachedTo(bindable);
            }

            protected override void OnDetachingFrom(Entry bindable)
            {
                base.OnDetachingFrom(bindable);
            }

            void NumberValidation(object sender, TextChangedEventArgs args)
            {
                string result = "";
                if (string.IsNullOrWhiteSpace(args.NewTextValue))
                {
                    ((Entry)sender).Text = result.ToString();
                }
                else
                    AdditionalCheck?.Invoke(((Entry)sender), args.OldTextValue);
            }
        }

        // Check for seconds
        public class MaxSecAmountEntryBehavior : Behavior<Entry>
        {
            protected Action<Entry, string> AdditionalCheck;

            public int MaximumAmount { get; set; } = 59;

            public MaxSecAmountEntryBehavior()
            {
                // check if the new value of the entry is greater than the requirement
                AdditionalCheck = (args, oldValue) =>
                {
                    args.Text = Convert.ToInt32(args.Text) > MaximumAmount ? oldValue : args.Text.ToString();
                };
            }

            protected override void OnAttachedTo(Entry bindable)
            {
                bindable.TextChanged += NumberValidation;

                base.OnAttachedTo(bindable);
            }

            protected override void OnDetachingFrom(Entry bindable)
            {
                base.OnDetachingFrom(bindable);
            }

            void NumberValidation(object sender, TextChangedEventArgs args)
            {
                string result = "";
                if (string.IsNullOrWhiteSpace(args.NewTextValue))
                {
                    ((Entry)sender).Text = result.ToString();
                }
                else
                    AdditionalCheck?.Invoke(((Entry)sender), args.OldTextValue);
            }
        }

        // Check for milliseconds cut to two decimal places
        public class MaxMsecAmountEntryBehavior : Behavior<Entry>
        {
            protected Action<Entry, string> AdditionalCheck;

            public int MaximumAmount { get; set; } = 999;

            public MaxMsecAmountEntryBehavior()
            {
                // check if the new value of the entry is greater than the requirement
                AdditionalCheck = (args, oldValue) =>
                {
                    args.Text = Convert.ToInt32(args.Text) > MaximumAmount ? oldValue : args.Text.ToString();
                };
            }

            protected override void OnAttachedTo(Entry bindable)
            {
                bindable.TextChanged += NumberValidation;

                base.OnAttachedTo(bindable);
            }

            protected override void OnDetachingFrom(Entry bindable)
            {
                base.OnDetachingFrom(bindable);
            }

            void NumberValidation(object sender, TextChangedEventArgs args)
            {
                string result = "";
                if (string.IsNullOrWhiteSpace(args.NewTextValue))
                {
                    ((Entry)sender).Text = result.ToString();
                }
                else
                    AdditionalCheck?.Invoke(((Entry)sender), args.OldTextValue);
            }
        }

        
    }
}
    