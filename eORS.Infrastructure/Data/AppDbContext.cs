using Microsoft.EntityFrameworkCore;
using eORS.Domain.Entities;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace eORS.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        // DbSet Tanımlamaları
        public DbSet<Company> Companies { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<TeacherSchedule> TeacherSchedules { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Fluent API ile İlişki ve Kısıtlamaları Tanımlama
            modelBuilder.Entity<Teacher>()
                .HasOne(t => t.Company)
                .WithMany(c => c.Teachers)
                .HasForeignKey(t => t.CompanyId);

            modelBuilder.Entity<Student>()
                .HasOne(s => s.Company)
                .WithMany(c => c.Students)
                .HasForeignKey(s => s.CompanyId);

            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.Student)
                .WithMany(s => s.Appointments)
                .HasForeignKey(a => a.StudentId);

            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.Teacher)
                .WithMany(t => t.Appointments)
                .HasForeignKey(a => a.TeacherId);

            modelBuilder.Entity<TeacherSchedule>()
                .HasOne(ts => ts.Teacher)
                .WithMany(t => t.Schedules)
                .HasForeignKey(ts => ts.TeacherId);
        }
    }
}
