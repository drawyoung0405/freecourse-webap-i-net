using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyWebApiBasic.Models;
using MyWebApiBasic.Services;

namespace MyWebApiBasic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoaisController : ControllerBase
    {
        private readonly ILoaiRepository _loaiRepository;
        public LoaisController(ILoaiRepository loaiRepository)
        {
            _loaiRepository = loaiRepository;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(_loaiRepository.GetAll());
            }
            catch
            {
                return BadRequest();
            }
        }



        [HttpGet("id")]
        public IActionResult GetById(int id)
        {
            try
            {
                var data = _loaiRepository.GetById(id);

                if (data != null)
                {
                    return Ok(data);
                }
                else
                {
                    return NotFound();
                }
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public IActionResult Add(LoaiModel loai)
        {
            try
            {
                return Ok(_loaiRepository.Add(loai));
            }
            catch
            {
                return BadRequest();
            }
        }


        [HttpPut("id")]
        public IActionResult Update(int Id, LoaiVM loaiVM)
        {
            if (Id != loaiVM.MaLoai)
            {
                return BadRequest();
            }
            try
            {
                _loaiRepository.Update(loaiVM);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }

        }

        [HttpDelete("id")]
        public IActionResult Delete(int id) { 
        try { 
                _loaiRepository.Delete(id);
            return Ok();
            }

            catch
            {
                return BadRequest();
            }
        }
    }
}
