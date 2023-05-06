using College.Interfaces;
using College.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace College.Repositories
{
    public class StudentCourseRepository : IStudentCourseRepository
    {
        private readonly CollegeContext _appDbContext;
        private readonly IConfiguration _config;

        public StudentCourseRepository(CollegeContext appDbContext, IConfiguration config)
        {
            _appDbContext = appDbContext;
            _config = config;
        }
        public async Task<StudentCourse> CreateStudentCourse(StudentCourse singlestudentcourse)
        {
           
            await Task.Run(() =>
            {
                using (var context = new CollegeContext(_config))
                {
                    //var entity = new MyEntity { Name = "New Entity" };
                    context.studentcourse.Add(singlestudentcourse);
                    context.SaveChanges();
                }
            });
            return null;
        }

        public Task<List<StudentCourse>> StudentCourseList()
        {
            return _appDbContext.studentcourse.ToListAsync();
        }
    }
}
