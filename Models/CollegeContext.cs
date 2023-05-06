using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;


namespace College.Models
{
    public class CollegeContext:DbContext
    {
        private readonly IConfiguration _config;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionstring = _config.GetConnectionString("College");

            optionsBuilder.UseSqlServer(connectionstring);
            
            
        }
        public CollegeContext(IConfiguration config)
        {
            _config = config;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StudentCourse>().HasKey(e => new { e.StudentId, e.CourseId });
           // modelBuilder.ApplyConfiguration(new StudentCourseConfiguration());
               
        }


        public DbSet<StudentModel> Student { get; set; }
        public DbSet<DegreeModel> Degree { get; set; }
        public DbSet<Course> Course { get; set; }
        public DbSet<StudentCourse> studentcourse { get; set; }
        public DbSet<FeeRemittance> feeremittance { get; set; }
    }
}

