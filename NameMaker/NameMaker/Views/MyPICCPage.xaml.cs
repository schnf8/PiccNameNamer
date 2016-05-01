using NameMaker.Classes_and_Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace NameMaker.Views
{
    public partial class MyPICCPage : ContentPage
    {
        private bool changeInsertedPlace;
        List<Picc> piccList = AllPiccModels.getModels();

        public MyPICCPage()
        {
            InitializeComponent();
            addAllOptions();

            Picc currentPicc = piccList.ElementAt(0);

            if (currentPicc != null)
            {
                PiccName.Text = currentPicc.piccName;
            }


        }

        void SideSelected(object o, EventArgs e)
        {

            if (Country.SelectedIndex == 1)
            {
                changeInsertedPlace = true;
                changeBetweenSwitzerlandAndOthers(changeInsertedPlace);
            }
            else if (Country.SelectedIndex == 2)
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
            List<Picc> currentPicc = AllPiccModels.getModels();


            foreach (var name in piccList)
            {

                if ((string.Compare(name.piccName, searchName, StringComparison.OrdinalIgnoreCase) == 0))
                {
                    PiccInformation.IsVisible = true;
                    PiccName.Text = name.piccName;
                    return;
                }
            }

            DisplayAlert("Information", "PICC Modell konnte nicht gefunden werden", "OK");
            PiccEntry.Text = "";
            PiccInformation.IsVisible = false;
        }

        void SaveButtonClicked(object o, EventArgs e)
        {
            return;
        }

        void CancelButtonClicked(object o, EventArgs e)
        {
            return;
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
