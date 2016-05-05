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
    public partial class MyPICCPage : ContentPage
    {
        /// <summary>
        /// bool to handle if the user either selects Switzerland or another Country for the picc implementation
        /// </summary>
        private bool changeInsertedPlace;

        /// <summary>
        /// int for checking if either Switzerland or abroad is selected in the country picker element
        /// </summary>
        private readonly int SWITZERLAND = 1;
        private readonly int ABROAD = 2;


        public MyPICCPage()
        {
            loadMyPiccPage();

        }

        /// <summary>
        /// This method initalizes the page and also add all needed information to the
        /// </summary>
        private void loadMyPiccPage()
        {
            InitializeComponent();
            addAllOptions();

            //Checks if a current picc is saved and bind the information to the page
            if (CurrentAndOldPiccs.currentAndOldPiccs.Count() != 0)
            {
                BindingContext = new CurrentPiccModelView(CurrentAndOldPiccs.currentAndOldPiccs.Last());
                PiccInformation.IsVisible = true;
                EditButton.IsVisible = true;

                if (PiccFrench.Text == "0")
                {
                    PiccFrench.IsVisible = false;
                }

            }

            enablePiccDetails(false);

        }

        /// <summary>
        /// This method makes sure that the page is reloaded and the latest picc model will be displayed.
        /// </summary>
        protected override void OnAppearing()
        {
            base.OnAppearing();
            loadMyPiccPage();
        }

        /// <summary>
        /// This method checks if the user has selected Switzerland, Abroad or nothing on the inserted country picker. Depending on the 
        /// selection, the interface shows all information either Switzerland, Abroad or none of them.
        /// </summary>
        /// <param name="o"></param>
        /// <param name="e"></param>
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


        void SaveButtonClicked(object o, EventArgs e)
        {
            savePiccChanges();

        }

        void CancelButtonClicked(object o, EventArgs e)
        {
            loadMyPiccPage();
        }

        void EditButtonClicked(object o, EventArgs e)
        {
            enablePiccDetails(true);
            PiccFrench.IsVisible = true;

        }

        void AddAPiccButtonClicked(object o, EventArgs e)
        {
            Navigation.PushAsync(new SearchAPiccPage());
        }

        /// <summary>
        /// This method either enables or disables the input field for the picc information
        /// </summary>
        /// <param name="yesOrNo"></param>
        private void enablePiccDetails(bool yesOrNo)
        {

            PiccName.IsEnabled = yesOrNo;
            InsertedDate.IsEnabled = yesOrNo;
            InsertedPlaceAbroad.IsEnabled = yesOrNo;
            InsertedPlaceCH.IsEnabled = yesOrNo;
            PiccSide.IsEnabled = yesOrNo;
            PiccFrench.IsEnabled = yesOrNo;
            Country.IsEnabled = yesOrNo;

            //Changes the visibility to either save/cancel buttons or edit/addAPicc buttons
            SaveAndCancelButtons.IsVisible = yesOrNo;
            EditAndAddButtons.IsVisible = (!yesOrNo);

        }

        /// <summary>
        /// This method checks if either the city picker for Switzerland is visible or the entry box to enter a city abroad
        /// </summary>
        /// <param name="choice"></param>
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

        /// <summary>
        /// This method saves all changes to the current picc object. 
        /// </summary>
        private void savePiccChanges()
        {
            // Checks if the entered french size is in double format. If not, a popup will inform the user.
            double frenchSize;
            if (double.TryParse(PiccFrench.Text.Replace('.', ','), out frenchSize))
            {
                CurrentAndOldPiccs.currentAndOldPiccs.Last().frenchSize = frenchSize;
                if (frenchSize == 0)
                {
                    PiccFrench.IsVisible = false;
                }
            }
            else
            {
                DisplayAlert("Fehler", "Kein gültiger Wert bei French Grösse!\nBeispiel: 4.6", "OK");
                return;

            }

            CurrentAndOldPiccs.currentAndOldPiccs.Last().insertDate = InsertedDate.Date;
            CurrentAndOldPiccs.currentAndOldPiccs.Last().insertCountry = Country.SelectedIndex;
            CurrentAndOldPiccs.currentAndOldPiccs.Last().piccSide = PiccSide.SelectedIndex;

            if (Country.SelectedIndex == SWITZERLAND)
            { CurrentAndOldPiccs.currentAndOldPiccs.Last().insertCity = InsertedPlaceCH.ToString(); }

            else if (Country.SelectedIndex == ABROAD)
            { CurrentAndOldPiccs.currentAndOldPiccs.Last().insertCity = InsertedPlaceAbroad.Text; }

            ///enables all the labels, pickers and so on after saving the new information
            enablePiccDetails(false);
        }

        /// <summary>
        /// This method adds all possible options to the picker objects (countries, cities and bodyside)
        /// </summary>
        private void addAllOptions()
        {
            Country.Items.Add(" ");
            Country.Items.Add("Schweiz");
            Country.Items.Add("Ausland");

            InsertedPlaceCH.Items.Add(" ");
            InsertedPlaceCH.Items.Add("Inselspital Bern");
            InsertedPlaceCH.Items.Add("UniversitätsSpital Zürich");
            InsertedPlaceCH.Items.Add("Universitätsspital Basel");
            InsertedPlaceCH.Items.Add("Universitätsspital Genf");
            InsertedPlaceCH.Items.Add("Andere Einrichtung");

            PiccSide.Items.Add(" ");
            PiccSide.Items.Add("Rechts");
            PiccSide.Items.Add("Links");

        }
    }
}
