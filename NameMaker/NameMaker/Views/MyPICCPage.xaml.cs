using Android.App;
using Android.Content;
using NameMaker.Model;
using NameMaker.Models;
using NameMaker.ModelViewController;
using NameMaker.Utilitys;
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
        // Variable for the current dispalyed PICC (needed to keep the original information accessable)
        private Picc currentPicc;

        // Variable if the user wants to add a new picc.
        private PiccModel selectedPiccModel = null;

        /// <summary>
        /// Constructor that provides a PiccModel object. The object is given by the "SearchAPiccPage".
        /// </summary>
        /// <param name="model"></param>
        public MyPICCPage(PiccModel model)
        {
            selectedPiccModel = model;
            loadMyPiccPage();

        }


        public MyPICCPage()
        {
            loadMyPiccPage();
        }

        /// <summary>
        /// This method initalizes the page and also add all needed information to the information panel, depending if the user wants to add a new picc,
        /// if already a picc is registered or not.
        /// 
        /// author: Florian Schnyder
        /// </summary>
        private void loadMyPiccPage()
        {
            InitializeComponent();

            // Checks if the user has already saved a picc. If yes, the last added picc needs to be active, otherwise it won't be displayed.
            if (CurrentAndOldPiccs.currentAndOldPiccs.Count() != 0 && (!CurrentAndOldPiccs.currentAndOldPiccs.Last().IsNotActiveAnymore))
            {
                
                // Checks if the selectedPiccModel is null. If it is not null, the user wants to add a new picc and the code below is useless.
                if (selectedPiccModel == null)
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
                    enablePiccDetails(false);

                    addGestureRegognizerToImage();

                }
            }
            //If the selectedPiccModel is not null, the user wants to add a new picc model.
            if (selectedPiccModel != null)
            {
                userWantsToAddANewPicc();
                addGestureRegognizerToImage();
            }

        }

        /// <summary>
        /// This method makes sure that the page is reloaded and the latest picc model will be displayed.
        /// If the selectedPiccModel has a value, the page does not need to be reloaded again. 
        /// </summary>
        protected override void OnAppearing()
        {
            base.OnAppearing();
            if (selectedPiccModel == null)
            {
                loadMyPiccPage();
            }
            
        }

        /// <summary>
        /// This method checks if the user has selected Switzerland, Abroad or nothing on the inserted country picker. If the user
        /// has no country selected, he is not able to enter a city.
        /// </summary>
        /// <param name="o"></param>
        /// <param name="e"></param>
        void SideSelected(object o, EventArgs e)
        {
            if ((PICCInsertCountry)Country.SelectedIndex != PICCInsertCountry.Undefined)
            {
                InsertCity.IsVisible = true;
                return;
            }
            else
            {
                InsertCity.Text = "";
                InsertCity.IsVisible = false;
            }
        }

        /// <summary>
        /// This method moves the user forward to an overview with all picc models.
        /// </summary>
        /// <param name="o"></param>
        /// <param name="e"></param>
        void AllPiccsClicked(object o, EventArgs e)
        {
            if (CurrentAndOldPiccs.currentAndOldPiccs.FirstOrDefault() == null)
            {
                DisplayAlert("Information", "Kein PICC Model gefunden", "Zurück");
                return;
            }
            Navigation.PushAsync(new AllPiccPage());
        }


        async void SaveButtonClicked(object o, EventArgs e)
        {   
            //Warns the user that the current picc wont be visible again if he presses "Weiterfahren"
            if (CurrentAndOldPiccs.currentAndOldPiccs.Last().IsNotActiveAnymore)
            {
                bool remove = await DisplayAlert("Warnung", "PICC wird bei Inaktivsetzung nicht mehr in aktueller Ansicht angezeigt!", "Weiterfahren", "Abbrechen");
                if (!remove)
                {
                    CurrentAndOldPiccs.currentAndOldPiccs.Last().IsNotActiveAnymore = false;

                }
            }

            // Make sure that the currentPicc and the selectedPiccModel variable are null before the page reloads itself.
            currentPicc = null;
            selectedPiccModel = null;
            loadMyPiccPage();
        }

        void CancelButtonClicked(object o, EventArgs e)
        {   
            // If the selected picc model is null, the user wants to cancel a change on the current picc.
            // In this case, all picc values will be overriden by the original information
            if (selectedPiccModel == null)
            {
                //Sets all the values back to the previous values
                CurrentAndOldPiccs.currentAndOldPiccs.Last().InsertDate = currentPicc.InsertDate;
                CurrentAndOldPiccs.currentAndOldPiccs.Last().PiccModel.FrenchSize = currentPicc.PiccModel.FrenchSize;
                CurrentAndOldPiccs.currentAndOldPiccs.Last().InsertCity = currentPicc.InsertCity;
                CurrentAndOldPiccs.currentAndOldPiccs.Last().InsertCountry = currentPicc.InsertCountry;
                CurrentAndOldPiccs.currentAndOldPiccs.Last().InsertSide = currentPicc.InsertSide;
                CurrentAndOldPiccs.currentAndOldPiccs.Last().InsertPosition = currentPicc.InsertPosition;
                CurrentAndOldPiccs.currentAndOldPiccs.Last().RemovalDate = currentPicc.RemovalDate;
                CurrentAndOldPiccs.currentAndOldPiccs.Last().IsNotActiveAnymore = currentPicc.IsNotActiveAnymore;
                
                loadMyPiccPage();
            }
            //If the selectedPiccModel is not null, the user wants to cancel his new selected picc model 
            //(maybe due to a misentry or he does not want to add a new picc at all).
            else
            {   // Removes the new created entry in the currentAndOldPiccs List
                CurrentAndOldPiccs.currentAndOldPiccs.RemoveAt(CurrentAndOldPiccs.currentAndOldPiccs.Count - 1);
                selectedPiccModel = null;
                Navigation.PopAsync();
            }
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
        void enablePiccDetails(bool yesOrNo)
        {
            InsertedDate.IsEnabled = yesOrNo;
            InsertCity.IsEnabled = yesOrNo;
            PiccSide.IsEnabled = yesOrNo;
            PiccPosition.IsEnabled = yesOrNo;
            PiccFrench.IsEnabled = yesOrNo;
            Country.IsEnabled = yesOrNo;
            PiccRemoveButton.IsEnabled = yesOrNo;

            //Changes the visibility to either save/cancel buttons or edit/addAPicc buttons
            SaveAndCancelButtons.IsVisible = yesOrNo;
            EditAndAddButtons.IsVisible = (!yesOrNo);

        }

        public void PiccRemoveButtonClicked(object o, EventArgs e)
        {
            RemovalDate.IsVisible = true;
            RemovalDate.Focus();
            CurrentAndOldPiccs.currentAndOldPiccs.Last().IsNotActiveAnymore = true;
            PiccRemoveButton.IsEnabled = false;

        }

        void userWantsToAddANewPicc()
        {
            currentPicc = new Picc(selectedPiccModel, DateTime.Today, PICCInsertCountry.Undefined, " ", PICCInsertSide.Undefined, PICCInsertPosition.Undefined);
            CurrentAndOldPiccs.currentAndOldPiccs.Add(currentPicc);
            BindingContext = new CurrentPiccModelView(CurrentAndOldPiccs.currentAndOldPiccs.Last());

            PiccInformation.IsVisible = true;
            EditButton.IsVisible = false;
            AllPiccs.IsVisible = false;
            PiccRemoveButton.IsVisible = false;
            enablePiccDetails(true);
        }

        void addGestureRegognizerToImage()
        {
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
    }
}
