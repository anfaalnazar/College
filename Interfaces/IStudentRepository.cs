using College.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace College.Interfaces
{
    public interface IStudentRepository
    {
        Task<List<StudentModel>> StudentList();
        Task<StudentModel> SingleStudent(int id);
        Task<StudentModel> CreateStudent(StudentModel singlestudent);
        Task<StudentModel> UpdateStudent(StudentModel singlestudent);
        Task<int> DeleteStudent(int id);
        Task<List<DegreeModel>> DegreeList();
        
    }
}
