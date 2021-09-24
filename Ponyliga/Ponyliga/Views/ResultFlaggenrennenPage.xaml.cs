﻿using Ponyliga.Models;
using Ponyliga.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace Ponyliga.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ResultFlaggenrennenPage : ContentPage
    {

        ObservableCollection<TeamResult> MyItems = new ObservableCollection<TeamResult>();
        ObservableCollection<TeamResult> Item { get { return MyItems; } }



        public ResultFlaggenrennenPage()
        {
            InitializeComponent();
            FillResultTable();



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


            listViewFlaggen.ItemsSource = MyItems;


            if (taskResultSum != null)
            {

                List<TeamResult> randomizeSortList = new List<TeamResult>();
                foreach (var resultSum in taskResultSum)
                {

                    foreach (var resultSums in resultSum.results)
                    {
                        if (resultSums.game == "Flaggenrennen")
                        {
                            //int penaltyTimeInt = Int16.Parse(resultSums.penaltyTime);
                            if (String.IsNullOrEmpty(resultSums.penaltyTime))
                            {
                                TeamResult team = new TeamResult();
                                resultSums.penaltyTime = "0";
                            }
                            randomizeSortList.Add(new TeamResult { position = resultSums.position.ToString(), name = resultSum.name, score = resultSums.score, time = resultSums.time, penaltyTime = resultSums.penaltyTime + " sek." });
                        }
                    }
                }
                List<TeamResult> SortedListByNumberNr = randomizeSortList.OrderBy(randomizeList => randomizeList.position).ToList();

                foreach (var item in SortedListByNumberNr)
                {
                    MyItems.Add(item);


                }

            }
        }

        private void btn_Kartoffelrennen_Clicked(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new ResultKartoffelrennenPage());
        }

        private void btn_Sacklaufen_Clicked(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new ResultSacklaufenPage());
        }

        private void btn_Steine_Clicked(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new ResultSteinePage());
        }

        private void btn_Becherrennen_Clicked(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new ResultBecherrennenPage());
        }

        private void btn_Slalom_Clicked(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new ResultSlalomPage());
        }

        private void btn_sumTable_Clicked(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new ResultTablePage());
        }

        private void btn_aktualisieren_Clicked(object sender, System.EventArgs e)
        {

        }

    }
}