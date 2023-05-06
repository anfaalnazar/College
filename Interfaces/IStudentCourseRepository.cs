using College.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace College.Interfaces
{
   public interface IStudentCourseRepository
    {
        Task<List<StudentCourse>> StudentCourseList();
        //Task<StudentCourse> SingleStudentCourse(int StudentCourseId);
        Task<StudentCourse> CreateStudentCourse(StudentCourse singlestudentcourse);
        // Task<StudentCourse> UpdateStudentCourse(StudentCourse singlestudentcourse);
        //  Task<int> DeleteStudentCourse(int StudentCourseId);
    }
}
