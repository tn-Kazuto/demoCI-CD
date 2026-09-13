using milesmorales_mvc.Models;

namespace milesmorales_mvc.Repository
{
    public interface IColorRepository
    {
        List<Color> GetColors();
        Color? GetColorById(int colorId);
        void CreateColor(Color color);
        void UpdateColor(Color color);
        void DeleteColor(Color color);
    }
}
