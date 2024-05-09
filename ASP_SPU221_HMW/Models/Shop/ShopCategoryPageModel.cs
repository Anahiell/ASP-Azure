using ASP_SPU221_HMW.Data.Entities;

namespace ASP_SPU221_HMW.Models.Shop
{
    public class ShopCategoryPageModel
    {
        public String Slug { get; set; } = null!;
        public Category Category { get; set; }
        public List<Product> Products { get; set; } = null !;
    }
}
