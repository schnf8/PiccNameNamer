using NameMaker.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace NameMaker
{
    public partial class AllPiccPage : ContentPage
    {


        public AllPiccPage()
        {
            InitializeComponent();

            if (CurrentAndOldPiccs.currentAndOldPiccs.FirstOrDefault() == null)
            {
                DisplayAlert("Information", "Kein PICC Model gefunden", "Zurück");
                return;
            }
            else
            {
                //Adds all piccs to the ListView 
                PiccList.ItemsSource = CurrentAndOldPiccs.currentAndOldPiccs;
            }
        }

        public async void selectedPicc(object o, EventArgs e)
        {
            if (PiccList.SelectedItem != null)
            {
                Picc selectedPicc = (Picc)PiccList.SelectedItem;

                await DisplayAlert(selectedPicc.PiccModel.PiccName, (selectedPicc.InsertDate + "\n" + selectedPicc.InsertCountry), "Abbrechen");

                PiccList.SelectedItem = null;

            }

        }


    }
}

