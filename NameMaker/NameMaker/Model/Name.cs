using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NameMaker
{
    public class Name
    {
        public string DisplayName { get; set; }

        public Name(string name)
        {
            DisplayName = name;
        }

        public override string ToString()
        {
            return DisplayName;
        }


    }
}
