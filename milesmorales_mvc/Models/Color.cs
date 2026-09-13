using System.ComponentModel.DataAnnotations.Schema;

namespace milesmorales_mvc.Models
{
    [Table("Color")]
    public class Color
    {
        public int ColorId { get; set; }

        public string ColorName { get; set; } = string.Empty;

        public string ColorHex { get; set; } = string.Empty;

        public Color(int colorId, string colorName, string colorHex)
        {
            ColorId = colorId;
            ColorName = colorName;
            ColorHex = colorHex;
        }

        public Color()
        {
        }
    }
}
