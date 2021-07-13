using Microsoft.EntityFrameworkCore;
using ResourcePlacementAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResourcePlacementAPI.Context
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions<MyContext> options) : base(options)
        {

        }
        public DbSet<Participants> Participants { get; set; }
        public DbSet<Projects> Projects { get; set; }
        public DbSet<Skills> Skills { get; set; }
        public DbSet<Accounts> Accounts { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<Employees> Employees { get; set; }
        public DbSet<CustomerUsers> CustomerUsers { get; set; }
        public DbSet<AccountsRoles> AccountsRoles { get; set; }
        public DbSet<ParticipantsSkills> ParticipantsSkills { get; set; }
        public DbSet<ProjectsSkills> ProjectsSkills { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // relasi untuk Employee dan Account
            //              One to One
            modelBuilder.Entity<Employees>()
                 .HasOne(e => e.Accounts)
                 .WithOne(a => a.Employees)
                 .HasForeignKey<Accounts>(a => a.EmployeeId);

            modelBuilder.Entity<CustomerUsers>()
               .HasOne(a => a.Accounts)
               .WithOne(p => p.CustomerUsers)
               .HasForeignKey<Accounts>(p => p.CustomerUserId);

            //relasi untuk project dan participant
            //             Many to One
            modelBuilder.Entity<Projects>()
                .HasMany(p => p.Participants)
                .WithOne(edc => edc.Projects);

            //relasi untuk project dan customer user
            //             One to Many
            modelBuilder.Entity<Projects>()
               .HasOne(edc => edc.CustomerUsers)
               .WithMany(u => u.Projects);

            // relasi untuk Account dan Role
            //              Many to Many
            modelBuilder.Entity<AccountsRoles>()
                .HasKey(bc => new { bc.AccountId, bc.RolesId });
            modelBuilder.Entity<AccountsRoles>()
                .HasOne(bc => bc.Accounts)
                .WithMany(b => b.AccountsRoles)
                .HasForeignKey(bc => bc.AccountId);
            modelBuilder.Entity<AccountsRoles>()
                .HasOne(bc => bc.Roles)
                .WithMany(c => c.AccountsRoles)
                .HasForeignKey(bc => bc.RolesId);

            // relasi untuk Skill dan Participant
            //              Many to Many
            modelBuilder.Entity<ParticipantsSkills>()
                .HasKey(bc => new { bc.ParticipantsId, bc.SkillsId });
            modelBuilder.Entity<ParticipantsSkills>()
                .HasOne(bc => bc.Participants)
                .WithMany(b => b.ParticipantsSkills)
                .HasForeignKey(bc => bc.ParticipantsId);
            modelBuilder.Entity<ParticipantsSkills>()
                .HasOne(bc => bc.Skills)
                .WithMany(c => c.ParticipantsSkills)
                .HasForeignKey(bc => bc.SkillsId);

            // relasi untuk Skill dan Participant
            //              Many to Many
            modelBuilder.Entity<ProjectsSkills>()
                .HasKey(bc => new { bc.ProjectsId, bc.SkillsId });
            modelBuilder.Entity<ProjectsSkills>()
                .HasOne(bc => bc.Projects)
                .WithMany(b => b.ProjectsSkills)
                .HasForeignKey(bc => bc.ProjectsId);
            modelBuilder.Entity<ProjectsSkills>()
                .HasOne(bc => bc.Skills)
                .WithMany(c => c.ProjectsSkills)
                .HasForeignKey(bc => bc.SkillsId);
        }
    }
}
