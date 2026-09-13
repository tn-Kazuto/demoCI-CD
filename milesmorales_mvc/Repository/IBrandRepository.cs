using milesmorales_mvc.Models;

namespace milesmorales_mvc.Repository
{
    public interface IBrandRepository
    {
        List<Brand> GetBrands();
        Brand? GetBrandById(int brandId);
        void CreateBrand(Brand brand);
        void UpdateBrand(Brand brand);
        void DeleteBrand(Brand brand);
    }
}
