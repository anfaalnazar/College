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
    public class StudentRepository : IStudentRepository
    {
        private readonly CollegeContext _appDbContext;
        private readonly IConfiguration _config;
        public StudentRepository(CollegeContext appDbContext, IConfiguration config)
        {
            _appDbContext = appDbContext;
            _config = config;
        }
        public async Task<StudentModel> CreateStudent(StudentModel singlestudent)
        {
           
            await Task.Run(() =>
            {
                using (var context = new CollegeContext( _config))
                {
                    //var entity = new MyEntity { Name = "New Entity" };
                    context.Student.Add(singlestudent);
                    context.SaveChanges();
                }
            });
            return null;
        }

        public Task<List<DegreeModel>> DegreeList()
        {
            return _appDbContext.Degree.ToListAsync();
        }

        
        public Task<int> DeleteStudent(int id)
        {
            throw new NotImplementedException();
        }

        public Task<StudentModel> SingleStudent(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<StudentModel>> StudentList()
        {
            return await _appDbContext.Student.Include(x=>x.Degree).Include(x=>x.studentcourse).ThenInclude(m=>m.course).ToListAsync();
        }

        public Task<StudentModel> UpdateStudent(StudentModel singlestudent)
        {
            throw new NotImplementedException();
        }
    }
}
