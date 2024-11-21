using Microsoft.EntityFrameworkCore;
using PT.Dasigno.DAL.Context.ContextDasigno.Entities;

namespace PT.Dasigno.DAL.Context.ContextDasigno
{
    public class dbContextDasigno : DbContext
    {
        public dbContextDasigno()
        { 
        }

        public dbContextDasigno(DbContextOptions<dbContextDasigno> options)
        : base(options)
        {
        }

        public DbSet<Users> Users { get; set; }
    }
}
