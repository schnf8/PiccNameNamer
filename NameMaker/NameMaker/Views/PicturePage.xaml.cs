using NameMaker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace NameMaker.Views
{
    public partial class PicturePage : ContentPage
    {
        //Counts the tabs on the displayed image
        int tapCount = 1;

        public PicturePage(ImageElement source)
        {
            InitializeComponent();
            // Cast the ImageElemnt first to a KnowledgeEntryElement and cast its source to an Image
            SelectedImage.Source = ((Image)((KnowledgeEntryElement)source).element).Source;

            // Adds a Gesture Regognizer to the loaded picutre
            TapGestureRecognizer tapGesture = new TapGestureRecognizer();
            tapGesture.Tapped += (s, e) =>
            {   
                //Make sure that the PopAsync method is only called once
                if (tapCount == 1)
                {
                    Navigation.PopAsync();
                }

                tapCount++;
            };
            SelectedImage.GestureRecognizers.Add(tapGesture);

            // Checks if the ImageElement has a caption and add it to the label
            if (source.caption != null)
            {
                SelectedImageCaption.IsVisible = true;
                SelectedImageCaption.Text = source.caption;
            }

        }
    }
}
