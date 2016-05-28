using NameMaker.Model;
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
    class PiccModelModelView : INotifyPropertyChanged
    {

        private List<PiccModel> allPiccModels;

        public PiccModelModelView()
        {
            this.allPiccModels = AllPiccModels.getModels();
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
        /// Returns the binded PICC models or sets new list of models if needed.
        /// </summary>
        public List<PiccModel> PiccModels
        {
            get { return allPiccModels; }
            set
            {
                if (allPiccModels != value)
                {
                    allPiccModels = value;
                    OnPropertyChanged("PiccModels");
                }
            }
        }
    }
}




