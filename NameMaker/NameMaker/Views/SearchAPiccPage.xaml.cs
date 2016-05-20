﻿using NameMaker.Model;
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

        // Loads all the available picc models, so that they can be found either by an userinput or a barcode scan.
        List<PiccModel> piccList = AllPiccModels.getModels();

        public SearchAPiccPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Gets the input string from the PiccEntry Entry and forward it to the searchForAPiccModel
        /// </summary>
        /// <param name="o"></param>
        /// <param name="e"></param>
        void PiccSearchButtonClicked(object o, EventArgs e)
        {
            string searchName = PiccEntry.Text;
            searchForAPiccModel(searchName);

        }

        void AddPiccManualButtonClick(object o, EventArgs e)
        {
            PiccModel model = new PiccModel(null, 0, null, null);
            //Navigation.PushAsync(new MyPICCPage(model));
            Navigation.PushModalAsync(new MyPICCPage(model));
        }

        async void ScanClick(object sender, EventArgs e)
        {

            var barcode = DependencyService.Get<IScanner>();
            var barcodeResult = await barcode.Barcode();

            if (barcodeResult != null)
            {
                searchForAPiccModel(barcodeResult);
            }

        }

        async void searchForAPiccModel(string nameOrBarcode)
        {
            foreach (PiccModel piccModel in piccList)
            {
                // if either the picc name or the barcode could be found in the database
                if ((string.Compare(piccModel.PiccName, nameOrBarcode, StringComparison.OrdinalIgnoreCase) == 0) || (string.Compare(piccModel.Barcode, nameOrBarcode, StringComparison.OrdinalIgnoreCase) == 0))
                {
                    await Navigation.PushAsync(new MyPICCPage(piccModel));
                    await Navigation.PushModalAsync(new MyPICCPage(piccModel));
                    return;
                }

                //only for test!!!
                if (nameOrBarcode == "e")
                {
                    //await Navigation.PushAsync(new MyPICCPage(piccModel));
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
    }
}
