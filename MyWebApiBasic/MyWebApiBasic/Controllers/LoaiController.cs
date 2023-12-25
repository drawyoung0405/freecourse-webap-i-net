using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyWebApiBasic.Data;
using MyWebApiBasic.Models;
using System.Linq;

namespace MyWebApiBasic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoaiController : ControllerBase
    {
        private readonly MyDBContext _context;
        public LoaiController(MyDBContext context) {
            _context = context;
        }
        [HttpGet]
        public IActionResult GetAllLoai() {
            var dsLoai = _context.Loais.ToList();
            return Ok(dsLoai);
        }
        [HttpGet("Id")]
        public IActionResult GetLoaiById(int Id)
        {
            var loai = _context.Loais.SingleOrDefault(lo => lo.MaLoai == Id);
            if(loai != null)
            {
                return Ok(loai);
            }
            else
            {
                return NotFound();
            }
        }


        [HttpPost]
        public IActionResult CreateLoai(LoaiModel model)
        {
            try
            {
                var loaiAdd = new Loai
                {
                    TenLoai = model.TenLoai
                };
                _context.Add(loaiAdd);
                _context.SaveChanges();
                return Ok();
            }
            catch
            {
                return BadRequest();
            }

        }



        [HttpPut("Id")]
        public IActionResult UpdateById(int Id, LoaiModel model)
        {
            var loai = _context.Loais.SingleOrDefault(lo => lo.MaLoai == Id);
            if (loai != null)
            {
                loai.TenLoai = model.TenLoai;
                _context.SaveChanges();
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }


        [HttpDelete("Id")]
        public IActionResult DeleteById(int Id)
        {
            var loai = _context.Loais.SingleOrDefault(lo => lo.MaLoai == Id);
            if (loai != null)
            {
                _context.Remove(loai);
                _context.SaveChanges();
                return Ok("Delete Thanh Cong");
            }
            else
            {
                return NotFound();
            }
        }
    }
}
