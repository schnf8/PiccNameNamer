using Core;
using NameMaker.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace NameMaker
{
    public partial class MainPage : ContentPage
    {
        List<Name> newName = new List<Name>();
        ObservableCollection<Name> displayedNames = new ObservableCollection<Name>();

        public MainPage()
        {
            InitializeComponent();
            NamesListPage();
        }


        public void NamesListPage()
        {
            namesList.ItemsSource = displayedNames;

        }
        
        void MyPiccButtonClick(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MyPICCPage());
        }

        void ScanPageButtonClick(object sender, EventArgs e)
        {
            Navigation.PushAsync(new BarCodeScannerPage());
        }

        void InformationOverviewButtonClick(object sender, EventArgs e)
        {
            Navigation.PushAsync(new InformationOverviewPage());
        }

        void GlossaryPageButtonClick(object sender, EventArgs e)
        {
            Navigation.PushAsync(new GlossaryPage());
            //DisplayAlert("Schutzkappe des nadellosen Injektionssystems (MicroClave)", "Die Schutzkappe des nadellosen Injektionssystems sorgt dafür, dass kein Blut zurück in den Katheter fliesst. Ausserdem kann die Verabreichung von Flüssigkeiten und Medikamenten in den Blutkreislauf direkt über diese Schutzkappe erfolgen.Sie muss vor jeder Verwendung genauestens desinfiziert werden.", "OK");
        }

        void OnBuild(object sender, EventArgs e)
        {
            //clears the list before adding the new elements
            try { displayedNames.Clear(); }

            //Sometimes error with Windows phone, other option for clear the whole collection
#pragma warning disable CS0168 // Variable ist deklariert, wird jedoch niemals verwendet
            catch (Exception ex)
            {
#pragma warning restore CS0168 // Variable ist deklariert, wird jedoch niemals verwendet
                if (!(displayedNames.Count == 0))
                {
                    int max = displayedNames.Count;
                    int index = 1;

                    while (index <= max)
                    {
                        displayedNames.RemoveAt(0);
                        index++;
                    }
                }
            }
            newName = NameTranslator.TranslateToName(NameText.Text);
            
            if (!newName.Equals(null))
            {
                foreach (Name a in newName)
                {
                    displayedNames.Add(a);

                }
            }
        }

        async void OnSelect(object sender, EventArgs e)
        {
            if (await this.DisplayAlert(
                    "Send an email",
                    "Would you like to send an email to " + namesList.SelectedItem.ToString() + "?",
                    "Yes",
                    "No"))
            {
                emailLabel.IsVisible = true;
                emailLabel.Text = namesList.SelectedItem.ToString() + "@bfh.ch";
                
                
            }

        }


    }
}
