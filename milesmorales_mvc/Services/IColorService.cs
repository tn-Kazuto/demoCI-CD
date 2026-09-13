using milesmorales_mvc.Models;

namespace milesmorales_mvc.Services
{
    public interface IColorService
    {
        List<Color> GetColors();
        Color? GetColorById(int id);
        void CreateColor(Color color);
        bool UpdateColor(Color color);
        bool DeleteColor(int id);
    }
}
