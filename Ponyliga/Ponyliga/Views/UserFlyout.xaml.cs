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
    public partial class UserFlyout : ContentPage
    {
        public ListView ListView;

        public UserFlyout()
        {
            InitializeComponent();

            BindingContext = new UserFlyoutViewModel();
            ListView = MenuItemsListView;
        }

        class UserFlyoutViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<UserFlyoutMenuItem> MenuItems { get; set; }

            public UserFlyoutViewModel()
            {
                MenuItems = new ObservableCollection<UserFlyoutMenuItem>(new[]
                {
                    new UserFlyoutMenuItem { Id = 0, Title = "Page 1" },
                    new UserFlyoutMenuItem { Id = 1, Title = "Page 2" },
                    new UserFlyoutMenuItem { Id = 2, Title = "Page 3" },
                    new UserFlyoutMenuItem { Id = 3, Title = "Page 4" },
                    new UserFlyoutMenuItem { Id = 4, Title = "Page 5" },
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