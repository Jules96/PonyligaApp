using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Ponyliga.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPageAfterLogin : ContentPage
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
        public MainPageAfterLogin(string username)
        {
            InitializeComponent();
            BindingContext = this;
            LabelProperty = "Herzlich Willkommen " + username + "!" ; // It will be shown at your label
            
            

        }

    public MainPageAfterLogin()
        {
            InitializeComponent();
            
        }

        //Label for Username(Welcome, * Username*);



        private void btn_LogOut_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }

        private void btn_User_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new UserPage());
        }

        private void btn_EditTeams_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new TeamsPage());
        }

        private void btn_StopWatch_Clicked(object sender, EventArgs e)
        {
          Navigation.PushAsync(new StopWatchPage());
        }

        private void btn_Table_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ResultTablePage());
        }

        private void btn_Group_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new CreateGroup());
        }

        private void btn_EditTable_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ChooseTimePage());
        }
    }
}