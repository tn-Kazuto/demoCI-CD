using milesmorales_mvc.Models;

namespace milesmorales_mvc.Repository
{
    public class BrandRepository : IBrandRepository
    {
        private readonly MilesmoralesDBContextcs milescontext;

        public BrandRepository(MilesmoralesDBContextcs milescontext)
        {
            this.milescontext = milescontext;
        }

        public List<Brand> GetBrands()
        {
            return this.milescontext.Brands.ToList();
        }

        public Brand? GetBrandById(int brandId)
        {
            return this.milescontext.Brands.FirstOrDefault(brand => brand.BrandId == brandId);
        }

        public void CreateBrand(Brand brand)
        {
            this.milescontext.Brands.Add(brand);
            this.milescontext.SaveChanges();
        }

        public void UpdateBrand(Brand brand)
        {
            this.milescontext.Brands.Update(brand);
            this.milescontext.SaveChanges();
        }

        public void DeleteBrand(Brand brand)
        {
            this.milescontext.Brands.Remove(brand);
            this.milescontext.SaveChanges();
        }
    }
}
