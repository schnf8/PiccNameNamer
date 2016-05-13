using NameMaker.Model;
using NameMaker.Models;
using NameMaker.ModelViewController;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using static NameMaker.Models.Picc;

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
        List<PiccModel> piccList = AllPiccModels.getModels();

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

            foreach (PiccModel piccModel in piccList)
            {
                // if either the picc name or the barcode could be found in the database
                if ((string.Compare(piccModel.PiccName, searchName, StringComparison.OrdinalIgnoreCase) == 0))
                {
                    currentPicc = new Picc(new PiccModel(piccModel.PiccName, piccModel.FrenchSize, piccModel.PictureUri, piccModel.Barcode), DateTime.Today, PICCInsertCountry.Undefined, "", PICCInsertSide.Undefined, PICCInsertPosition.Undefined);
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
                    currentPicc = new Picc(new PiccModel(piccModel.PiccName, piccModel.FrenchSize, piccModel.PictureUri, piccModel.Barcode), DateTime.Today, PICCInsertCountry.Undefined, "", PICCInsertSide.Undefined, PICCInsertPosition.Undefined);
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
            InsertedPlaceCH.Items.Add("");
            InsertedPlaceCH.Items.Add("Inselspital Bern");
            InsertedPlaceCH.Items.Add("UniversitätsSpital Zürich");
            InsertedPlaceCH.Items.Add("Universitätsspital Basel");
            InsertedPlaceCH.Items.Add("Universitätsspital Genf");
            InsertedPlaceCH.Items.Add("Andere Einrichtung");


        }

        //method to save a picc
        private void saveAPicc()
        {
            //Checks if the entered double value for the french size is in a correct format
            double frenchSize = 0;
            string frenchString = PiccFrench.Text.Replace(',', '.');
            bool success = double.TryParse(frenchString, NumberStyles.Number, CultureInfo.InvariantCulture, out frenchSize);

            if (PiccFrench.Text != null && !success)
            {
                DisplayAlert("Fehler", "Kein gültiger Wert bei French Grösse!\nBeispiel: 4.6", "OK");
                return;
            }

            /// Checks if either "Schweiz", "Ausland" or nothing is selected as country. According to the choice, the picc object will be generated in a different way.
            if (Country.SelectedIndex == SWITZERLAND)
            {
                currentPicc = new Picc(currentPicc.PiccModel, InsertedDate.Date, currentPicc.InsertCountry, InsertedPlaceCH.Items.ElementAtOrDefault(InsertedPlaceCH.SelectedIndex), currentPicc.InsertSide, currentPicc.InsertPosition);
            }

            else if (Country.SelectedIndex == ABROAD)
            {
                currentPicc = new Picc(currentPicc.PiccModel, InsertedDate.Date, currentPicc.InsertCountry, InsertedPlaceAbroad.Text, currentPicc.InsertSide, currentPicc.InsertPosition);
            }
            else
            {
                currentPicc = new Picc(currentPicc.PiccModel, InsertedDate.Date, currentPicc.InsertCountry, "", currentPicc.InsertSide, currentPicc.InsertPosition);
            }

            // Saves the currentPicc object in the list and moves back to the MyPiccPage.
            CurrentAndOldPiccs.currentAndOldPiccs.Add(currentPicc);
            Navigation.PopAsync();

        }
    }
}
