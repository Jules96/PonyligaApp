using Ponyliga.Models;
using Ponyliga.Services;
using Ponyliga.ViewModels;
using System;
using System.Collections;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Ponyliga.Views.Users
{
    [XamlCompilation(XamlCompilationOptions.Compile)]

    // page for manual time input
    public partial class TimeInputPage : ContentPage
    {
        // only for using the AddPenaltyTime method
        StopWatch stopWatch;

        public List<Team> taskTeam;

        public TimeInputPage()
        {
            InitializeComponent();

            FillTeamList();
        }

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

        private void btn_TransmitResults_Clicked(object sender, EventArgs e)
        {
            // saves time in a label
            //label_manual_result.Text = timeInputHour.Text + ":" + timeInputMin.Text + ":" + timeInputSec.Text + "." + timeInputMsec.Text;

            var stoppedTime = timeInputHour.Text + ":" + timeInputMin.Text + ":" + timeInputSec.Text + "." + timeInputMsec.Text;
            var penTime = penaltyTime.Text;
            
            stopWatch = new StopWatch();

            if(String.IsNullOrEmpty(timeInputHour.Text) | String.IsNullOrEmpty(timeInputMin.Text) | String.IsNullOrEmpty(timeInputSec.Text) | String.IsNullOrEmpty(timeInputMsec.Text))
            {
                DisplayAlert("Achtung", "Es sind nicht alle Zeitfelder ausgefüllt!", "OK");
            }
            else
            {
                // with penalty time
                if (penaltyTime.Text != null)
                {
                    double pentime = Convert.ToDouble(penTime);

                    // shows the calculated Time incl. penalty
                    timeIncPenalty.Text = stopWatch.AddPenaltyTime(stoppedTime, pentime).ToString();

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
                        result.time = stopWatch.AddPenaltyTime(stoppedTime, pentime).ToString();
                        result.teamId = teamId;
                        result.penaltyTime = penTime.ToString();


                        ApiService apiService = new ApiService();
                        apiService.AddResult(result);

                        DisplayAlert("Übermittelt!", "Die Zeit für " + selectedTeam + " wurde hinzugefügt.", "OK");

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
                        result.penaltyTime = 0.ToString();

                        ApiService apiService = new ApiService();
                        apiService.AddResult(result);

                        DisplayAlert("Übermittelt!", "Die Zeit für " + selectedTeam + " wurde hinzugefügt.", "OK");

                        Navigation.PushAsync(new StopWatchPage());
                    }
                    else
                    {
                        DisplayAlert("Fehler", "Mit * markierte Felder wurden nicht oder fehlerhaft ausgefüllt.", "OK");
                    }
                }
            }
        }
    }

    // limit the keyboard input in range to the time value


    // Check for hours
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

    // behavior with color wrong entries


    //public class CustomBehavior : Behavior<Entry>
    //{
    //    protected override void OnAttachedTo(Entry bindable)
    //    {
    //        bindable.TextChanged += NumberValidation;
    //        base.OnAttachedTo(bindable);
    //    }

    //    protected override void OnDetachingFrom(Entry bindable)
    //    {
    //        base.OnDetachingFrom(bindable);
    //    }

    //    /// <summary>
    //    /// If the text is not numeric, then the text color is red..
    //    /// else text color is green
    //    /// </summary>
    //    /// <param name="sender"></param>
    //    /// <param name="args"></param>

    //    void NumberValidation(object sender, TextChangedEventArgs args)
    //    {

    //        int result;
    //        bool isValid = int.TryParse(args.NewTextValue, out result);
    //        ((Entry)sender).TextColor = isValid ? Color.Green : Color.Red;
    //    }
    //}





    // behavior with a mask for getting the right format while editing


    //public class CustomBehavior : Behavior<Entry>
    //{
    //    private string mask = "";
    //    public string Mask
    //    {
    //        get => mask;
    //        set
    //        {
    //            mask = value;
    //            SetPositions();
    //        }
    //    }

    //    protected override void OnAttachedTo(Entry entry)
    //    {
    //        entry.TextChanged += NumberValidation;
    //        base.OnAttachedTo(entry);
    //    }

    //    protected override void OnDetachingFrom(Entry entry)
    //    {
    //        entry.TextChanged -= NumberValidation;
    //        base.OnDetachingFrom(entry);
    //    }

    //    IDictionary<int, char> positions;

    //    void SetPositions()
    //    {
    //        if (string.IsNullOrEmpty(Mask))
    //        {
    //            positions = null;
    //            return;
    //        }

    //        var list = new Dictionary<int, char>();
    //        for (var i = 0; i < Mask.Length; i++)
    //            if (Mask[i] != 'X')
    //                list.Add(i, Mask[i]);

    //        positions = list;
    //    }

    //    void NumberValidation(object sender, TextChangedEventArgs args)
    //    {
    //        var entry = sender as Entry;

    //        var text = entry.Text;

    //        if (string.IsNullOrWhiteSpace(text) || positions == null)
    //            return;

    //        if (text.Length > mask.Length)
    //        {
    //            entry.Text = text.Remove(text.Length - 1);
    //            return;
    //        }

    //        foreach (var position in positions)
    //            if (text.Length >= position.Key + 1)
    //            {
    //                var value = position.Value.ToString();
    //                if (text.Substring(position.Key, 1) != value)
    //                    text = text.Insert(position.Key, value);
    //            }

    //        if (entry.Text != text)
    //            entry.Text = text;
    //    }
    //}






    // behavior incl. numeric check


    //public class PlainNumericEntryBehavior : Behavior<Entry>
    //{
    //    protected override void OnAttachedTo(Entry bindable)
    //    {
    //        base.OnAttachedTo(bindable);
    //        bindable.TextChanged += TextChanged_Handler;
    //    }

    //    protected override void OnDetachingFrom(Entry bindable)
    //    {
    //        base.OnDetachingFrom(bindable);
    //    }

    //    protected Action<Entry, string> AdditionalCheck;

    //    protected virtual void TextChanged_Handler(object sender, TextChangedEventArgs args)
    //    {
    //        if(string.IsNullOrEmpty(args.NewTextValue))
    //        {
    //            ((Entry)sender).Text = 0.ToString();
    //            return;
    //        }

    //        double _;
    //        if (!double.TryParse(args.NewTextValue, out _))
    //            ((Entry)sender).Text = args.OldTextValue;
    //        else
    //            AdditionalCheck?.Invoke(((Entry)sender), args.OldTextValue);
    //    }
    //}


    //public class MaximumAmountEntryBehavior : PlainNumericEntryBehavior
    //{
    //    public int MaximumAmount { get; set; } = 999;

    //    public MaximumAmountEntryBehavior()
    //    {
    //        AdditionalCheck = (args, ot) =>
    //        {
    //            args.Text = Convert.ToInt32(args.Text) > MaximumAmount ? ot : args.Text.ToString();
    //        };
    //    }
    //    protected override void OnAttachedTo(BindableObject bindable)
    //    {
    //        base.OnAttachedTo(bindable);
    //    }

    //    protected override void OnDetachingFrom(BindableObject bindable)
    //    {
    //        base.OnDetachingFrom(bindable);
    //    }

    //    protected override void TextChanged_Handler(object sender, TextChangedEventArgs args)
    //    {
    //        base.TextChanged_Handler(sender, args);
    //    }
    //}

}