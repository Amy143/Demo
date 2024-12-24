using EFCoreDemo.Model;
using Microsoft.EntityFrameworkCore;

namespace EFCoreDemo.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<StudentEntity> StudentsRegister { get; set; }
        //StudentsRegister is thetable name

    }
}
