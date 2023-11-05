using BarbellPro.Application.Models.Enums;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Windows.Media;

namespace BarbellPro.Application.Models.Services
{
    public class ImageManagerService : JsonParserService
    {     
        private readonly string _imagePath = "C:\\Users\\ingam\\source\\repos\\BarbellPro\\BarbellPro.Application\\Resources\\Images.xaml";
        private readonly Dictionary<Images, ImageSource> imageSource = new();

        public void LoadImages()
        {
            string xamlContent = File.ReadAllText(_imagePath);
            ResourceDictionary resourceDictionary = (ResourceDictionary)XamlReader.Parse(xamlContent);
            imageSource.Add(Images._25kg, (DrawingImage)resourceDictionary["_25kg_rot_finiDrawingImage"]);
            imageSource.Add(Images._20kg, (DrawingImage)resourceDictionary["_20kg_blau_finiDrawingImage"]);
            imageSource.Add(Images._15kg, (DrawingImage)resourceDictionary["_15kg_gelb_finiDrawingImage"]);
            imageSource.Add(Images._10kg, (DrawingImage)resourceDictionary["_10kg_gru__n_finiDrawingImage"]);
            imageSource.Add(Images._5kg, (DrawingImage)resourceDictionary["_5kg_wei___finiDrawingImage"]);
            imageSource.Add(Images._2_5kg, (DrawingImage)resourceDictionary["_2_5kg_rot_finiDrawingImage"]);
            imageSource.Add(Images._2_0kg, (DrawingImage)resourceDictionary["_2_0kg_blau_finiDrawingImage"]);
            imageSource.Add(Images._1_5kg, (DrawingImage)resourceDictionary["_1_5kg_gelb_finiDrawingImage"]);
            imageSource.Add(Images._1_0kg, (DrawingImage)resourceDictionary["_1_0kg_gru__n_finiDrawingImage"]);
            imageSource.Add(Images._0_5kg, (DrawingImage)resourceDictionary["_0_5kg_wei___finiDrawingImage"]);
            imageSource.Add(Images._clip, (DrawingImage)resourceDictionary["verschluss_grau_finiDrawingImage"]);
            imageSource.Add(Images._barbell, (DrawingImage)resourceDictionary["leerestange_finiDrawingImage"]);
        }

        public Image GetImage(Images key)
        {
            Image image = new()
            {
                Source = imageSource[key]
            };
            SetImageProperties(image, key);

            return image;
        }

        private void SetImageProperties(Image image, Images key)
        {
            var imageProperty = ParseImageProperties()?.GetValueOrDefault(key);

            if (imageProperty != null)
            {
                image.Width = imageProperty.Width;
                image.Height = imageProperty.Height;

                if (Math.Abs(imageProperty.MarginTop) > 0.01)
                {
                    Thickness margin = image.Margin;
                    margin.Top = imageProperty.MarginTop;
                    image.Margin = margin;
                }

                if (imageProperty.Stretch != Stretch.None)
                    image.Stretch = imageProperty.Stretch;
            }
            else
                image.Stretch = Stretch.None;
        }
    }
}