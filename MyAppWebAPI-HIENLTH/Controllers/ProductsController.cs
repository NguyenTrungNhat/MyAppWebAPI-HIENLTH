using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyAppWebAPI_HIENLTH.Services;

namespace MyAppWebAPI_HIENLTH.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IHangHoaReponsitory _hangHoaReponsitory;

        public ProductsController(IHangHoaReponsitory hangHoaReponsitory)
        {
            _hangHoaReponsitory = hangHoaReponsitory;
        }
        [HttpGet]
        public IActionResult GetAllProducts(string search, double? from, double? to
            ,string sortBy, int page = 1)
        {
            try
            {
                var result = _hangHoaReponsitory.GetAll(search, from, to, sortBy, page);
                return Ok(result);
            }
            catch
            {
                return BadRequest("We can't get product. ");
            }
        }
    }
}
