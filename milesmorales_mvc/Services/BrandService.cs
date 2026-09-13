using milesmorales_mvc.Models;
using milesmorales_mvc.Repository;

namespace milesmorales_mvc.Services
{
    public class BrandService : IBrandService
    {
        private readonly IBrandRepository brandRepository;

        public BrandService(IBrandRepository brandRepository)
        {
            this.brandRepository = brandRepository;
        }

        public List<Brand> GetBrands()
        {
            return brandRepository.GetBrands();
        }

        public Brand? GetBrandById(int id)
        {
            return brandRepository.GetBrandById(id);
        }

        public void CreateBrand(Brand brand)
        {
            brandRepository.CreateBrand(brand);
        }

        public bool UpdateBrand(Brand brand)
        {
            var existingBrand = brandRepository.GetBrandById(brand.BrandId);
            if (existingBrand == null)
            {
                return false;
            }

            existingBrand.BrandName = brand.BrandName;

            brandRepository.UpdateBrand(existingBrand);
            return true;
        }

        public bool DeleteBrand(int id)
        {
            var brand = brandRepository.GetBrandById(id);
            if (brand == null)
            {
                return false;
            }

            brandRepository.DeleteBrand(brand);
            return true;
        }
    }
}
