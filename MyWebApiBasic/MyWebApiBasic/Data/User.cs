using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MyWebApiBasic.Data
{

    [Table("User")]
    public class User
        {
            [Key]
            public int Id { get; set; }
            [Required]
            [MaxLength(50)]
            public string UserName { get; set; }
            [Required]
            [MaxLength(250)]
            public string Password { get; set; }
            public string HoTen { get; set; }
            public string Email { get; set; }

        }
    }

