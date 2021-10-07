using Ponyliga.Views.Results;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Ponyliga.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class totalScoreTableFlyout : ContentPage
    {
        public ListView ListView;

        public totalScoreTableFlyout()
        {
            InitializeComponent();

            BindingContext = new totalScoreTableFlyoutViewModel();
            ListView = MenuItemsListView;
        }

        class totalScoreTableFlyoutViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<totalScoreTableFlyoutMenuItem> MenuItems { get; set; }
           

            public totalScoreTableFlyoutViewModel()
            {

                MenuItems = new ObservableCollection<totalScoreTableFlyoutMenuItem>(new[]
                {
                    new totalScoreTableFlyoutMenuItem { Id = 0, Title = "Flaggen", TargetType = typeof(FlaggenPageDetail)},
                    new totalScoreTableFlyoutMenuItem { Id = 1, Title = "Kartoffel",TargetType = typeof(KartoffelrennenPageDetail) },
                    new totalScoreTableFlyoutMenuItem { Id = 2, Title = "Sacklaufen",TargetType = typeof(SackrennenPageDetail) },
                    new totalScoreTableFlyoutMenuItem { Id = 3, Title = "Slalom",TargetType = typeof(SlalomPageDetail) },
                    new totalScoreTableFlyoutMenuItem { Id = 4, Title = "Steine" ,TargetType = typeof(SteinePageDetail)},
                    new totalScoreTableFlyoutMenuItem { Id = 5, Title = "Becherrennen" ,TargetType = typeof(BecherrennenPageDetail)},


                });
            }

            #region INotifyPropertyChanged Implementation
            public event PropertyChangedEventHandler PropertyChanged;
            void OnPropertyChanged([CallerMemberName] string propertyName = "")
            {
                if (PropertyChanged == null)
                    return;

                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            #endregion
        }
    }
}