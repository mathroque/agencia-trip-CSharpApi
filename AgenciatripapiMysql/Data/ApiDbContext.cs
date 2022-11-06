using AgenciatripapiMysql.Models;
using Microsoft.EntityFrameworkCore;

namespace AgenciatripapiMysql.Data
{
    public class ApiDbContext : DbContext
    {
        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options)
        {

        }

        public DbSet<DestinoModel> Destino { get; set; }
    }
}
