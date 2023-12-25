using System.ComponentModel.DataAnnotations;

namespace MyWebApiBasic.Models
{
    public class LoaiModel
    {
        [Required]
        public string TenLoai { get; set; }
    }
}
