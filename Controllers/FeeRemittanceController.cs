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
    public class FeeRemittanceController : Controller
    {
        private readonly CollegeContext _ctx;
        private readonly IFeeRemittanceRepository _repo;
        private readonly IStudentRepository _strepo;
        private readonly ICourseRepository _crsrepo;

        public FeeRemittanceController(CollegeContext ctx,IFeeRemittanceRepository repo,IStudentRepository strepo,ICourseRepository crsrepo)
        {
            _ctx = ctx;
            _repo = repo;
            _strepo = strepo;
            _crsrepo = crsrepo;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult CreateFeeRemittance()
        {
            List<StudentModel> lst = _strepo.StudentList().Result;
            List<Course> lstcrs = _crsrepo.CourseList().Result;
            ViewBag.studentid = new SelectList(lst, "id", "name");
            ViewBag.CourseId = new SelectList(lstcrs, "CourseId", "CourseName");
            return View();
        }

        public IActionResult FeeRemittanceList()
        {
            List<FeeRemittance> lst = new List<FeeRemittance>();
            lst = _repo.FeeRemittanceList().Result;
            return View(lst);
        }
        [HttpPost]
        public IActionResult CreateFeeRemittance(FeeRemittance model)
        {
            try
            {
                _repo.CreateFeeRemittance(model);
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
