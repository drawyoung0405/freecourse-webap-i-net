using Microsoft.EntityFrameworkCore;

namespace MyWebApiBasic.Data
{
    public class MyDBContext:DbContext
    {
        public MyDBContext(DbContextOptions options): base(options) {
        
        }

        #region DbSet
        public DbSet<HangHoa> HangHoas { get; set;}
        public DbSet<Loai> Loais { get; set;}
        #endregion
    }
}
