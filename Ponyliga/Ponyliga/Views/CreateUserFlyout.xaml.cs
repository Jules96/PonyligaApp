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
    public partial class CreateUserFlyout : ContentPage
    {
        public ListView ListView;

        public CreateUserFlyout()
        {
            InitializeComponent();

            BindingContext = new CreateUserFlyoutViewModel();
            ListView = MenuItemsListView;
        }

        class CreateUserFlyoutViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<CreateUserFlyoutMenuItem> MenuItems { get; set; }

            public CreateUserFlyoutViewModel()
            {
                MenuItems = new ObservableCollection<CreateUserFlyoutMenuItem>(new[]
                {
                    new CreateUserFlyoutMenuItem { Id = 0, Title = "Page 1" },
                    new CreateUserFlyoutMenuItem { Id = 1, Title = "Page 2" },
                    new CreateUserFlyoutMenuItem { Id = 2, Title = "Page 3" },
                    new CreateUserFlyoutMenuItem { Id = 3, Title = "Page 4" },
                    new CreateUserFlyoutMenuItem { Id = 4, Title = "Page 5" },
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