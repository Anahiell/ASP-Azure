using Microsoft.AspNetCore.Mvc;

namespace ASP_SPU221_HMW.Models.Shop
{
    public class ShopProductFormModel
    {
        [FromForm(Name = "category-id")]
        public Guid CategoryId { get; set; }

        [FromForm(Name = "product-name")]
        public string? Name { get; set; }

        [FromForm(Name = "product-price")]
        public double Price { get; set; }

        [FromForm(Name = "product-description")]
        public string? Description { get; set; }

        [FromForm(Name = "product-image")]
        public IFormFile? Image { get; set; }

        public Dictionary<string, string> ToParams()
        {
            return new Dictionary<string, string>
            {
                { "category-id", CategoryId.ToString() ?? "null" },
                { "product-name", Name ?? "null" },
                { "product-description", Description ?? "null" },
                { "product-price", Price.ToString() ?? "null" },
                { "product-image", Image?.FileName ?? "null" }
            };
        }
    }
}