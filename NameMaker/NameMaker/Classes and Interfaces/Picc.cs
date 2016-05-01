using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NameMaker.Classes_and_Interfaces
{
    class Picc
    {
        public string piccName { get; set; }
        public double frenchSize { get; set; }

        public string barcode { get; set; }
        public DateTime insertDate { get; set; }
        public string insertCountry { get; set; }
        public string insertCity { get; set; }
        public string piccSide { get; set; }


        public Picc(string piccName, double frenchSize, string barcode, DateTime insertDate, string insertCountry, string insertCity, string piccSide)
        {
            this.piccName = piccName;
            this.frenchSize = frenchSize;

            if (barcode != null)
            {
                this.barcode = barcode;
            }

            if (insertDate != null)
            {
                this.insertDate = insertDate;
            }

            if (insertCity != null)
            {
                this.insertCity = insertCity;

            }

            if (insertCountry != null)
            {
                this.insertCountry = insertCountry;

            }

            if (piccSide != null)
            {
                this.piccSide = piccSide;

            }
        }
    }
}