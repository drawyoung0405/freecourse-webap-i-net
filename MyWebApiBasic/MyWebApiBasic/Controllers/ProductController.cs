using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyWebApiBasic.Services;

namespace MyWebApiBasic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IHangHoaRepository _hangHoaRepository;
        public ProductController(IHangHoaRepository hangHoaRepository) {
          _hangHoaRepository = hangHoaRepository;
        }


        [HttpGet]
        public IActionResult GetAllProduct(string search, double? from, double? to, string orderBy, int page = 1) { 
        
             try
            {
                var result = _hangHoaRepository.GetAll(search, from, to, orderBy, page);
                return Ok(result);
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
