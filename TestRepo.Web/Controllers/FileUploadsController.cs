using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestRepo.Business.FileUploadBusiness;
using TestRepo.ViewModel.ViewModels.FileUploadsViewModel;
using TestRepo.Data;
using TestRepo.Data.DataModels.FileUploads;

namespace TestRepo.Web.Controllers
{
    public class FileUploadsController : Controller
    {
        // GET: FileUploads
        DataContext db = new DataContext();
        public ActionResult Index()
        {
            List<FileUploads> name = db.fileUpload.ToList();
            return View(name);
        }

        public ActionResult FileUploadProcess(FileUploadsViewModel model, HttpPostedFileBase file)
        {

            if (!ModelState.IsValid)
            {
                return View();
            }
            var x = new FileUploadBusiness();
            x.FileUploadProcess(model);

            return RedirectToAction("Index");
        }
       

        public FileContentResult FileDownload(int? id, FileUploadBusiness fileUploadBusiness)
        {
            var file= fileUploadBusiness.SearchFile(id);
            return File(fileUploadBusiness.fileData(file), "text", fileUploadBusiness.fileName(file));
        }

    }
}