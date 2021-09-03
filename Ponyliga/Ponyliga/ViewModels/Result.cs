using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace Ponyliga.ViewModels
{
    public class Result : INotifyPropertyChanged
    {

        public string Placement { get; set; }
        public string Club { get; set; }
        public string Score { get; set; }
      /*  public int Score
        {
            get
            {
                return Addend1 + Addend2;
            }
        }
        public string Summary
        {
            get
            {
                return Addend1 + " + " + Addend2 + " = " + Score;
            }
        }*/
        public event PropertyChangedEventHandler PropertyChanged;
    }
}