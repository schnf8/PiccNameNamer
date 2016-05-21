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
            //Adds all piccs to the ListView 
            PiccList.ItemsSource = CurrentAndOldPiccs.currentAndOldPiccs;
        }

        public async void SelectedPicc(object o, EventArgs e)
        {
            if (PiccList.SelectedItem != null)
            {
                Picc selectedPicc = (Picc)PiccList.SelectedItem;
                if(selectedPicc.RemovalDate != null)
                {
                    await DisplayAlert(selectedPicc.PiccModel.PiccName, "Legedatum: " + selectedPicc.InsertDate.ToString("d") + "\nEntfernungsdatum: " + ((DateTime)selectedPicc.RemovalDate).ToString("d"), "Abbrechen");

                }
                else
                {
                    await DisplayAlert(selectedPicc.PiccModel.PiccName, "Legedatum: " + selectedPicc.InsertDate.ToString("d") + "\nEntfernungsdatum: ", "Abbrechen");

                }

                PiccList.SelectedItem = null;

            }

        }

        private string allInformation()
        {
            string allInformationString = "";
            return allInformationString;
        }


    }
}

