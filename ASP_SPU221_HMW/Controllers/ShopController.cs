using ASP_SPU221_HMW.Data.Dal;
using ASP_SPU221_HMW.Data.Entities;
using ASP_SPU221_HMW.Models.Shop;
using Microsoft.AspNetCore.Mvc;

namespace ASP_SPU221_HMW.Controllers
{
    public class ShopController(DataAccessor dataAccessor) : Controller
    {
        private readonly DataAccessor _dataAccessor = dataAccessor;
        public IActionResult Index()
        {
            ViewData["Categories"] = _dataAccessor.ShopDao.GetCategories();
            return View();
        }
        public IActionResult Category([FromRoute] String id)
        {
            var model = new ShopCategoryPageModel
            {
                Slug = id,
                Category = _dataAccessor.ShopDao.GetCategoryBySlug(id),
                Products = _dataAccessor.ShopDao.GetProductsByCategoryId(_dataAccessor.ShopDao.GetCategoryBySlug(id))
            };

            ViewData["Categories"] = _dataAccessor.ShopDao.GetCategories();
            ViewData["Products"] = _dataAccessor.ShopDao.GetProductsByCategoryId(_dataAccessor.ShopDao.GetCategoryBySlug(id));

            return View(model);
        }
    }
}
