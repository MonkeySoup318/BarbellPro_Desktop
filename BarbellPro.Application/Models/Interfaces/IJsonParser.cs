using BarbellPro.Application.Models.Enums;
using System.Collections.Generic;

namespace BarbellPro.Application.Models.Interfaces
{
    public interface IJsonParser
    {
        Dictionary<Images, ImagePropertiesModel>? ParseImageProperties();
    }
}
