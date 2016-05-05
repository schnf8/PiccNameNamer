using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace NameMaker.Models
{
    class Picc
    {
        public string piccName { get; set; }
        public double frenchSize { get; set; }

        public string barcode { get; set; }
        public DateTime insertDate { get; set; }
        // 1 is for Switzerland, 2 for abroad
        public int insertCountry { get; set; }
        public string insertCity { get; set; }
        public int piccSide { get; set; }


        public Picc(string piccName, double frenchSize, string barcode, DateTime insertDate, int insertCountry, string insertCity, int piccSide)
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

            if (insertCountry != 0)
            {
                this.insertCountry = insertCountry;

            }

            if (piccSide != 0)
            {
                this.piccSide = piccSide;

            }
        }
    }
}