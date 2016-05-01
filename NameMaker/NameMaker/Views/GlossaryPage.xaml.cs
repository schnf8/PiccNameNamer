using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace NameMaker
{
    public partial class GlossaryPage : ContentPage
    {


        public GlossaryPage()
        {
            InitializeComponent();

            //Adds all glossary entries form the singleton class "GlossaryEntries" to the glossary ListView 
            GlossaryList.ItemsSource = GlossaryEntries.getEntries();
        }

        //Constructor with a GlossaryEntry object. The given entry will be displayed
        public GlossaryPage(GlossaryEntry aSelectedEntry)
        {
            InitializeComponent();

            //Adds all glossary entries form the singleton class "GlossaryEntries" to a variable. Afterwards, the list with the entries will be added to the glossary ListView.
            var glossaryWords = GlossaryEntries.getEntries();

            GlossaryList.ItemsSource = glossaryWords;

            showGlossaryEntry(aSelectedEntry);


        }


        // This method checks whitch glossary entry has been selected and displays the related information in a pop up.
        void OnSelect(object sender, EventArgs e)
        {
            if (GlossaryList.SelectedItem != null)
            {
                GlossaryEntry selectedEntry = (GlossaryEntry)GlossaryList.SelectedItem;
                showGlossaryEntry(selectedEntry);

            }
            GlossaryList.SelectedItem = null;
        }

        //displays a glossary entry. The word is the header, the explanation the body
        private void showGlossaryEntry(GlossaryEntry entry)
        {
            this.DisplayAlert(entry.word, entry.explanation, "Ok");
        }

    }
}

