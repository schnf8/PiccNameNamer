using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NameMaker.Models
{
    public interface KnowledgeEntryElement
    {
        Object element { get;}
        string type { get; }
    }
}
