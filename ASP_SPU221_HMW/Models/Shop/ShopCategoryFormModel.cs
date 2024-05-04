using Microsoft.AspNetCore.Mvc;

namespace ASP_SPU221_HMW.Models.Shop
{
    public class ShopCategoryFormModel
    {
        [FromForm(Name = "category-slug")]
        public string? Slug { get; set; }
        [FromForm(Name = "category-name")]
        public string? Name { get; set; }
        [FromForm(Name = "category-description")]

        public string? Description { get; set; }
        [FromForm(Name = "category-image")]
        public IFormFile? Image { get; set; }
        public Dictionary<string, string> ToParams() => new()
        {
            {"category-name", Name ?? "null"},
            {"category-description", Description ?? "null"},
            {"category-slug", Slug ?? "null" },
            {"category-image", Image?.FileName ?? "null"}
        };
    }
}
