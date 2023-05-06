using College.Interfaces;
using College.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace College.Controllers
{
    public class StudentController : Controller
    {
        private readonly CollegeContext _ctx;
        private readonly IStudentCourseRepository _screpo;
        private readonly IStudentRepository _repo;
        private readonly IDegreeRepository _degrepo;
        private readonly ICourseRepository _crsrepo;

        public StudentController(CollegeContext ctx,IStudentCourseRepository screpo, IStudentRepository repo,IDegreeRepository degrepo,ICourseRepository crsrepo)
        {
            _ctx = ctx;
            _screpo = screpo;
            _repo = repo;
            _degrepo = degrepo;
            _crsrepo = crsrepo;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult CreateStudent()
        {
            List<DegreeModel> lst = _degrepo.DegreeList().Result;
            List<Course> lstcrs = _crsrepo.CourseList().Result;
            ViewBag.degreeid = new SelectList(lst, "degreeid", "degreename");
            ViewBag.CourseList = new SelectList(lstcrs, "CourseId", "CourseName");
            return View();
        }
        public IActionResult StudentList()
        {
            List<StudentModel> lst = new List<StudentModel>();
            lst = _repo.StudentList().Result;
            return View(lst);
        }
        [HttpPost]
        public IActionResult CreateStudent(StudentVM model)
        {
            StudentModel obj = new StudentModel()
            {
                id=model.id,
                name=model.name,
                address=model.address,
                phone=model.phone,
                degreeid=model.degreeid,
                IsActive=1
            };
            

            try
            {
               var st= _repo.CreateStudent(obj);
               var studentlist= _repo.StudentList().Result.ToList();
                var noofelements = studentlist.Count;
                var latestid=studentlist[noofelements-1].id;
                StudentCourse sc = new StudentCourse();
                foreach (var item in model.CourseIds)
                {
                    sc.CourseId = item;
                    sc.StudentId = latestid+1;
                    _screpo.CreateStudentCourse(sc);
                    sc = new StudentCourse();

                }
                
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
