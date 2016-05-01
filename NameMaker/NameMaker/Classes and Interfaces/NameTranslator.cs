using NameMaker;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Core
{
    public static class NameTranslator
    {
        //Array with a given name to each character of the alphabeth
        static readonly Name[] firstnames = {
            new Name("Ada"), new Name("Beni"), new Name("Chrigi"), new Name("Denis"), new Name("Emil"), new Name("Flo"), new Name("Geri"),new Name("Hans"), new Name("Igor"), new Name("Jeanne"),
            new Name("Kusi"), new Name ("Lea"), new Name("Michu"),new Name("Noel"),new Name("Olaf"), new Name("Peter") ,new Name("Qina"), new Name("Raphael"), new Name("Simon"), new Name("Thom"), new Name("Ueli"),
            new Name("Valmir"), new Name("Wesna") ,new Name("Xenia"), new Name("Yasmin"),new Name("Zoo")
            };


        //This method translates each character of a given string to a full name which starts with the given characater
        public static List<Name> TranslateToName(string raw)
        {
            List<Name> displayedNames = new List<Name>();

            //makes sure that all characters are capital letters, so that they can be compared with the first capital letter of a name
            raw = raw.ToUpperInvariant();

            // loop over each character of a given string
            foreach (char c in raw)
            {
                // checks if a given character is equal to the first character of a name.
                // if yes, the name will be displayed.
                foreach (Name name in firstnames)
                {

                    if (name.DisplayName[0].Equals(c))
                    {
                        displayedNames.Add(name);
                    }

                }
            }

            return displayedNames;
        }
    }
}
