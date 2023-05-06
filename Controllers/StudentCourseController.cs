using College.Interfaces;
using College.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace College.Controllers
{
    public class StudentCourseController : Controller
    {
        private readonly CollegeContext _ctx;
        private readonly IStudentCourseRepository _repo;

        public IActionResult Index()
        {
            return View();
        }
        public StudentCourseController(CollegeContext ctx, IStudentCourseRepository repo)
        {
            _ctx = ctx;
            _repo = repo;
        }
        public IActionResult CreateStudentCourse()
        {
            return View();
        }
        public IActionResult StudentCourseList()
        {
            List<StudentCourse> lst = new List<StudentCourse>();
            lst = _repo.StudentCourseList().Result;
            return View(lst);
        }
        [HttpPost]
        public IActionResult CreateStudentCourse(StudentCourse model)
        {
            try
            {
                _repo.CreateStudentCourse(model);
                return View();
            }
            catch (Exception ex)
            {

            }
            finally
            {

            }
            return View();
        }
    }
}
