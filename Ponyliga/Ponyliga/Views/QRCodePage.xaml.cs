using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Ponyliga.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    
    public partial class QRCodePage : ContentPage
    {
        public string Source { get; set; }

        public QRCodePage()
        {
            InitializeComponent();
        }

    }
}