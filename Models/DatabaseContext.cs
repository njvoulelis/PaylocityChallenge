using  Microsoft.EntityFrameworkCore;

namespace PaylocityChallenge.Models
{
    public class MyContext: DbContext
    {
        public MyContext(DbContextOptions options) : base(options) { }

        public DbSet<Employee> Employees {get;set;}

        public DbSet<Dependent> Dependents {get;set;}
    }
}