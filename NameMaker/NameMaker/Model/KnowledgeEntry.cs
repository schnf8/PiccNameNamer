using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NameMaker.Models
{
    public class KnowledgeEntry
    {
        public string title { get; }
        public List<KnowledgeEntryElement> knowledgeElements { get; }
        public List<GlossaryEntry> glossaryEntries { get; }

        public KnowledgeEntry(string aTitle, List<KnowledgeEntryElement> theseKnowledgeElements, List<GlossaryEntry> theseGlossaryEntries)
        {
            title = aTitle;
            knowledgeElements = theseKnowledgeElements;
            glossaryEntries = theseGlossaryEntries;
        }

       
    }
}
