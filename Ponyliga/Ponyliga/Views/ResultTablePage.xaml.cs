﻿using Ponyliga.ViewModels;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Ponyliga.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ResultTablePage : ContentPage
    {
        
        ObservableCollection<Result> MyItems = new ObservableCollection<Result>();
        ObservableCollection<Result> Item { get { return MyItems; } }



        public ResultTablePage()
        {
            InitializeComponent();

            listViewm.ItemsSource = MyItems;


            MyItems.Add(new Result() { Club="Herzlake II", Placement="1", Score="15(5;5;5;)"});
            MyItems.Add(new Result() { Club = "Herzlake I", Placement = "2", Score = "12(4;4;4;)" });
            MyItems.Add(new Result() { Club = "Haselünne", Placement = "3", Score = "9(3;3;3;)" });
            MyItems.Add(new Result() { Club = "Meppen", Placement = "4", Score = "6(2;2;2;)" });



        }

        async void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
                return;

            await DisplayAlert("Item Tapped", "An item was tapped.", "OK");

            //Deselect Item
            ((ListView)sender).SelectedItem = null;
        }
    }
}
