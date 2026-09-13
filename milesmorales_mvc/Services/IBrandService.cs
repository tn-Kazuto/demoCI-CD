using milesmorales_mvc.Models;

namespace milesmorales_mvc.Services
{
    public interface IBrandService
    {
        List<Brand> GetBrands();
        Brand? GetBrandById(int id);
        void CreateBrand(Brand brand);
        bool UpdateBrand(Brand brand);
        bool DeleteBrand(int id);
    }
}
