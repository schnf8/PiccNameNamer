using NameMaker.Models;
using NameMaker.ModelViewController;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using static NameMaker.Models.Picc;

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

        private Picc currentPicc;


        public MyPICCPage()
        {
            loadMyPiccPage();

        }

        /// <summary>
        /// This method initalizes the page and also add all needed information to the information panel, if the user has already registerd a picc
        /// </summary>
        private void loadMyPiccPage()
        {
            InitializeComponent();
            addAllOptions();

            //Checks if a current picc is saved and bind the information to the page. If the piccs expirationdate is not set, the information will be added to the page. If the expiration date is set, but does not lie in the past, the information will also be added.
            if (CurrentAndOldPiccs.currentAndOldPiccs.Count() != 0 && (!CurrentAndOldPiccs.currentAndOldPiccs.Last().IsExpirationDateSet ||
                (CurrentAndOldPiccs.currentAndOldPiccs.Last().IsExpirationDateSet && CurrentAndOldPiccs.currentAndOldPiccs.Last().RemovalDate >= DateTime.Today)))
            {
                //If not set, copy the current datas of the picc object. The current picc object will be needed if the cancel buttons has been clicked.
                if (currentPicc == null)
                {
                    currentPicc = new Picc(CurrentAndOldPiccs.currentAndOldPiccs.Last().PiccModel, CurrentAndOldPiccs.currentAndOldPiccs.Last().InsertDate,
                   CurrentAndOldPiccs.currentAndOldPiccs.Last().InsertCountry, CurrentAndOldPiccs.currentAndOldPiccs.Last().InsertCity, CurrentAndOldPiccs.currentAndOldPiccs.Last().InsertSide, CurrentAndOldPiccs.currentAndOldPiccs.Last().InsertPosition);

                }

                //Load the current carried picc to the binding context
                BindingContext = new CurrentPiccModelView(CurrentAndOldPiccs.currentAndOldPiccs.Last());

                //make the information panel visible and the edit button visible
                PiccInformation.IsVisible = true;
                EditButton.IsVisible = true;
                AllPiccs.IsVisible = true;
            }

            enablePiccDetails(false);

            // Adds a Gesture Regognizer to the picture element, 
            if (PiccImage.Source != null)
            {
                TapGestureRecognizer tapGesture = new TapGestureRecognizer();
                tapGesture.Tapped += (s, e) =>
                {
                    Navigation.PushAsync(new PicturePage((new ImageElement(PiccImage))));
                };
                PiccImage.GestureRecognizers.Add(tapGesture);
            }
            else { PiccImage.IsVisible = false; }

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

        void AllPiccsClicked(object o, EventArgs e)
        {
            Navigation.PushAsync(new AllPiccPage());
        }


        void SaveButtonClicked(object o, EventArgs e)
        {
            currentPicc = null;
            loadMyPiccPage();
        }

        void CancelButtonClicked(object o, EventArgs e)
        {
            //Sets all the values back to the previous values
            CurrentAndOldPiccs.currentAndOldPiccs.Last().InsertDate = currentPicc.InsertDate;
            CurrentAndOldPiccs.currentAndOldPiccs.Last().PiccModel.FrenchSize = currentPicc.PiccModel.FrenchSize;
            CurrentAndOldPiccs.currentAndOldPiccs.Last().InsertCity = currentPicc.InsertCity;
            CurrentAndOldPiccs.currentAndOldPiccs.Last().InsertCountry = currentPicc.InsertCountry;
            CurrentAndOldPiccs.currentAndOldPiccs.Last().InsertSide = currentPicc.InsertSide;
            CurrentAndOldPiccs.currentAndOldPiccs.Last().InsertPosition = currentPicc.InsertPosition;
            CurrentAndOldPiccs.currentAndOldPiccs.Last().RemovalDate = currentPicc.RemovalDate;

            loadMyPiccPage();
        }

        void EditButtonClicked(object o, EventArgs e)
        {
            enablePiccDetails(true);
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
            InsertedDate.IsEnabled = yesOrNo;
            InsertedPlaceAbroad.IsEnabled = yesOrNo;
            InsertedPlaceCH.IsEnabled = yesOrNo;
            PiccSide.IsEnabled = yesOrNo;
            PiccPosition.IsEnabled = yesOrNo;
            PiccFrench.IsEnabled = yesOrNo;
            Country.IsEnabled = yesOrNo;
            ExpirationDate.IsEnabled = yesOrNo;
            ExpirationSwitch.IsEnabled = yesOrNo;

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
        /// This method adds all possible options to the picker objects (countries, cities and bodyside)
        /// </summary>
        private void addAllOptions()
        {

            InsertedPlaceCH.Items.Add("");
            InsertedPlaceCH.Items.Add("Inselspital Bern");
            InsertedPlaceCH.Items.Add("UniversitätsSpital Zürich");
            InsertedPlaceCH.Items.Add("Universitätsspital Basel");
            InsertedPlaceCH.Items.Add("Universitätsspital Genf");
            InsertedPlaceCH.Items.Add("Andere Einrichtung");
            
        }

        public async void SwitchToggled(object o, EventArgs e)
        {
            if (ExpirationSwitch.IsToggled && !currentPicc.IsExpirationDateSet)
            {
                bool expiartion = await DisplayAlert("Warnung", "PICC wird bei Inaktivsetzung nicht mehr in aktueller Ansicht angezeigt, sobald das Inaktivdatum überschritten wird!", "Weiterfahren", "Abbrechen");
                if (expiartion == false)
                {
                    ExpirationSwitch.IsToggled = false;
                    return;

                }
                else
                {
                    ExpirationDate.IsVisible = true;
                    return;
                }
                
            } else if(ExpirationSwitch.IsToggled && currentPicc.IsExpirationDateSet)
            {
                ExpirationDate.IsVisible = false;
                return;
            }
            else { ExpirationDate.IsVisible = false; }   

        }
    }
}



///// <summary>
///// This method saves all changes to the current picc object. 
///// </summary>
//private void savePiccChanges()
//{
//    // Checks if the entered french size is in double format. If not, a popup will inform the user.
//    double frenchSize;
//    if (double.TryParse(PiccFrench.Text.Replace('.', ','), out frenchSize))
//    {
//        CurrentAndOldPiccs.currentAndOldPiccs.Last().frenchSize = frenchSize;
//        if (frenchSize == 0)
//        {
//            PiccFrench.IsVisible = false;
//        }
//    }
//    else
//    {
//        DisplayAlert("Fehler", "Kein gültiger Wert bei French Grösse!\nBeispiel: 4.6", "OK");
//        return;

//    }

//    CurrentAndOldPiccs.currentAndOldPiccs.Last().insertDate = InsertedDate.Date;
//    CurrentAndOldPiccs.currentAndOldPiccs.Last().insertCountry = Country.Items.ElementAtOrDefault(Country.SelectedIndex);
//    CurrentAndOldPiccs.currentAndOldPiccs.Last().piccSide = PiccSide.Items.ElementAtOrDefault(PiccSide.SelectedIndex);

//    if (Country.SelectedIndex == SWITZERLAND)
//    { CurrentAndOldPiccs.currentAndOldPiccs.Last().insertCity = InsertedPlaceCH.Items.ElementAtOrDefault(InsertedPlaceCH.SelectedIndex); }

//    else if (Country.SelectedIndex == ABROAD)
//    { CurrentAndOldPiccs.currentAndOldPiccs.Last().insertCity = InsertedPlaceAbroad.Text; }

//    else { CurrentAndOldPiccs.currentAndOldPiccs.Last().insertCity = ""; }

//    ///disables all the labels, pickers and so on after saving the new information
//    enablePiccDetails(false);
//}
