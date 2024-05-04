using ASP_SPU221_HMW.Data.Dal;
using ASP_SPU221_HMW.Models.Rest;
using ASP_SPU221_HMW.Models.Shop;
using ASP_SPU221_HMW.Services.Upload;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ASP_SPU221_HMW.Controllers
{
    [Route("api/shop")]
    [ApiController]
    public class ShopApiController(DataAccessor dataAccessor, IUploadService uploadService, ILogger<ShopApiController> logger = null) : ControllerBase
    {
        private readonly IUploadService _uploadService = uploadService;
        private readonly DataAccessor _dataAccessor = dataAccessor;
        private readonly ILogger<ShopApiController> _logger = logger;

        [HttpGet("category")]
        public RestResponse GetCategory()
        {
            var res = _dataAccessor.ShopDao.GetCategories();
            return new RestResponse
            {
                Status = new()
                {
                    Code = StatusCodes.Status200OK,
                    Message = "OK",
                    IsOK = true
                },
                Meta = new()
                {
                    Service = "/api/shop/category",
                    ServerTime = DateTime.Now.Ticks,
                    Total = res.Count
                },

                Data = res
            };
        }
        [HttpPost("category")]
        public RestResponse DoPost(ShopCategoryFormModel? model)
        {
            RestResponse restResponse = new()
            {
                Meta = new()
                {
                    Service = "/api/shop/category",
                    ServerTime = DateTime.Now.Ticks,
                    ReguestParameters = model?.ToParams() ?? []
                }
            };
            _logger.LogInformation(String.Join(',', restResponse.Meta.ReguestParameters.Values));
            if (String.IsNullOrEmpty(model?.Slug) ||
                String.IsNullOrEmpty(model?.Name) ||
                String.IsNullOrEmpty(model?.Description))
            {
                restResponse.Status = new()
                {
                    Code = StatusCodes.Status422UnprocessableEntity,
                    Message = "ok",
                    IsOK = false

                };
                return restResponse;
            }
            else
            {
                try
                {
                    var category = _dataAccessor.ShopDao.AddCategory(
                        name: model.Name,
                        slug: model.Slug,
                    description: model.Description,
                        imageUrl: _uploadService.SaveFormFile(model.Image, "wwwroot/img/shop")
                        );
                    restResponse.Status = new()
                    {
                        Code = StatusCodes.Status201Created,
                        Message = "Missing required data",
                        IsOK = true

                    };
                    restResponse.Data = category;
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex.Message);
                    restResponse.Status = new()
                    {
                        Code = StatusCodes.Status500InternalServerError,
                        Message = "Server error. Details in logs",
                        IsOK = false
                    };
                }
                return restResponse;
            }
        }
    }
}
