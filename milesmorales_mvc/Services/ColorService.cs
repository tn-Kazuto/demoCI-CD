using milesmorales_mvc.Models;
using milesmorales_mvc.Repository;

namespace milesmorales_mvc.Services
{
    public class ColorService : IColorService
    {
        private readonly IColorRepository colorRepository;

        public ColorService(IColorRepository colorRepository)
        {
            this.colorRepository = colorRepository;
        }

        public List<Color> GetColors()
        {
            return colorRepository.GetColors();
        }

        public Color? GetColorById(int id)
        {
            return colorRepository.GetColorById(id);
        }

        public void CreateColor(Color color)
        {
            colorRepository.CreateColor(color);
        }

        public bool UpdateColor(Color color)
        {
            var existingColor = colorRepository.GetColorById(color.ColorId);
            if (existingColor == null)
            {
                return false;
            }

            existingColor.ColorName = color.ColorName;
            existingColor.ColorHex = color.ColorHex;

            colorRepository.UpdateColor(existingColor);
            return true;
        }

        public bool DeleteColor(int id)
        {
            var color = colorRepository.GetColorById(id);
            if (color == null)
            {
                return false;
            }

            colorRepository.DeleteColor(color);
            return true;
        }
    }
}
