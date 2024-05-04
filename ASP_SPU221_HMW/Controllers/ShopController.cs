using ASP_SPU221_HMW.Data.Dal;
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
    }
}
