using milesmorales_mvc.Models;

namespace milesmorales_mvc.Repository
{
    public class ColorRepository : IColorRepository
    {
        private readonly MilesmoralesDBContextcs milescontext;

        public ColorRepository(MilesmoralesDBContextcs milescontext)
        {
            this.milescontext = milescontext;
        }

        public List<Color> GetColors()
        {
            return this.milescontext.Colors.ToList();
        }

        public Color? GetColorById(int colorId)
        {
            return this.milescontext.Colors.FirstOrDefault(color => color.ColorId == colorId);
        }

        public void CreateColor(Color color)
        {
            this.milescontext.Colors.Add(color);
            this.milescontext.SaveChanges();
        }

        public void UpdateColor(Color color)
        {
            this.milescontext.Colors.Update(color);
            this.milescontext.SaveChanges();
        }

        public void DeleteColor(Color color)
        {
            this.milescontext.Colors.Remove(color);
            this.milescontext.SaveChanges();
        }
    }
}
