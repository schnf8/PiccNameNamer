using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace NameMaker.Views
{
    public partial class WhyUseAPiccPage : ContentPage
    {
        public WhyUseAPiccPage()
        {
            InitializeComponent();

            //    // Adds all mentioned glossary entries of this page to the glossary label on the bottom of the page
            //    List<GlossaryEntry> glossaryWords = new List<GlossaryEntry>();

            //    glossaryWords.Add(new GlossaryEntry("Intravenöse Therapie (IV-Therapie)", "Ein Medikamenten oder eine Flüssigkeit wird durch eine Vene verabreicht."));
            //    glossaryWords.Add(new GlossaryEntry("Katheter", "Ein weicher Schlauch, der in den Körper eingeführt wird. In diesem Fall handelt es sich um einen peripher eingeführten zentralen Venenkatheter (PICC: Peripherally inserted central venous catheter), der in eine Armvene eingeführt wird. Die Spitze des Katheters beﬁndet sich in einem Bereich mit grosser Blutzirkulation in der Nähe des Herzens. Durch den Katheter können verschiedene Medikamente und Flüssigkeiten verabreicht werden. Dadurch ist es nicht nötig, eine Nadel (Kanüle) direkt in die Vene einzuführen."));
            //    glossaryWords.Add(new GlossaryEntry("PICC (peripher eingeführter zentraler Venenkatheter oder peripherally inserted central venous catheter)", "Ein Katheter, der in eine der Armvenen eingeführt wird und bis in die Nähe des Herzens führt. Medikamente, die durch den Katheter verabreicht werden, können sich gut mit dem Blut vermischen. Dieser Katheter kann mit optimaler Pflege bis zu mehreren Monaten im Körper verbleiben."));

            //    GlossaryList.ItemsSource = glossaryWords;

            //   // Adds a Gesture Regognizer to link a word with the glossary
            //    TapGestureRecognizer tapGesture = new TapGestureRecognizer();
            //    tapGesture.Tapped += (s, e) =>
            //    {   
            //        //get the image source and add it to the tapped event
            //        ImageSource source = Picc.Source;

            //        if (source != null)
            //        {
            //           Navigation.PushAsync(new PicturePage(source));
            //        }

            //    };
            //    Picc.GestureRecognizers.Add(tapGesture);
            //}

            //void OnSelect(object sender, EventArgs e)
            //{
            //    //Checks if the GlossaryList.SelectetItem value is null (value will be null after the following "if" statement).
            //    if (GlossaryList.SelectedItem != null)
            //    {

            //        //Casts the selected object to a glossary entry and moves forward to the glossary page
            //        GlossaryEntry selectedEntry = (GlossaryEntry)GlossaryList.SelectedItem;
            //        Navigation.PushAsync(new GlossaryPage(selectedEntry));
            //        GlossaryList.SelectedItem = null;

            //    }
            //}
        }
    }
}
