using NameMaker.Models;
using NameMaker.ModelViewController;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace NameMaker.Views
{
    public partial class SearchAPiccPage : ContentPage
    {
        /// <summary>
        /// bool to handle if the user either selects Switzerland or another country for the picc implementation
        /// </summary>
        private bool changeInsertedPlace;

        /// <summary>
        /// int for Switzerland and for abroad for the country picker element
        /// </summary>
        private readonly int SWITZERLAND = 1;
        private readonly int ABROAD = 2;

        // variable for the current active picc
        Picc currentPicc;

        /// <summary>
        /// Loads all the available picc models, so that they can be found either by an userinput or a barcode scan.
        /// </summary>
        List<Picc> piccList = AllPiccModels.getModels();

        public SearchAPiccPage()
        {
            LoadSearchAPiccPage();

            // Adds a Gesture Regognizer to the picture element, 
            TapGestureRecognizer tapGesture = new TapGestureRecognizer();
            tapGesture.Tapped += (s, e) =>
            {
                Navigation.PushAsync(new PicturePage((new ImageElement(PiccImage))));
            };
            PiccImage.GestureRecognizers.Add(tapGesture);

        }


        private void LoadSearchAPiccPage()
        {
            InitializeComponent();
            addAllOptions();

        }

        void SideSelected(object o, EventArgs e)
        {

            if (Country.SelectedIndex == SWITZERLAND)
            {
                changeInsertedPlace = true;
                changeBetweenSwitzerlandAndOthers(changeInsertedPlace);
            }
            else if (Country.SelectedIndex == ABROAD)
            {
                changeInsertedPlace = false;
                changeBetweenSwitzerlandAndOthers(changeInsertedPlace);
            }
            else
            {
                InsertedPlaceCH.IsVisible = false;
                InsertedPlaceAbroad.IsVisible = false;
            }
        }

        void PiccSearchButtonClicked(object o, EventArgs e)
        {
            string searchName = PiccEntry.Text;

            foreach (Picc piccModel in piccList)
            {
                // if either the picc name or the barcode could be found in the database
                if ((string.Compare(piccModel.piccName, searchName, StringComparison.OrdinalIgnoreCase) == 0))
                {
                    currentPicc = piccModel;
                    BindingContext = new CurrentPiccModelView(currentPicc);

                    //enables the view to add more information for selected picc
                    PiccInformation.IsVisible = true;

                    //disables the image element if the source is null
                    if (PiccImage.Source == null) { PiccImage.IsVisible = false; }

                    //Enables the save and cancel buttons
                    Save.IsEnabled = true;
                    Cancel.IsEnabled = true;

                    return;
                }

                //only for test!!!
                if (searchName == "e")
                {
                    //Adds the model to the local currentPicc object
                    currentPicc = piccModel;
                    this.BindingContext = new CurrentPiccModelView(currentPicc);

                    //enables the view to add more information for selected picc
                    PiccInformation.IsVisible = true;

                    //Enables the save and cancel buttons
                    Save.IsEnabled = true;
                    Cancel.IsEnabled = true;
                    return;
                }
            }

            DisplayAlert("Information", "PICC Modell konnte nicht gefunden werden", "OK");
            PiccEntry.Text = "";
            PiccInformation.IsVisible = false;
        }

        void SaveButtonClicked(object o, EventArgs e)
        {
            if ((PiccName.Text != null) || (PiccName.Text != ""))
            {
                saveAPicc();

            }

        }

        void CancelButtonClicked(object o, EventArgs e)
        {
            LoadSearchAPiccPage();
        }

        private void changeBetweenSwitzerlandAndOthers(bool choice)
        {
            if (choice)
            {
                InsertedPlaceCH.IsVisible = true;
                InsertedPlaceAbroad.IsVisible = false;
            }
            else
            {

                InsertedPlaceCH.IsVisible = false;
                InsertedPlaceAbroad.IsVisible = true;
            }

        }

        //Add all options to the picker objects (countries, cities and bodyside)
        private void addAllOptions()
        {
            Country.Items.Add("");
            Country.Items.Add("Schweiz");
            Country.Items.Add("Ausland");

            InsertedPlaceCH.Items.Add("");
            InsertedPlaceCH.Items.Add("Inselspital Bern");
            InsertedPlaceCH.Items.Add("UniversitätsSpital Zürich");
            InsertedPlaceCH.Items.Add("Universitätsspital Basel");
            InsertedPlaceCH.Items.Add("Universitätsspital Genf");
            InsertedPlaceCH.Items.Add("Andere Einrichtung");

            PiccSide.Items.Add("");
            PiccSide.Items.Add("Rechts");
            PiccSide.Items.Add("Links");

            PiccPosition.Items.Add("");
            PiccPosition.Items.Add("Oberhalb Ellbogen");
            PiccPosition.Items.Add("Unterhalb Ellbogen");

        }

        //method to save a picc
        private void saveAPicc()
        {
            //Checks if the entered double value for the french size is in a correct format
            double frenchSize = 0;

            if (PiccFrench.Text != null && (!double.TryParse(PiccFrench.Text.Replace('.', ','), out frenchSize)))
            {
                DisplayAlert("Fehler", "Kein gültiger Wert bei French Grösse!\nBeispiel: 4.6", "OK");
                return;
            }

            /// Checks if either "Schweiz", "Ausland" or nothing is selected as country. According to the choice, the picc object will be generated in a different way.
            if (Country.SelectedIndex == SWITZERLAND)
            {
                currentPicc = new Picc(PiccName.Text, frenchSize, currentPicc.uri, currentPicc.barcode, InsertedDate.Date, Country.Items.ElementAtOrDefault(Country.SelectedIndex), InsertedPlaceCH.Items.ElementAtOrDefault(InsertedPlaceCH.SelectedIndex), PiccSide.Items.ElementAtOrDefault(PiccSide.SelectedIndex), PiccPosition.Items.ElementAtOrDefault(PiccPosition.SelectedIndex));
            }

            else if (Country.SelectedIndex == ABROAD)
            {
                currentPicc = new Picc(PiccName.Text, frenchSize, currentPicc.uri, currentPicc.barcode, InsertedDate.Date, Country.Items.ElementAtOrDefault(Country.SelectedIndex), InsertedPlaceAbroad.Text, PiccSide.Items.ElementAtOrDefault(PiccSide.SelectedIndex), PiccPosition.Items.ElementAtOrDefault(PiccPosition.SelectedIndex));
            }
            else
            {
                currentPicc = new Picc(PiccName.Text, frenchSize, currentPicc.uri, currentPicc.barcode, InsertedDate.Date, Country.Items.ElementAtOrDefault(Country.SelectedIndex), "", PiccSide.Items.ElementAtOrDefault(PiccSide.SelectedIndex), PiccPosition.Items.ElementAtOrDefault(PiccPosition.SelectedIndex));
            }

            // Saves the currentPicc object in the list and moves back to the MyPiccPage.
            CurrentAndOldPiccs.currentAndOldPiccs.Add(currentPicc);
            Navigation.PopAsync();

        }
    }
}
