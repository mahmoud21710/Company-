using Company.G04.DAL.Data.Configrations;
using Company.G04.DAL.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Company.G04.DAL.Data.Contexts
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options ): base( options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);

          
        }
       
        public DbSet<Department>  Departments { get; set; }
        public DbSet<Employee>  Employees { get; set; }
        public DbSet<Dependent> Dependents { get; set; }
        public DbSet<Project> Projects { get; set; }

        //public DbSet<IdentityUser>  Users { get; set; }
        //public DbSet<IdentityRole> Roles { get; set; }

    }
}
