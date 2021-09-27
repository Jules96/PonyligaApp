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
    public partial class Rules : ContentPage
    {
        public Rules()
        {
            InitializeComponent();
        }

        // rb umbenennen
        private void OnRule_RadioButton_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            if (rb1.IsChecked)
            {
                LabelRuleText.Text = GameOne;
            }
            else if (rb2.IsChecked)
            {
                LabelRuleText.Text = GameTwo;
            }
            else if (rb3.IsChecked)
            {
                LabelRuleText.Text = GameThree;
            }
            else if (rb4.IsChecked)
            {
                LabelRuleText.Text = GameFour;
            }
            else if (rb5.IsChecked)
            {
                LabelRuleText.Text = GameFive;
            }
            else if (rb6.IsChecked)
            {
                LabelRuleText.Text = GameSix;
            }
        }

        // RuleText / not charming but serves its purpose
        readonly string GameOne = "Der erste Reiter erhält einen Staffelstab und reitet im Slalom durch die 5 Kegel, um den letzten herum und im Slalom zurück zur Start- und Ziellinie, dort übergibt er den Staffelstab an den nächsten Reiter weiter. Die Übergabe muss sitzend vom Pferd aus hinter der Start- Ziellinie erfolgen. Alle Reiter absolvieren den Parcours in der gleichen Weise. \nWas wenn ein Fehler passiert? \n• Fällt ein Ball herunter oder ein Kegel um, muss er vom Reiter wieder aufgelegt bzw.aufgestellt werden. Danach darf der Reiter seinen Ritt an dieser Stelle fortsetzen; der entsprechende Kegel muss nicht nochmals umritten werden. \n• Wird ein Kegel ausgelassen, muss der Reiter zurück zum entsprechenden Kegel reiten und ab hier das Spiel fortsetzen \n• Fällt der Staffelstab bei der Übergabe hinter der Start- und Ziellinie herunter muss der gerade gerittene Reiter absitzen den Staffelstab aufheben und vom Pony aus an den nächsten Reiter übergeben.Verliert ein Reiter den Stab während des Spiels, muss er absitzen, den Stab aufheben, wieder aufsitzen und darf dann erst das Spiel fortsetzen.";
        readonly string GameTwo = "Der erste Reiter reitet zum Becher Nr.4 nimmt ihn vom Besenstiel herunter und bringt ihn zu Stab Nr.5 und setzt ihn dort ab,danach reitet der Reiter so schnell wie möglich zurück zur Start-/ Ziellinie.Reiter Nr.2 startet erst wenn Reiter Nr.1 im Ziel ist.Reiter Nr. 2 nimmt nun vom Stab Nr.3 den Becher herunter und stülpt den Becher auf den freien Stab Nr.4. Reiter Nr.3 nimmt den Becher von Stab 2 und setzt ihn auf Stab 3 und Reiter Nr.4 (Schlussreiter) nimmt den Becher von Stab Nr.1 und setzt ihn auf Stab 2. Wenn alle Becher umgesetzt sind und der Schlussreiter die Ziellinie überquert hat ist das Spiel zu Ende. \nWas, wenn ein Fehler passiert? \n• Fällt ein Becher herunter, springt der Reiter von seinem Pony herunter hebt den Becher auf, sitzt wieder auf und stülpt den Becher , auf dem Pony sitzend, auf den entsprechenden Stab. \n• Fällt ein Kegel um, steigt auch hier der Reiter ab, stellt den Kegel wieder auf, darf dann wieder aufsitzen und das Spiel fortführen.";
        readonly string GameThree = "Der erste Reiter startet auf dem Pony sitzend von der Startlinie, sitzt vor den „Eimern“ ab, läuft über die Eimer währenddessen führt er sein Pony nebenher. Der Reiter muss, ohne zwischendurch den Boden zu berühren nacheinander auf alle 5 Eimer treten. Nach mindestens einem Schritt nach den Eimern, sitzt der Reiter wieder auf, die Wendemarke muss umritten werden, danach reitet er so schnell wie möglich zurück zur Start-/ Ziellinie.Erst dann darf der nächste Reiter starten, und absolviert das Spiel auf gleiche Weise. \nWas ist wenn ein Fehler passiert? \n• Lässt ein Reiter beim Überqueren der Eimer einen Eimer aus, muss er umdrehen und die Eimer erneut überqueren. Fällt ein Eimer um, wird dieser vom Schiedsrichter wieder aufgestellt. Fällt ein Eimer durch das drauf treten um, ist dies kein Fehler und das Spiel kann direkt fortgesetzt werden. \n• Fällt der Kegel (Wendemarke ) um, muss der Reiter absitzen und den Kegel wieder aufstellen.";
        readonly string GameFour = "Reiter 1 bekommt den Sack in die Hand und wartet hinter der Start-/ Ziellinie. Reiter 2,3 und 4 warten am Ende der Spielbahn beim Kegel(K.-F ). Nach dem Startsignal reitet Reiter 1 mit dem Sack zum anderen Ende der Bahn und übergibt den Sack(von Hand zu Hand) an Reiter 2 . Beide steigen mit einem Bein in den Sack und laufen, die Ponys führend, zurück zur Start-/Ziellinie. Beide Reiter steigen hinter der Start-/ Zielinie aus dem Sack.Reiter 2 springt auf sein Pony, Reiter 1 überreicht dem Reiter 2 den Sack hinter der Start-/Zielinie dieser reitet zum anderen Ende der Spielbahn und überreicht den Sack an Spieler Nr.3. Somit laufen dann Spieler 2 & 3 zurück zur Start-/Ziellinie.Anschließend holt Spieler 3 den Spieler 4 auf gleiche Weise ab. Die Zeit wird erst gestoppt wenn Spieler 3&4 und beide Ponys komplett die Ziellinie passiert haben.";
        readonly string GameFive = "Reiter 1 bekommt eine Flagge in die Hand, er startet nach dem Signal und steckt die Flagge in den Flaggenkasten 2, auf dem Rückweg greift er sich eine neue Flagge aus Kasten 1, diese übergibt er dem Reiter 2hinter der Startlinie, dann startet Reiter 2 auf gleiche Weise.Alle Reiter absolvieren das Spiel auf gleiche Weise.Reiter 4 trägt die letzte Flagge bis über die Ziellinie. \nWas ist wenn ein Fehler passiert ? \n• Fällt eine Flagge beim Flaggenkasten runter, steigt der Reiter ab, die Flagge darf er von unten in den Kasten stecken, sitzt dann wieder auf und führt das Spiel weiter. \n• Greift der Spieler mehr als eine Flagge aus Kasten muss er die zu viel genommenen sofort zurück bringen. \n• Fällt aus dem Kasten eine Flagge runter, kann der Spieler die Flagge aufheben und mit der Flagge in der Hand aufsitzen oder die Flagge erst wieder in den Kasten stellen, aufsitzen und die Flagge erneut greifen und das Spiel fortsetzen. \n• Fällt die Flagge bei der Übergabe hinter der Start-/Ziellinie runter muss der Reiter absitzen, die Flagge aufheben und dann wieder auf dem Pony sitzend die Flagge an den nächsten Spieler überreichen. \n• Fällt ein Flaggenkasten um, muss der Spieler absitzen wieder aufbauen und darf dann erst das Spiel fortsetzen";
        readonly string GameSix = "Reiter Nr. startet reitet zu dem hinteren Eimer und holt sich eine Säckchen aus dem Eimer und bringt das Säckchen zu dem vorderen Eimer und wirft das Säckchen(auf dem Pony sitzend) in den vorderen Eimer.Wenn er die Start-/Ziellinie passiert hat startet Reiter Nr.2 usw. \nWas ist wenn ein Fehler passiert? \n• Greift ein Spieler mehr als1 Säckchen, muss er die zu viel genommen sofort wieder zurück bringen \n• Wirft ein Spieler beim vorderen Eimer daneben, muss der Reiter absitzen das Säckchen greifen, aufsitzen und sitzend vom Pony aus das Säckchen im den Eimer werfen. \n• Wird ein Eimer umgeworfen, muss der Spieler den Eimer wieder aufstellen und darf erst das Spiel fortsetzen.";

    }
}