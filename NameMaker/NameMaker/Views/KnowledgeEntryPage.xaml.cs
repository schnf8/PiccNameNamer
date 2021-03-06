﻿using NameMaker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace NameMaker.Views
{
    public partial class KnowledgeEntryPage : ContentPage
    {
        public KnowledgeEntryPage(KnowledgeEntry selectedEntry)
        {
            InitializeComponent();
            addPageElements(selectedEntry);
            // TitleProperty.PropertyName.Replace("test", selectedEntry.title);
        }

        void OnSelect(object sender, EventArgs e)
        {
            //   Checks if the GlossaryList.SelectetItem value is null(value will be null after the following "if" statement).
            if (GlossaryList.SelectedItem != null)
            {

                // Casts the selected object to a glossary entry and moves forward to the glossary page
                GlossaryEntry selectedEntry = (GlossaryEntry)GlossaryList.SelectedItem;
                Navigation.PushAsync(new GlossaryPage(selectedEntry));
                GlossaryList.SelectedItem = null;
            }
        }

        // this method adds all the needed knowledge elements to the correct position
        private void addPageElements(KnowledgeEntry selectedEntry)
        {
            {
                //Adds the glossary entries to the realted list
                GlossaryList.ItemsSource = selectedEntry.glossaryEntries;

                //the index variable adds the knowledgeElement to its particular position
                int index = 0;

                //check if the element is either a text or an image
                foreach (var entry in selectedEntry.knowledgeElements)
                {
                    if (entry.type == "text")
                    {

                        KnowledgeEntryPageLayout.Children.Insert(index, (new Label
                        {
                            Text = (string)entry.element
                        }));

                        index++;

                    }
                    else if (entry.type == "image")
                    {

                        Image currentImage = (Image)entry.element;
                        currentImage.Aspect = Aspect.AspectFit;
                        currentImage.HeightRequest = 300;
                        currentImage.WidthRequest = 150;

                        addTabGestureRecognizerToImage(entry);
                        KnowledgeEntryPageLayout.Children.Insert(index, currentImage);
                        index++;

                        //Checks if a caption is set. If yes, a new label for the caption will be generated
                        ImageElement imgElem = (ImageElement)entry;
                        if (imgElem.caption != null)
                        {
                            KnowledgeEntryPageLayout.Children.Insert(index, (new Label
                            {
                                Text = imgElem.caption,
                                HorizontalTextAlignment = TextAlignment.Center

                            }));
                            index++;
                        }

                    }
                }
            }
        }

        //this method adds a gesture reognizer to an image. If the image is touched, it will be displayed in it's real size on a new page
        private void addTabGestureRecognizerToImage(KnowledgeEntryElement imageElem)
        {

            // Adds a Gesture Regognizer to link a word with the glossary
            TapGestureRecognizer tapGesture = new TapGestureRecognizer();
            tapGesture.Tapped += (s, e) =>
            {


                if (imageElem != null)
                {
                    Navigation.PushAsync(new PicturePage((ImageElement)imageElem));
                }

            };

            Image image = (Image)imageElem.element;

            image.GestureRecognizers.Add(tapGesture);
        }
    }
}


