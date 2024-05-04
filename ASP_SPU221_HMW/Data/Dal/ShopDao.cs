using ASP_SPU221_HMW.Data.Context;
using ASP_SPU221_HMW.Data.Entities;

namespace ASP_SPU221_HMW.Data.Dal
{
    public class ShopDao(DataContext context, Object dbLocker)
    {
        private readonly DataContext _context = context;
        private readonly Object _dbLocker = dbLocker;

        public List<Category> GetCategories()
        {
            List<Category> res;
            lock (_dbLocker)
            {
                res = _context.Categories.Where(c => c.IsActive).ToList();
            }
            return res;
        }
        public Category AddCategory(String name, String slug, String description, String imageUrl)
        {
            Category category = new()
            {


                Name = name,
                Slug = slug,
                Description = description,
                ImageUrl = imageUrl,
                IsActive = true,
                Id = Guid.NewGuid()
            };
            return AddCategory(category);
        }
        public Category AddCategory(Category category)
        {
            lock (_dbLocker)
            {
                _context.Categories.Add(category);
                _context.SaveChanges();
            }
            return category;
        }
        public Product AddProduct(Guid categoryId, String name, Double price, String description, String imageUrl)
        {
            Product product = new()
            {
                Name = name,
                Price = price,
                Description = description,
                ImageUrl = imageUrl,
                CategoryId = categoryId,

                IsActive = true,
                Id = Guid.NewGuid()
            };
            return AddProduct(product);
        }
        public Product AddProduct(Product product)
        {
            lock (_dbLocker)
            {
                _context.Products.Add(product);
                _context.SaveChanges();
            }
            return product;
        }
    }
}
