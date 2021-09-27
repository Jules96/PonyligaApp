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
    public partial class GameStructure : ContentPage
    {
        public GameStructure()
        {
            InitializeComponent();

            labelGameName.Text = "Allgemein";
            labelGameStructureText.Text = generalText;
            labelStructure.Text = "";

            //string gameOneText = "Aufbau : Es werden in einer Reihe 5 Kegel in einem Abstand von je 5m aufgestellt auf den Kegeln wird jeweils ein Tennisball gelegt.Der erste Kegel steht im Abstand von 5m zu der Startlinie";
            //label_GameOne.Text = gameOneText;
            //var gameOne = new Image { Source = "Spiel1.jpg" };

            //string gameTwoText = "Aufbau: Es werden 5 Kegel mit jeweils 5m Abstand zueinander in einer Reihe aufgestellt. (wie beim Slalom) Jetzt werden 5 Besenstiele Länge a'1,40m in die Kegel gestellt. Auf die ersten 4 Besenstiele wird jeweils 1 Becher(Kunststoff - Becher 0, 2ltr) gestülpt.Stab Nr.5 bleibt vorerst frei.";
            //label_GameTwo.Text = gameTwoText;
            //var gameTwo = new Image { Source = "Spiel2.jpg" };

            //string gameThreeText = "Aufbau: Auf der Spielbahn werden in Bahnrichtung 5 umgestülpte Eimer im Abstand von einer je einer Eimerbreite hintereinander aufgestellt. (Beginn B - E). Am Ende der Bahn wird ein Kegel als Wendemarke(K - F) aufgestellt.";
            //label_GameThree.Text = gameThreeText;
            //var gameThree = new Image { Source = "Spiel3.jpg" };

            //string gameFourText = "";
            //label_GameFour.Text = gameFourText;
            //var gameFour = new Image { Source = "Spiel4.jpg" };

            //string gameFiveText = "Aufbau: Flaggenkasten 1 auf Höhe ( E-B)mit 4 Flaggen, Flaggenkasten 2 auf Wendelinie(K-F)";
            //label_GameFive.Text = gameFiveText;
            //var gameFive = new Image { Source = "Spiel5.jpg" };

            //string gameSixText = "Aufbau: Der erste (leere) Eimer wird 5 m von der Start-/ Ziellinie aufgestellt. Der zweite Eimer steht auf der Wechsellinie K - F (27m von Start -/ Ziellinie) mit 4 kleinen Säckchen aufgestellt.";
            //label_GameSix.Text = gameSixText;
            //var gameSix = new Image { Source = "Spiel6.jpg" };
        }

        private void OnGameStructure_RadioButton_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            
            if (rb_General.IsChecked)
            {
                scrollViewGameStructure.ScrollToAsync(0, 0, false);
                labelGameName.Text = "Allgemein";
                labelMaterial.Text = "";
                imageMaterial.Source = "";
                labelGameStructureText.Text = generalText;
                labelStructure.Text = "";
                imageGameStructure.Source = "";
            }
            else if (rb_GameOne.IsChecked)
            {
                scrollViewGameStructure.ScrollToAsync(0, 0, false);
                labelGameName.Text = "Spiel 1:";
                labelMaterial.Text = "Material: 5 Kegel, 5 Tennisbälle, 1 Staffelstab";
                imageMaterial.Source = (Device.RuntimePlatform == Device.Android) ? ImageSource.FromFile("game1.jpg") : ImageSource.FromFile("game1.jpg");
                labelGameStructureText.Text = gameOneText;
                imageGameStructure.Source = (Device.RuntimePlatform == Device.Android) ? ImageSource.FromFile("structure1.jpg") : ImageSource.FromFile("structure1.jpg");
                //var gameOne = new Image { Source = "Spiel1.jpg" };
            }
            else if (rb_GameTwo.IsChecked)
            {
                scrollViewGameStructure.ScrollToAsync(0, 0, false);
                labelGameName.Text = "Spiel 2:";        
                labelMaterial.Text = "Material: 5 Kegel, 5 Besenstiele, 4 Becher";
                imageMaterial.Source = (Device.RuntimePlatform == Device.Android) ? ImageSource.FromFile("game2.jpg") : ImageSource.FromFile("game2.jpg");
                labelGameStructureText.Text = gameTwoText;
                imageGameStructure.Source = (Device.RuntimePlatform == Device.Android) ? ImageSource.FromFile("structure2.jpg") : ImageSource.FromFile("structure2.jpg");
                //var gameTwo = new Image { Source = "Spiel2.jpg" };
            }
            else if (rb_GameThree.IsChecked)
            {
                scrollViewGameStructure.ScrollToAsync(0, 0, false);
                labelGameName.Text = "Spiel 3:";
                labelMaterial.Text = "Material: 5 Eimer(Steine), 1 Kegel";
                imageMaterial.Source = (Device.RuntimePlatform == Device.Android) ? ImageSource.FromFile("game3.jpg") : ImageSource.FromFile("game3.jpg");
                labelGameStructureText.Text = gameThreeText;
                imageGameStructure.Source = (Device.RuntimePlatform == Device.Android) ? ImageSource.FromFile("structure3.jpg") : ImageSource.FromFile("structure3.jpg");
                //var gameThree = new Image { Source = "Spiel3.jpg" };
            }
            else if (rb_GameFour.IsChecked)
            {
                scrollViewGameStructure.ScrollToAsync(0, 0, false);
                labelGameName.Text = "Spiel 4:";
                labelMaterial.Text = "Material: 1 Sack, 1 Kegel";
                imageMaterial.Source = (Device.RuntimePlatform == Device.Android) ? ImageSource.FromFile("game4.jpg") : ImageSource.FromFile("game4.jpg");
                labelGameStructureText.Text = gameFourText;
                imageGameStructure.Source = (Device.RuntimePlatform == Device.Android) ? ImageSource.FromFile("structure4.jpg") : ImageSource.FromFile("structure4.jpg");
                //var gameFour = new Image { Source = "Spiel4.jpg" };
            }
            else if (rb_GameFive.IsChecked)
            {
                scrollViewGameStructure.ScrollToAsync(0, 0, false);
                labelGameName.Text = "Spiel 5:";
                labelMaterial.Text = "Material: 2 Holzkisten, 5 Flaggen";
                imageMaterial.Source = (Device.RuntimePlatform == Device.Android) ? ImageSource.FromFile("game5.jpg") : ImageSource.FromFile("game5.jpg");
                labelGameStructureText.Text = gameFiveText;
                imageGameStructure.Source = (Device.RuntimePlatform == Device.Android) ? ImageSource.FromFile("structure5.jpg") : ImageSource.FromFile("structure5.jpg");
                //var gameFive = new Image { Source = "Spiel5.jpg" };
            }
            else if (rb_GameSix.IsChecked)
            {
                scrollViewGameStructure.ScrollToAsync(0, 0, false);
                labelGameName.Text = "Spiel 6:";
                labelMaterial.Text = "Material: 2 10 ltr. Eimer, 4 kleine Säckchen";
                imageMaterial.Source = (Device.RuntimePlatform == Device.Android) ? ImageSource.FromFile("game6.jpg") : ImageSource.FromFile("game6.jpg");
                labelGameStructureText.Text = gameSixText;
                imageGameStructure.Source = (Device.RuntimePlatform == Device.Android) ? ImageSource.FromFile("structure6.jpg") : ImageSource.FromFile("structure6.jpg");
                //var gameSix = new Image { Source = "Spiel6.jpg" };
            }
        }

        readonly string generalText = "• Für alle Spiele wird zunächst einmal eine Startlinie hergestellt. \n• Die Startlinie kann mit auf dem Boden liegenden Hindernisstangen oder auch mit \n• Späne gekennzeichnet werden Für alle Spiele wird eine Stoppuhr benötigt";
        readonly string gameOneText = "Aufbau : Es werden in einer Reihe 5 Kegel in einem Abstand von je 5m aufgestellt auf den Kegeln wird jeweils ein Tennisball gelegt.Der erste Kegel steht im Abstand von 5m zu der Startlinie";
        readonly string gameTwoText = "Aufbau: Es werden 5 Kegel mit jeweils 5m Abstand zueinander in einer Reihe aufgestellt. (wie beim Slalom) Jetzt werden 5 Besenstiele Länge a'1,40m in die Kegel gestellt. Auf die ersten 4 Besenstiele wird jeweils 1 Becher(Kunststoff - Becher 0, 2ltr) gestülpt.Stab Nr.5 bleibt vorerst frei.";
        readonly string gameThreeText = "Aufbau: Auf der Spielbahn werden in Bahnrichtung 5 umgestülpte Eimer im Abstand von einer je einer Eimerbreite hintereinander aufgestellt. (Beginn B - E). Am Ende der Bahn wird ein Kegel als Wendemarke(K - F) aufgestellt.";
        readonly string gameFourText = "";
        readonly string gameFiveText = "Aufbau: Flaggenkasten 1 auf Höhe ( E-B)mit 4 Flaggen, Flaggenkasten 2 auf Wendelinie(K-F)";
        readonly string gameSixText = "Aufbau: Der erste (leere) Eimer wird 5 m von der Start-/ Ziellinie aufgestellt. Der zweite Eimer steht auf der Wechsellinie K - F (27m von Start -/ Ziellinie) mit 4 kleinen Säckchen aufgestellt.";
    }
}