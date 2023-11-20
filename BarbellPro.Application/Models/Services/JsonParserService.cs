using BarbellPro.Application.Models.Enums;
using BarbellPro.Application.Models.Interfaces;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace BarbellPro.Application.Models.Services
{
    public class JsonParserService : IJsonParser
    {
        public Dictionary<Images, ImagePropertiesModel>? ParseImageProperties()
        {
            string fullPath = FilePathManagerModel.ImagePropertiesPath;
            string json = File.ReadAllText(fullPath);
            var result = JsonConvert.DeserializeObject<Dictionary<Images, ImagePropertiesModel>>(json);

            return result;
        }
    }
}
