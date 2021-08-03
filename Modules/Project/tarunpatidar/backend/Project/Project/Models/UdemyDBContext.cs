using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Project.Models.Authentication;

#nullable disable

namespace Project.Models
{
    public partial class UdemyDBContext : IdentityDbContext<ApplicationUser>
    {
        public UdemyDBContext()
        {
        }

        public UdemyDBContext(DbContextOptions<UdemyDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Courses> Courses { get; set; }
        public virtual DbSet<Fees> Fees { get; set; }
        public virtual DbSet<Schedule> Schedule { get; set; }
        public virtual DbSet<Student> Student { get; set; }
        public virtual DbSet<AppUser> AppUsers { get; set; }


       // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
           // optionsBuilder.UseSqlServer("Server=DESKTOP-4KO4R8R\\SQLEXPRESS03;Database=Udemy;Trusted_Connection=True;");
            //            if (!optionsBuilder.IsConfigured)
            //            {
            //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
            //               
            //            }
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AI");

            modelBuilder.Entity<AppUser>(entity =>
            {
                entity.HasKey(e => e.UserId);
                entity.Property(e => e.UserId).HasColumnName("UserID");
                entity.Property(e => e.AboutUser).HasMaxLength(200);
                entity.Property(e => e.FullName)
                .IsRequired()
                .HasMaxLength(30);

                entity.Property(e => e.GitHub).HasMaxLength(100);
                entity.Property(e => e.LastSeen).HasColumnName("datetime");
                entity.Property(e => e.Location).HasMaxLength(50);
                entity.Property(e => e.Title).HasMaxLength(20);
                entity.Property(e => e.Twitter).HasMaxLength(100);
            });


            modelBuilder.Entity<Courses>(entity =>
            {
                entity.HasIndex(e => e.UserId, "IX_Courses_UserID");

                entity.HasKey(e => e.CourseId)
                      .HasName("PKCourseID");
                
                entity.Property(e => e.CourseId)
                    .HasColumnName("CourseID");

                entity.Property(e => e.CourseDescription)
                    .IsRequired()
                    .IsUnicode(false)
                    .HasMaxLength(30)
                    .HasColumnName("coursedescription");

                entity.Property(e => e.CourseName)
                    .IsRequired()
                    .IsUnicode(false)
                    .HasMaxLength(100)
                    .HasColumnName("coursename");

                entity.Property(e => e.Course1)
                .HasMaxLength(500)
                .HasColumnName("Courses");

                entity.Property(e => e.CourseType)
                    .HasColumnType("coursetype");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.User)
                .WithMany(p => p.Courses)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_UserIDCourses");
            });

            modelBuilder.Entity<Fees>(entity =>
            {
                entity.HasIndex(e => e.UserId, "IX_Fees_UserID");

                entity.HasKey(e => e.FeeID)
                      .HasName("PKFeeID");

                entity.Property(e => e.FeeID)
                    .HasColumnName("FeeID");

                entity.Property(e => e.FeeType).HasColumnName("feetype");

                entity.Property(e => e.FeeDescription)
                    .IsRequired()
                    .IsUnicode(false)
                    .HasMaxLength(100)
                    .HasColumnName("feedescription");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.User)
                .WithMany(p => p.Fees)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_UserIDFees");
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.HasIndex(e => e.UserId, "IX_Student_UserID");

                entity.HasKey(e => e.StuID)
                      .HasName("PKStuID");

                entity.Property(e => e.StuID).HasColumnName("stuid");

                entity.Property(e => e.StuName)
                    .IsRequired()
                    .IsUnicode(false)
                    .HasMaxLength(100)
                    .HasColumnName("stuname");

                entity.Property(e => e.StuEmail)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("stuEmail");

                entity.Property(e => e.StuAddress)
                     .IsRequired()
                     .IsUnicode(false)
                     .HasMaxLength(100)
                     .HasColumnName("stuAddress");

                entity.Property(e => e.StuMobile)
                     .HasColumnName("stuMoblie");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.User)
                .WithMany(p => p.Students)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_UserIDStudent");
            });

            modelBuilder.Entity<Schedule>(entity =>
            {
                entity.HasIndex(e => e.UserId, "IX_Schedule_UserID");

                entity.HasKey(e => e.SchID)
                      .HasName("PKSchID");

                entity.Property(e => e.SchID).HasColumnName("schId");

                entity.Property(e => e.SchName)
                    .IsRequired()
                    .IsUnicode(false)
                    .HasMaxLength(100)
                    .HasColumnName("schName");

                entity.Property(e => e.SchDate)
                    .HasColumnType("date")
                    .HasColumnName("schDate");

                entity.Property(e => e.SchTime)
                    .HasColumnName("schTime");

                entity.Property(e => e.SchDescription)
                    .IsRequired()
                    .IsUnicode(false)
                    .HasMaxLength(50)
                    .HasColumnName("schDescription");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.User)
                .WithMany(p => p.Schedules)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_UserIDSchedule");
            });

           
            //OnModelCreatingPartial(modelBuilder);
        }

        //partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}