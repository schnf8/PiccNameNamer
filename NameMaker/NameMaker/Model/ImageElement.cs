using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace NameMaker.Models
{
    public class ImageElement : KnowledgeEntryElement
    {
        Image source;
        public string caption { get; set; }

        // Constructor with an image and a caption element
        public ImageElement(Image aSource, string aCaption)
        {
            source = aSource;
            caption = aCaption;
        }

        // Constructor with only an image provided.
        public ImageElement(Image aSource)
        {
            source = aSource;
            
        }


        object KnowledgeEntryElement.element
        {
            get
            {
                return source;
            }
        }

        string KnowledgeEntryElement.type
        {
            get
            {
                return "image";
            }
        }
    }
}
