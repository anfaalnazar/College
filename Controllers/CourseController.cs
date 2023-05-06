using College.Interfaces;
using College.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace College.Controllers
{
    public class CourseController : Controller
    {
        private readonly CollegeContext _ctx;
        private readonly ICourseRepository _repo;

        public IActionResult Index()
        {
            return View();
        }
        public CourseController(CollegeContext ctx, ICourseRepository repo)
        {
            _ctx = ctx;
            _repo = repo;
        }
        public IActionResult CreateCourse()
        {
            return View();
        }
        public IActionResult CourseList()
        {
            List<Course> lst = new List<Course>();
            lst = _repo.CourseList().Result;
            return View(lst);
        }
        [HttpPost]
        public IActionResult CreateCourse(Course model)
        {
            try
            {
                _repo.CreateCourse(model);
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
