using System;
using System.IO;

namespace BarbellPro.Application.Models
{
    public static class FilePathManagerModel
    {
        public static string CalculatorImagesPath => GetPath("Images.xaml");
        public static string AppIconImagePath => GetPath("AppIcon_2.png");
        public static string ImagePropertiesPath => GetPath("ImageProperties.json");

        private static string GetPath(string fileName)
        {
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", fileName);
            if (!File.Exists(path))
                throw new FileNotFoundException($"Missing file '{fileName}' could not be found.");
            return path;
        }
    }
}
