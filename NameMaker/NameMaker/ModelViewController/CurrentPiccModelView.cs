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

        public CurrentPiccModelView(Picc picc)
        {
            this.picc = picc;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected internal void OnPropertyChanged(string propertyname)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
            }
        }

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

        public int PiccSide
        {
            get { return picc.piccSide; }
            set
            {
                if (picc.piccSide != value)
                {
                    picc.piccSide = value;
                    OnPropertyChanged("PiccSide");
                }
            }
        }

        public int InsertCountry
        {
            get { return picc.insertCountry; }
            set
            {
                if (picc.insertCountry != value)
                {
                    picc.insertCountry = value;
                    OnPropertyChanged("InsertCountry");
                }
            }
        }
    }
    
}
