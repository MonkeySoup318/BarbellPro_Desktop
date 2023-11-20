using BarbellPro.Application.Models.Enums;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace BarbellPro.Application.Models.Services
{
    /// <summary>
    /// Handles the image import and property management
    /// </summary>
    public class ImageManagerService : JsonParserService
    {
        private readonly Dictionary<Images, ImageSource> imageSource = new();

        public static ImageSource LoadAppIconImage()
        {
            var appIconImage = new BitmapImage();
            appIconImage.BeginInit();
            appIconImage.UriSource = new Uri(FilePathManagerModel.AppIconImagePath, UriKind.RelativeOrAbsolute);
            appIconImage.EndInit();

            return appIconImage;
        }

        public void LoadBumberPlateImages()
        {
            string xamlContent = File.ReadAllText(FilePathManagerModel.CalculatorImagesPath);
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

        public Image GetImageFromDictionary(Images key)
        {
            Image image = new()
            {
                Source = imageSource[key]
            };
            SetBumperPlateImageProperties(image, key);

            return image;
        }

        private void SetBumperPlateImageProperties(Image image, Images key)
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