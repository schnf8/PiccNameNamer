using NameMaker.Classes_and_Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace NameMaker.Views
{
    public partial class InformationOverviewPage : ContentPage
    {
        List<KnowledgeEntry> allEntries = new List<KnowledgeEntry>();

        public InformationOverviewPage()
        {
            InitializeComponent();
            //Get all the knowledge entries and add them to  the ListView
            
            KnowledgeEntries.ItemsSource = KnowledgePageEntries.getEntries();

        }

        //Checks which ListView Element has been selected and moves forward to the KnowledgeEntryPage with the related information 
        void OnSelect(object sender, EventArgs e)
        {
            //Checks if the KnowledgeEntries.SelectedItem value is null (value will be null after the following "if" statement).
            if (KnowledgeEntries.SelectedItem != null)
            {
                //Casts the selected object to a Knowledge entry object and moves it forward to the glossary page.
                KnowledgeEntry selectedEntry = (KnowledgeEntry)KnowledgeEntries.SelectedItem;

                Navigation.PushAsync(new KnowledgeEntryPage(selectedEntry)
                {
                    //Sets the title for the new created KnowledgeEntryPage
                    Title = selectedEntry.title
                }
                    );
                KnowledgeEntries.SelectedItem = null;
            }

        }

        //private void CreateKnowledgeEntries()
        //{
        //    // "Was ist ein PICC?" page information
        //    List<KnowledgeEntryElement> content = new List<KnowledgeEntryElement>();
        //    content.Add(new TextElement("Ihr zentraler PICC Venenkatheter besteht aus weichem, flexiblem Material (Silikon oder Polyurethan). Der lange, schmale Katheter ist mit einem breiteren, verstärkten Ansatz aus Kunststoff, sowie je nach Ausführung mit einer Kunststoffklemme und mit «Flügeln» ausgestattet. Durch diese Flügel kann der Katheter besser auf der Haut ﬁxiert werden. Am äusseren Ende ist eine Schutzkappe angebracht. Diese verhindert, dass Blut zurück in den Katheter fliesst (siehe MicroClave).\n\nManchmal verschreibt der Arzt einen Katheter mit zwei separaten Kanälen(doppellumiger Katheter).Diese zwei Kanäle ermöglichen die Verabreichung unterschiedlicher Substanzen."));
        //    content.Add(new ImageElement(new Image { Source = "DoppellumigerPICC.PNG" }, "Doppellumiger PICC: Kunststoffklemme zum Verschliessen des Katheters"));

        //    List<GlossaryEntry> glossaryWords = new List<GlossaryEntry>();
        //    glossaryWords.Add(new GlossaryEntry("Ansatz", "Ein Zwischenstück aus Kunststoff am Katheter. Am Ansatzende des Katheters wird die Schutzkappe (MicroClave) des nadellosen Injektionssystems aufgeschraubt."));
        //    glossaryWords.Add(new GlossaryEntry("Katheter", "Ein weicher Schlauch, der in den Körper eingeführt wird. In diesem Fall handelt es sich um einen peripher eingeführten zentralen Venenkatheter (PICC: Peripherally inserted central venous catheter), der in eine Armvene eingeführt wird. Die Spitze des Katheters beﬁndet sich in einem Bereich mit grosser Blutzirkulation in der Nähe des Herzens. Durch den Katheter können verschiedene Medikamente und Flüssigkeiten verabreicht werden. Dadurch ist es nicht nötig, eine Nadel (Kanüle) direkt in die Vene einzuführen."));
        //    glossaryWords.Add(new GlossaryEntry("PICC (peripher eingeführter zentraler Venenkatheter oder peripherally inserted central venous catheter)", "Ein Katheter, der in eine der Armvenen eingeführt wird und bis in die Nähe des Herzens führt. Medikamente, die durch den Katheter verabreicht werden, können sich gut mit dem Blut vermischen. Dieser Katheter kann mit optimaler Pflege bis zu mehreren Monaten im Körper verbleiben."));
        //    glossaryWords.Add(new GlossaryEntry("Schutzkappe des nadellosen Injektionssystems (MicroClave)", "Die Schutzkappe des nadellosen Injektionssystems sorgt dafür, dass kein Blut zurück in den Katheter fliesst. Ausserdem kann die Verabreichung von Flüssigkeiten und Medikamenten in den Blutkreislauf direkt über diese Schutzkappe erfolgen. Sie muss vor jeder Verwendung genauestens desinfiziert werden."));

        //    KnowledgeEntry generalInformation = new KnowledgeEntry("Was ist ein PICC", content, glossaryWords);
        //    allEntries.Add(generalInformation);

        //    // "Wozu wird ein PICC verwendet?" page information
        //    List<KnowledgeEntryElement> content2 = new List<KnowledgeEntryElement>();
        //    content2.Add(new TextElement("Ein PICC ist für die Verabreichung von Flüssigkeiten, von Blutprodukten, Medikamenten und intravenösen Nährlösungen bestimmt. Er kann auch zur Abnahme von Blutproben verwendet werden. Ein PICC kann je nach Therapie mehrere Wochen oder Monate in einer Vene verbleiben.\n\nDer PICC ist insbesondere dann sinnvoll, wenn Ihnen im Rahmen einer Therapie zahlreiche Infusionen verabreicht werden müssen. Dank dem Venenzugang über den PICC müssen die Fachleute nicht für jede Infusion eine neue Einstichstelle schaffen. Der PICC verhindert somit, dass Ihre Venen an Hand und Arm durch diverse Einstiche belastet werden.\n\nDie Verabreichung Ihrer Therapie wird durch den PICC zuverlässiger, komfortabler und einfacher."));
        //    content2.Add(new ImageElement(new Image { Source = "EinlumigerPICC.PNG" }, "Einlumiger PICC: Weiches, flexibles Kathetermaterial"));

        //    List<GlossaryEntry> glossaryWords2 = new List<GlossaryEntry>();
        //    glossaryWords2.Add(new GlossaryEntry("Intravenöse Therapie (IV-Therapie)", "Ein Medikamenten oder eine Flüssigkeit wird durch eine Vene verabreicht."));
        //    glossaryWords2.Add(new GlossaryEntry("Katheter", "Ein weicher Schlauch, der in den Körper eingeführt wird. In diesem Fall handelt es sich um einen peripher eingeführten zentralen Venenkatheter (PICC: Peripherally inserted central venous catheter), der in eine Armvene eingeführt wird. Die Spitze des Katheters beﬁndet sich in einem Bereich mit grosser Blutzirkulation in der Nähe des Herzens. Durch den Katheter können verschiedene Medikamente und Flüssigkeiten verabreicht werden. Dadurch ist es nicht nötig, eine Nadel (Kanüle) direkt in die Vene einzuführen."));
        //    glossaryWords2.Add(new GlossaryEntry("PICC (peripher eingeführter zentraler Venenkatheter oder peripherally inserted central venous catheter)", "Ein Katheter, der in eine der Armvenen eingeführt wird und bis in die Nähe des Herzens führt. Medikamente, die durch den Katheter verabreicht werden, können sich gut mit dem Blut vermischen. Dieser Katheter kann mit optimaler Pflege bis zu mehreren Monaten im Körper verbleiben."));

        //    KnowledgeEntry generalInformation2 = new KnowledgeEntry("Wozu wird ein PICC verwendet?", content2, glossaryWords2);
        //    allEntries.Add(generalInformation2);
        //}
    }
}
