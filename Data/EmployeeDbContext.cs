using EmpManagement.Data.Model;
using Microsoft.EntityFrameworkCore;

namespace EmpManagement.Data
{
    public class EmployeeDbContext : DbContext
    {
        public EmployeeDbContext(DbContextOptions options):base(options)
        {

        }
        public DbSet<Employee> Employees { get; set; }
    }
}
