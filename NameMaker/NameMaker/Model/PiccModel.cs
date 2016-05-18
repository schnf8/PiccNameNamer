using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NameMaker.Model
{
    public class PiccModel
    {
        public string PiccName { get; set; }
        public double FrenchSize { get; set; }
        public string PictureUri { get; set; }
        public string Barcode { get; set; }
       
        public PiccModel(string piccName, double frenchSize, string pictureUri, string barcode) { 
            this.PiccName = piccName;
            this.FrenchSize = frenchSize;
            this.PictureUri = pictureUri;
            this.Barcode = barcode;
   
        }
    }
}

