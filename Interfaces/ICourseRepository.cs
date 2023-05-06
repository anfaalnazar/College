using College.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace College.Interfaces
{
    public interface ICourseRepository
    {
         Task<List<Course>> CourseList();
        //Task<Course> SingleCourse(int CourseId);
        Task<Course> CreateCourse(Course singlecourse);
        // Task<Course> UpdateCourse(Course singlecourse);
        //  Task<int> DeleteCourse(int degreeid);
    }
}
