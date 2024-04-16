using EmployeesServer.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeesServer.Data
{
    public class DataContext:DbContext
    {
        public DbSet<Employee> Employee { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<EmployeeRoles> EmployeeRoles { get; set; }
        private readonly IConfiguration _configuration;

        public DataContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EmployeeRoles>()
            .HasKey(jc => new { jc.EmployeeId, jc.RoleId });
            //modelBuilder.Entity<EmployeeRoles>()
            //.HasOne(jc => jc.Employee)
            //.WithMany(fc => fc.EmployeeRoles)
            //.HasForeignKey(jc => jc.EmployeeId);
            //modelBuilder.Entity<EmployeeRoles>()
            //.HasOne(jc => jc.Role)
            //.WithMany(sc => sc.EmployeeRoles)
            //.HasForeignKey(jc => jc.RoleId);
        }

       

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_configuration["DbConnectionString"]);
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //   // optionsBuilder.UseLazyLoadingProxies();
        //    optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=employeesR_db");
        //}
    }
}
