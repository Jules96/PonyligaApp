﻿using Ponyliga.Models;
using Ponyliga.Services;
using System.Collections.ObjectModel;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Ponyliga.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ResultTablePage : ContentPage
    {
        
        ObservableCollection<TeamResult> MyItems = new ObservableCollection<TeamResult>();
        ObservableCollection<TeamResult> Item { get { return MyItems; } }



        public ResultTablePage()
        {
            InitializeComponent();
            FillResultTable();
            
            listViewm.ItemsSource = MyItems;


            //MyItems.Add(new Result() { Club="Herzlake II", Placement="1", Score="15(5;5;5;)"});
            //MyItems.Add(new Result() { Club = "Herzlake I", Placement = "2", Score = "12(4;4;4;)" });
            //MyItems.Add(new Result() { Club = "Haselünne", Placement = "3", Score = "9(3;3;3;)" });
           // MyItems.Add(new Result() { Club = "Meppen", Placement = "4", Score = "6(2;2;2;)" });


        }

        async void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
                return;

            await DisplayAlert("Item Tapped", "An item was tapped.", "OK");

            //Deselect Item
            ((ListView)sender).SelectedItem = null;
        }

        
        public async void FillResultTable()
        {
            
            ApiService apiService = new ApiService();
            System.Collections.Generic.List<Models.Team> taskResultSum = await apiService.GetResultSummary();

           
            listViewm.ItemsSource = MyItems;

            if (taskResultSum != null)
            {

                foreach (var resultSum in taskResultSum)
                {
                    MyItems.Add(new TeamResult { place = resultSum.place, name = resultSum.name, score = resultSum.totalScore });
                    foreach (var resultSums in resultSum.results)
                    {

                    }

                }
            }
        }

        private void btn_Kartoffelrennen_Clicked(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new ResultKartoffelrennenPage());
        }

        private void btn_Flaggenrennen_Clicked(object sender, System.EventArgs e)
        {
            //Navigation.PushAsync(new UserPage());
        }

        private void btn_Sacklaufen_Clicked(object sender, System.EventArgs e)
        {
            //Navigation.PushAsync(new UserPage());
        }

        private void btn_Steine_Clicked(object sender, System.EventArgs e)
        {
            //Navigation.PushAsync(new UserPage());
        }

        private void btn_Becherrennen_Clicked(object sender, System.EventArgs e)
        {
            //Navigation.PushAsync(new UserPage());
        }

        private void btn_Slalom_Clicked(object sender, System.EventArgs e)
        {
            //Navigation.PushAsync(new UserPage());
        }

        private void btn_sumTable_Clicked(object sender, System.EventArgs e)
        {
            //Navigation.PushAsync(new UserPage());
        }

        private void btn_aktualisieren_Clicked(object sender, System.EventArgs e)
        {

        }
    }
}
