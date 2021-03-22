using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace BCX_Api.Models
{
    public partial class BCXContext : DbContext
    {
        public BCXContext()
        {
        }

        public BCXContext(DbContextOptions<BCXContext> options)
            : base(options)
        {
        }

        public virtual DbSet<EmployeeTask> EmployeeTasks { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<RoleLevel> RoleLevels { get; set; }
        public virtual DbSet<Task> Tasks { get; set; }
        public virtual DbSet<Timesheet> Timesheets { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.\\;Database=BCX;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<EmployeeTask>(entity =>
            {
                entity.HasOne(d => d.Task)
                    .WithMany(p => p.EmployeeTasks)
                    .HasForeignKey(d => d.TaskId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EmployeeTasks_Tasks");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.EmployeeTasks)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EmployeeTasks_Users");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.Property(e => e.RoleName).IsUnicode(false);
            });

            modelBuilder.Entity<RoleLevel>(entity =>
            {
                entity.Property(e => e.LevelName).IsUnicode(false);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.RoleLevels)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RoleLevels_Roles");
            });

            modelBuilder.Entity<Task>(entity =>
            {
                entity.Property(e => e.TaskName).IsUnicode(false);
            });

            modelBuilder.Entity<Timesheet>(entity =>
            {
                entity.HasOne(d => d.EmployeeTask)
                    .WithMany(p => p.Timesheets)
                    .HasForeignKey(d => d.EmployeeTaskId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Timesheets_EmployeeTasks");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.FirstName).IsUnicode(false);

                entity.Property(e => e.LastName).IsUnicode(false);

                entity.Property(e => e.Password).IsUnicode(false);

                entity.Property(e => e.ProfilePicture).IsUnicode(false);

                entity.Property(e => e.UserName).IsUnicode(false);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Users_Roles");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
