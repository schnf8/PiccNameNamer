using NameMaker.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace NameMaker.ModelViewController
{
    class CurrentPiccModelView : INotifyPropertyChanged
    {
        private Picc picc;
        private List<String> selectedPiccSide = new List<string>();
        private List<String> selectedPiccPosition = new List<string>();
        private List<String> selectedPiccCountry = new List<string>();
        private List<String> selectedPiccCity = new List<string>();


        public CurrentPiccModelView(Picc picc)
        {
            // Add all possible picker (piccside, piccposition, country, city CH) options to the lists
            selectedPiccSide.Add("");
            selectedPiccSide.Add("Rechts");
            selectedPiccSide.Add("Links");

            selectedPiccPosition.Add("");
            selectedPiccPosition.Add("Oberhalb Ellbogen");
            selectedPiccPosition.Add("Unterhalb Ellbogen");

            selectedPiccCity.Add("");
            selectedPiccCity.Add("Inselspital Bern");
            selectedPiccCity.Add("UniversitätsSpital Zürich");
            selectedPiccCity.Add("Universitätsspital Basel");
            selectedPiccCity.Add("Universitätsspital Genf");
            selectedPiccCity.Add("Andere Einrichtung");

            selectedPiccCountry.Add("");
            selectedPiccCountry.Add("Schweiz");
            selectedPiccCountry.Add("Ausland");

            this.picc = picc;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Checks if a binded property has been changed and fires the event
        /// </summary>
        /// <param name="propertyname"></param>
        protected internal void OnPropertyChanged(string propertyname)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
            }
        }

        /// <summary>
        /// Returns the binded name or sets a new name to the related object
        /// </summary>
        public string PiccName
        {
            get { return picc.piccName; }
            set
            {
                if (picc.piccName != value)
                {
                    picc.piccName = value;
                    OnPropertyChanged("PiccName");
                }
            }
        }

        /// <summary>
        /// Returns the image string for the current picc or sets a new image string to the related object
        /// </summary>
        public string ImageSource
        {
            get { return picc.uri; }
            set
            {
                if (picc.uri != value)
                {
                    picc.uri = value;
                    OnPropertyChanged("ImageSource");
                }
            }
        }

        /// <summary>
        /// Returns the binded size or sets a new size to the related object
        /// </summary>
        public double FrenchSize
        {
            get { return picc.frenchSize; }
            set
            {
                if (picc.frenchSize != value)
                {
                    picc.frenchSize = value;
                    OnPropertyChanged("FrenchSize");
                }
            }
        }

        /// <summary>
        /// Returns the binded date or sets a new date to the related object
        /// </summary>
        public DateTime InsertDate
        {
            get { return picc.insertDate; }
            set
            {
                if (picc.insertDate != value)
                {
                    picc.insertDate = value;
                    OnPropertyChanged("InsertDate");
                }
            }
        }

        /// <summary>
        /// Returns the binded picc position or sets a new picc position to the related object
        /// </summary>
        public int PiccPosition
        {
            get
            {
                int index = 0;
                foreach (string a in selectedPiccPosition)
                {

                    if (a == picc.piccPosition)
                    {
                        return index;
                    }
                    index++;

                }
                return 0;
            }

            set
            {
                if (picc.piccPosition != selectedPiccPosition.ElementAt(value))
                {
                    picc.piccPosition = selectedPiccPosition.ElementAt(value);
                    OnPropertyChanged("PiccPosition");
                }
            }
        }

        /// <summary>
        /// Returns the binded picc side or sets a new picc side to the related object
        /// </summary>
        public int PiccSide
        {
            get
            {
                int index = 0;
                foreach (string a in selectedPiccSide)
                {

                    if (a == picc.piccSide)
                    {
                        return index;
                    }
                    index++;

                }
                return 0;
            }

            set
            {
                if (picc.piccSide != selectedPiccSide.ElementAt(value))
                {
                    picc.piccSide = selectedPiccSide.ElementAt(value);
                    OnPropertyChanged("PiccSide");
                }
            }
        }

        /// <summary>
        /// Returns the binded country or sets a new country to the related object
        /// </summary>
        public int InsertCountry
        {
            get
            {
                int index = 0;
                foreach (string a in selectedPiccCountry)
                {
                    if (a == picc.insertCountry)
                    {
                        return index;
                    }

                    index++;
                }
                return 0;
            }

            set
            {
                if (picc.insertCountry != selectedPiccCountry.ElementAt(value))

                    picc.insertCountry = selectedPiccCountry.ElementAt(value);
                OnPropertyChanged("InsertCountry");
            }

        }

        // <summary>
        // Returns the binded city if "Schweiz" is selected as country.Sets a new city to the related object if "Schweiz is selected as country
        // </summary>
        public int CityCH
        {
            get
            {
                int index = 0;
                foreach (string a in selectedPiccCity)
                {
                    if (a == picc.insertCity)
                    {
                        return index;
                    }

                    index++;
                }
                return 0;
            }
            set
            {
                if (picc.insertCity != selectedPiccCity.ElementAt(value) && (picc.insertCountry == "Schweiz") && (selectedPiccCity.Contains(selectedPiccCity.ElementAt(value))))
                {
                    picc.insertCity = selectedPiccCity.ElementAt(value);
                    OnPropertyChanged("CityCH");
                }

            }
        }


        /// <summary>
        /// Returns the binded city if "Ausland" is selected as country. Sets a new city to the related object if "Ausland" is selected as country
        /// </summary>
        public string CityAbroad
        {
            get
            {
                if (picc.insertCountry == "Ausland")
                {
                    return picc.insertCity;
                }
                return "";
            }

            set
            {
                if (picc.insertCity != value && !(selectedPiccCity.Contains(value)) && picc.insertCountry == "Ausland")
                {
                    picc.insertCity = value;
                    OnPropertyChanged("CityAbroad");
                }
            }
        }
    }
}






