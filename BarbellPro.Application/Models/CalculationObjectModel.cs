using BarbellPro.Application.Models.Enums;

namespace BarbellPro.Application.Models
{
    public class CalculationObjectModel
    {
        public Gender Gender { get; set; }
        public int Weight { get; set; }
        public bool HasClip { get; set; }
    }
}
