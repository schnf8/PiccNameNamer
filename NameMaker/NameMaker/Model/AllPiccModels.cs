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
        private static List<Picc> piccList;

        private AllPiccModels() { }

        public static List<Picc> getModels()
        {
                        
            if (piccList == null)
            {
                piccList = new List<Picc>();
                piccList.Add(new Picc("Einlumiger Picc", 3.4, null, DateTime.Today, 0, null, 0));
                piccList.Add(new Picc("Zweilumiger Picc", 3.9, null, DateTime.Today, 0, null, 0));
                piccList.Add(new Picc("Dreilumiger Picc", 4.4, null, DateTime.Today, 0, null, 0));

            }
            return piccList;

        }
    }
}
