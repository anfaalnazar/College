using College.Interfaces;
using College.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace College.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        private readonly CollegeContext _appDbContext;

        public CourseRepository(CollegeContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public Task<List<Course>> CourseList()
        {
            return _appDbContext.Course.ToListAsync();
        }

        public Task<Course> CreateCourse(Course singlecourse)
        {
            _appDbContext.Add(singlecourse);
            _appDbContext.SaveChangesAsync();
            var game = _appDbContext.Course.SingleOrDefaultAsync(x => x.CourseId == singlecourse.CourseId);

            return game;
        }
    }
}
