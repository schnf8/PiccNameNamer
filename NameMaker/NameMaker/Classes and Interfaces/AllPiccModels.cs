using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NameMaker.Classes_and_Interfaces
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
                piccList.Add(new Picc("Einlumiger Picc", 3.4, null, new DateTime(), null, null, null));
                piccList.Add(new Picc("Zweilumiger Picc", 3.9, null, new DateTime(), null, null, null));
                piccList.Add(new Picc("Dreilumiger Picc", 4.4, null, new DateTime(), null, null, null));

            }
            return piccList;

        }
    }
}
