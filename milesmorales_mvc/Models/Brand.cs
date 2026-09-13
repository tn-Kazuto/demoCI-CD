namespace milesmorales_mvc.Models
{
    public class Brand
    {
        public int BrandId { get; set; }

        public string BrandName { get; set; } = string.Empty;

        public Brand(int brandId, string brandName)
        {
            BrandId = brandId;
            BrandName = brandName;
        }

        public Brand() {  }
    }
}
