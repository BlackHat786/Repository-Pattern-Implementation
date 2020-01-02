using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TestRepo.Business.StudentBusiness;
using TestRepo.ViewModel.ViewModels.StudentViewModel;

namespace TestRepo.Web.Controllers
{
    public class StudentController : Controller
    {

        // GET: Student
        public ActionResult Index()
        {
            var x = new StudentBusiness();
            return View(x.GetStudents().ToList());
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(StudentViewModel student)
        {
            if (ModelState.IsValid)
            {
                var std = new StudentBusiness();
                std.Create(student);
            }
            return RedirectToAction("Index");
        }


        public ActionResult Details(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var buss = new StudentBusiness();
            var student = new StudentViewModel();
            student = buss.FindIdStd(id);

            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var buss = new StudentBusiness();
            var student = new StudentViewModel();
            student = buss.FindIdStd(id);

            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        [HttpPost]
        public ActionResult Edit(StudentViewModel s)
        {
            if (ModelState.IsValid)
            {
                var x = new StudentBusiness();
                x.Edit(s);
                return RedirectToAction("Index");
            }
            return View();
        }



    }
}