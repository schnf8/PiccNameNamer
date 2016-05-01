using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NameMaker.Classes_and_Interfaces
{
    public class TextElement : KnowledgeEntryElement
    {
        string text;

        public TextElement(string aText)
        {
            text = aText;
        }

        object KnowledgeEntryElement.element
        {
            get
            {
                return text; 
            }
        }

        string KnowledgeEntryElement.type
        {
            get
            {
                return "text";
            }
        }
    }
}
