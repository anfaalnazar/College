using College.Interfaces;
using College.Models;
using College.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace College.Controllers
{
    public class DegreeController : Controller
    {
        private readonly CollegeContext _ctx;
        private readonly IDegreeRepository _repo;

        public IActionResult Index()
        {
            return View();
        }
        public DegreeController(CollegeContext ctx,IDegreeRepository repo)
        {
            _ctx = ctx;
            _repo = repo;
        }
        public IActionResult CreateDegree()
        {
            return View();
        }

        public IActionResult DegreeList()
        {
            List<DegreeModel> lst = new List<DegreeModel>();
            lst = _repo.DegreeList().Result;
            return View(lst); 
        }

        public IActionResult EditDegree(int degreeid)
        {
           var degree= _repo.SingleDegree(degreeid).Result;
            return View(degree);
        }

        public IActionResult deletedegree(int degreeid)
        {
            var degree = _repo.SingleDegree(degreeid).Result;
            return View(degree);
        }

        [HttpPost]
        public IActionResult CreateDegree(DegreeModel model)
        {
            try
            {
                _repo.CreateDegree(model);
                return View();
            }
            catch(Exception ex)
            {

            }
            finally
            {

            }
            return View();
        }

        [HttpPost]
        public IActionResult EditDegree(DegreeModel model)
        {
            var degree = _repo.UpdateDegree(model);
           
            return RedirectToAction(nameof(DegreeList));
        }

        [HttpPost]
        public IActionResult HIDeleteDegree(int degreeid)
        {
            var degree = _repo.DeleteDegree(degreeid);
            return RedirectToAction(nameof(DegreeList));
        }
    }
}
