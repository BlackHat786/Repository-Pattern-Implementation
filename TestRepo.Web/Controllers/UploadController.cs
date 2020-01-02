using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestRepo.Business;
using TestRepo.Data;
using TestRepo.Data.DataModels;
using TestRepo.Repository.Repository;
using TestRepo.ViewModel.ViewModels;

namespace TestRepo.Web.Controllers
{
    public class UploadController : Controller
    {
        // GET: Upload
        public ActionResult Index()
        {
            UploadBusiness b = new UploadBusiness();
            return View(b.Index().ToList());
        }
        public byte[] ConvertToBytes(HttpPostedFileBase files)
        {

            BinaryReader reader = new BinaryReader(files.InputStream);
            return reader.ReadBytes(files.ContentLength);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Upload vm, HttpPostedFileBase files)
        {
            if (files != null && files.ContentLength > 0)
            {
                vm.FileName = files.FileName;
                vm.file = ConvertToBytes(files);
            }
            if (ModelState.IsValid)
            {
                db.uploads.Add(vm);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vm);
        }
        DataContext db = new DataContext();
        public ActionResult Download(int id)
        {
            var repo = new UploadRepository();

            var r = repo.GetById(id);

            return File(r.file, "application/pdf", r.FileName);
        }
    }
}