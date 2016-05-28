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
        //Add a ModelView Controller to the page
        PiccModelModelView piccModelViewInstance = new PiccModelModelView();

        public SearchAPiccPage()
        {
            InitializeComponent();

            if(piccModelViewInstance != null && piccModelViewInstance.PiccModels.Count > 0)
            {
                BindingContext = piccModelViewInstance;
            }           
        }

        /// <summary>
        /// Gets the input string from the SearchBar and checks if a PICC exists with the given information.
        /// </summary>
        /// <param name="o"></param>
        /// <param name="e"></param>
        void PiccSearchButtonClicked(object o, EventArgs e)
        {
            string searchName = PiccEntry.Text;
            searchForAPiccModel(searchName);

        }

        /// <summary>
        /// Sets the visibility of the PiccModel ListView to false if the user has unfocused the searchbar
        /// </summary>
        /// <param name="o"></param>
        /// <param name="e"></param>
        void SearchBarUnfocused(object o, EventArgs e)
        {
            AllModels.IsVisible = false;
        }

        /// <summary>
        /// Sets the visibility of the PiccModel ListView to true if the user has focused the searchbar
        /// </summary>
        /// <param name="o"></param>
        /// <param name="e"></param>
        void SearchBarFocused(object o, EventArgs e)
        {
            AllModels.IsVisible = true;
        }

        void SerachForAPiccModel(object o, EventArgs e)
        {
            AllModels.IsVisible = true;
            FilterLocations(PiccEntry.Text);
        }

        /// <summary>
        /// If the user has selected a PICC model, he/she will be forwarded to the modfify page together with the selected model
        /// </summary>
        /// <param name="o"></param>
        /// <param name="e"></param>
        void SelectedPicc(object o, EventArgs e)
        {
            if (AllModels.SelectedItem != null)
            {
                Navigation.PushModalAsync(new MyPICCPage((PiccModel)AllModels.SelectedItem));
                AllModels.SelectedItem = null;
            }
        }

        /// <summary>
        /// If the user wants to add a PICC model manually, an empty PiccModel object is generated.
        /// </summary>
        /// <param name="o"></param>
        /// <param name="e"></param>
        void AddPiccManualButtonClick(object o, EventArgs e)
        {
            PiccModel model = new PiccModel(null, 0, null, null);
            Navigation.PushModalAsync(new MyPICCPage(model));
        }

        /// <summary>
        /// Enable the camera for barcode scan. If a barcode is returned, it checks if there is a match with a PICC barcode.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        async void ScanClick(object sender, EventArgs e)
        {

            var barcode = DependencyService.Get<IScanner>();
            var barcodeResult = await barcode.Barcode();

            if (barcodeResult != null)
            {
                searchForAPiccModel(barcodeResult);
            }

        }

        /// <summary>
        /// Checks if either the entered name or the barcode can be found within the given PICC models. If no, a popup will inform the user.
        /// </summary>
        /// <param name="nameOrBarcode"></param>
        async void searchForAPiccModel(string nameOrBarcode)
        {
            foreach (PiccModel piccModel in piccModelViewInstance.PiccModels)
            {
                // if either the picc name or the barcode could be found in the database
                if ((string.Compare(piccModel.PiccName, nameOrBarcode, StringComparison.OrdinalIgnoreCase) == 0) || (string.Compare(piccModel.Barcode, nameOrBarcode, StringComparison.OrdinalIgnoreCase) == 0))
                {
                    await Navigation.PushAsync(new MyPICCPage(piccModel));
                    await Navigation.PushModalAsync(new MyPICCPage(piccModel));
                    return;
                }
            }

            bool registerManually = await DisplayAlert("Information", "PICC Modell konnte nicht gefunden werden", "PICC manuell erfassen", "OK");
            if (registerManually)
            {
                PiccModel model = new PiccModel(PiccEntry.Text, 0, null, null);
                await Navigation.PushModalAsync(new MyPICCPage(model));

            }
            else
            {
                PiccEntry.Text = "";
            }

        }

        /// <summary>
        /// Refreshes the AllModels ListView by checking if the entered information in the related Searchbar matches with a PICC
        /// </summary>
        /// <param name="filter"></param>
        void FilterLocations(string filter)
        {
            AllModels.BeginRefresh();

            if (!string.IsNullOrWhiteSpace(filter))
            {
                AllModels.IsVisible = true;
                AllModels.ItemsSource = piccModelViewInstance.PiccModels.Where(x => x.PiccName.ToLower().Contains(filter.ToLower()));
            }
            else
            {
                AllModels.IsVisible = false;
            }

            AllModels.EndRefresh();
        }
    }
}
