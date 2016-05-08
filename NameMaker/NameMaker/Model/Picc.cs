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
        public string uri { get; set; }
        public string barcode { get; set; }
        public DateTime insertDate { get; set; }
        public string insertCountry { get; set; }
        public string insertCity { get; set; }
        public string piccSide { get; set; }
        public string piccPosition { get; set; }

        public Picc(string piccName, double frenchSize, string uri, string barcode, DateTime insertDate, string insertCountry, string insertCity, string piccSide, string piccPosition)
        {
            this.piccName = piccName;
            this.frenchSize = frenchSize;
            this.uri = uri;
            this.barcode = barcode;
            this.insertDate = insertDate;
            this.insertCity = insertCity;
            this.insertCountry = insertCountry;
            this.piccSide = piccSide;
            this.piccPosition = piccPosition;
        }
    }
}