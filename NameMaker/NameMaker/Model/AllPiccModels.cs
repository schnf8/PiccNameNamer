using NameMaker.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace NameMaker.Models
{
    class AllPiccModels
    {
        private static List<PiccModel> piccList;

        private AllPiccModels() { }

        public static List<PiccModel> getModels()
        {
                        
            if (piccList == null)
            {
                piccList = new List<PiccModel>();
                piccList.Add(new PiccModel("Einlumiger Picc", 3.4, "EinlumigerPICC.PNG", ""));
                piccList.Add(new PiccModel("Zweilumiger Picc", 3.9,"DoppellumigerPICC.PNG", ""));
                piccList.Add(new PiccModel("Dreilumiger Picc", 4.4, null, ""));

            }
            return piccList;

        }
    }
}
