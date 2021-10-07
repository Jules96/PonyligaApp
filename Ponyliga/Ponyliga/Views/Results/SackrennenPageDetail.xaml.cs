using Ponyliga.Models;
using Ponyliga.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Ponyliga.Views.Results
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SackrennenPageDetail : ContentPage
    {

        ObservableCollection<TeamResult> SackrennenItems = new ObservableCollection<TeamResult>();
        ObservableCollection<TeamResult> Item { get { return SackrennenItems; } }

        public SackrennenPageDetail()
        {
            InitializeComponent();
            FillResultTable();
        }

        public async void FillResultTable()
        {

            ApiService apiService = new ApiService();
            List<Team> taskResultSum = await apiService.GetResultSummary();


            listViewSacklaufen.ItemsSource = SackrennenItems;


            if (taskResultSum != null)
            {

                List<TeamResult> randomizeSortList = new List<TeamResult>();
                foreach (var resultSum in taskResultSum)
                {

                    foreach (var resultSums in resultSum.results)
                    {
                        if (resultSums.game == "Sacklaufen")
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
                    SackrennenItems.Add(item);


                }
            }
        }

        private void btn_aktualisieren_Clicked(object sender, EventArgs e)
        {

        }
    }
}