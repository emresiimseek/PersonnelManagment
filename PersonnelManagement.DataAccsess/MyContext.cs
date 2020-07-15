using Microsoft.EntityFrameworkCore;
using PersonnelManagement.DataAccsess.Configurations;
using PersonnelManagement.DataAccsess.Seeds;
using PersonnelManagement.EntityFramework.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace PersonnelManagement.DataAccsess
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions<MyContext> options) : base(options)
        {
           
        }

        public DbSet<Personnel> Personnels { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<JobRoles> jobRoles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Personnel>()
                 .HasOne<Department>(p => p.Department)
                 .WithMany(d => d.Personnels)
                 .HasForeignKey(p => p.DepartmentId);
            modelBuilder.Entity<Personnel>()
                .HasOne<Job>(j => j.Job)
                .WithMany(p => p.Personnels)
                .HasForeignKey(p => p.JobId);
            modelBuilder.Entity<JobRoles>().HasKey(jr => new { jr.JobId, jr.RoleId});


            modelBuilder.ApplyConfiguration(new DepartmentConfiguration());
            modelBuilder.ApplyConfiguration(new PersonnelConfiguration());
            modelBuilder.ApplyConfiguration(new JobConfiguration());
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new JobRolesConfiguration());
            modelBuilder.ApplyConfiguration(new DepartmentSeed());
            modelBuilder.ApplyConfiguration(new JobRolesSeed());
            modelBuilder.ApplyConfiguration(new JobSeed());
            modelBuilder.ApplyConfiguration(new PersonnelSeed());
            modelBuilder.ApplyConfiguration(new RoleSeed());

        }


    }
}
