using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Ponyliga.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]

    // page for manual time input
    public partial class TimeInputPage : ContentPage
    {
        public TimeInputPage()
        {
            InitializeComponent();
        }

        private void btn_AcceptResult_Clicked(object sender, EventArgs e)
        {
            // saves time in a label
            label_manual_result.Text = timeInput1.Text + " : " + timeInput2.Text + " : " + timeInput3.Text + " ." + timeInput4.Text;


            // label_manuel_result.Text = TEST_entry_behavior.Text;

            // DBConnection
        }
    }

    // <-- now it takes the right range - test successful -->

    // limit the keyboard input in range to the time value


    // Check for hours
    public class MaxHourAmountEntryBehavior : Behavior<Entry>
    {
        protected Action<Entry, string> AdditionalCheck;

        public int MaximumAmount { get; set; } = 24;

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

    // Check for milliseconds
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