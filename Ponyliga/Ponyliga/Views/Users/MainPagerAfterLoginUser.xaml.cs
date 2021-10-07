using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Ponyliga.Views.Users
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPagerAfterLoginUser : ContentPage
    {
        private string labelProperty;
        public string LabelProperty
        {
            get { return labelProperty; }
            set
            {
                labelProperty = value;
                OnPropertyChanged(nameof(LabelProperty)); // Notify that there was a change on this property
            }
        }
        public MainPagerAfterLoginUser(string username)
        {
            InitializeComponent();
            BindingContext = this;
            LabelProperty = "Herzlich Willkommen, " + username + "!"; // It will be shown at your label
        }

        public MainPagerAfterLoginUser()
        {
            InitializeComponent();

        }
        private void btn_StopWatch_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new StopWatchPage());
        }

        private void btn_Table_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new totalScoreTable());
        }
        private void btn_LogOut_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }

    }
}