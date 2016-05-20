using NameMaker.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using static NameMaker.Models.Picc;

namespace NameMaker.ModelViewController
{
    class CurrentPiccModelView : INotifyPropertyChanged
    {
        private Picc picc;
      
        public CurrentPiccModelView(Picc picc)
        {
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
            get { return picc.PiccModel.PiccName; }
            set
            {
                if (picc.PiccModel.PiccName != value)
                {
                    picc.PiccModel.PiccName = value;
                    OnPropertyChanged("PiccName");
                }
            }
        }

        /// <summary>
        /// Returns the image string for the current picc or sets a new image string to the related object
        /// </summary>
        public string ImageSource
        {
            get { return picc.PiccModel.PictureUri; }
            set
            {
                if (picc.PiccModel.PictureUri != value)
                {
                    picc.PiccModel.PictureUri = value;
                    OnPropertyChanged("ImageSource");
                }
            }
        }

        /// <summary>
        /// Returns the binded size or sets a new size to the related object
        /// </summary>
        public double FrenchSize
        {
            get { return picc.PiccModel.FrenchSize; }
            set
            {
                if (picc.PiccModel.FrenchSize != value)
                {
                    picc.PiccModel.FrenchSize = value;
                    OnPropertyChanged("FrenchSize");
                }
            }
        }

        /// <summary>
        /// Returns the binded date or sets a new date to the related object
        /// </summary>
        public DateTime InsertDate
        {
            get { return picc.InsertDate; }
            set
            {
                if (picc.InsertDate != value)
                {
                    picc.InsertDate = value;
                    OnPropertyChanged("InsertDate");
                }
            }
        }

        /// <summary>
        /// Returns the binded expiration date or sets a new date to the related object
        /// </summary>
        public DateTime RemovalDate
        {
            get { return picc.RemovalDate; }
            set
            {
                if (picc.RemovalDate != value)
                {
                    picc.RemovalDate = value;
                    OnPropertyChanged("RemovalDate");
                }
            }
        }

        public bool IsRemovalDateSet
        {
            get { return picc.IsNotActiveAnymore; }
            set
            {
                if (picc.IsNotActiveAnymore != value)
                {
                    picc.IsNotActiveAnymore = value;
                    OnPropertyChanged("IsRemovalDateSet");
                }
            }
        }

        /// <summary>
        /// Returns the binded picc position or sets a new picc position to the related object
        /// </summary>
        public PICCInsertPosition PiccPosition
        {
            get
            {
                return picc.InsertPosition; 
            }

            set
            {
                if (picc.InsertPosition != value)
                {
                    picc.InsertPosition = value;
                    OnPropertyChanged("PiccPosition");
                }
            }
        }

        /// <summary>
        /// Returns the binded picc side or sets a new picc side to the related object
        /// </summary>
        public PICCInsertSide PiccSide
        {
            get
            {
                return picc.InsertSide;
            }

            set
            {
                if (picc.InsertSide != value)
                {
                    picc.InsertSide = value;
                    OnPropertyChanged("PiccSide");
                }
            }
        }

        /// <summary>
        /// Returns the binded country or sets a new country to the related object
        /// </summary>
        public PICCInsertCountry InsertCountry
        {
            get
            {
                return picc.InsertCountry;
            }

            set
            {
                if (picc.InsertCountry != value)
                {
                    picc.InsertCountry = value;
                    OnPropertyChanged("InsertCountry");
                }
            }

        }

        /// <summary>
        /// Returns the binded city if "Ausland" or "Switzerland" is selected as country. Sets a new city to the related object.
        /// </summary>
        public string City
        {
            get
            {
                if (picc.InsertCountry != PICCInsertCountry.Undefined)
                {
                    return picc.InsertCity;
                }
                return "";
            }

            set
            {
                if (picc.InsertCity != value && picc.InsertCountry == PICCInsertCountry.Undefined)
                {
                    picc.InsertCity = value;
                    OnPropertyChanged("City");
                }
            }
        }

        //// <summary>
        //// Returns the binded city if "Schweiz" is selected as country.Sets a new city to the related object if "Schweiz is selected as country
        //// </summary>
        //public int CityCH
        //{
        //    get
        //    {
        //        int index = 0;
        //        foreach (string a in selectedPiccCity)
        //        {
        //            if (a == picc.InsertCity)
        //            {
        //                return index;
        //            }

        //            index++;
        //        }
        //        return 0;
        //    }
        //    set
        //    {
        //        if (picc.InsertCity != selectedPiccCity.ElementAt(value) && (picc.InsertCountry == PICCInsertCountry.Switzerland) && (selectedPiccCity.Contains(selectedPiccCity.ElementAt(value))))
        //        {
        //            picc.InsertCity = selectedPiccCity.ElementAt(value);
        //            OnPropertyChanged("CityCH");
        //        }

        //    }
        //}


        ///// <summary>
        ///// Returns the binded city if "Ausland" is selected as country. Sets a new city to the related object if "Ausland" is selected as country
        ///// </summary>
        //public string CityAbroad
        //{
        //    get
        //    {
        //        if (picc.InsertCountry == PICCInsertCountry.Abroad)
        //        {
        //            return picc.InsertCity;
        //        }
        //        return "";
        //    }

        //    set
        //    {
        //        if (picc.InsertCity != value && !(selectedPiccCity.Contains(value)) && picc.InsertCountry == PICCInsertCountry.Abroad)
        //        {
        //            picc.InsertCity = value;
        //            OnPropertyChanged("CityAbroad");
        //        }
        //    }
        //}
    }
}






