using Ponyliga.Models;
using Ponyliga.Services;
using System.Collections.ObjectModel;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Ponyliga.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class totalScoreTableDetail : ContentPage
    {
        ObservableCollection<TeamResult> MyItems = new ObservableCollection<TeamResult>();
        ObservableCollection<TeamResult> Item { get { return MyItems; } }

        public totalScoreTableDetail()
        {
            InitializeComponent();
            FillResultTable();

            listViewm.ItemsSource = MyItems;
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

      

        private void btn_aktualisieren_Clicked(object sender, System.EventArgs e)
        {

        }
    }
}
