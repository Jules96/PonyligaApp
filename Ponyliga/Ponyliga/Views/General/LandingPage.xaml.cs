using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ponyliga.Views.Users;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Ponyliga.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LandingPage : ContentPage
    {
        public LandingPage()
        {
            InitializeComponent();
        }

        private void btn_Table_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new totalScoreTable());
        }

        private void btn_LogIn_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new LogInPage());
        }

        private void btn_Rules_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Rules());
        }

        private void btn_GameStructure_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new GameStructure());
        }

        private void btn_QrCode_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new QRCodePage());
        }

        private void btn_Impressum_Clicked(object sender, EventArgs e)
        {

        }

        private void btn_DateSave_Clicked(object sender, EventArgs e)
        {

        }

        private void btn_Grouping_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new groupingPage());
        }
    }
}