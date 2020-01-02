using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using TestRepo.Data;
using TestRepo.Data.DataModels;
using TestRepo.Repository.Repository;
using TestRepo.ViewModel.ViewModels;

namespace TestRepo.Business
{
    public class UploadBusiness
    {
        public List<UploadViewModel> Index()
        {
            List<UploadViewModel> vm = new List<UploadViewModel>();
            var repo = new UploadRepository();

            var results= repo.GetAll();

            foreach (var item in results)
            {
                UploadViewModel vms = new UploadViewModel();

                vms.file = item.file;
                vms.location = item.FileName;

                vm.Add(vms);
            }

            return vm;
        }

        public byte[] ConvertToBytes(HttpPostedFileBase files)
        {

            BinaryReader reader = new BinaryReader(files.InputStream);
            return reader.ReadBytes(files.ContentLength);
        }

        public void Upload(UploadViewModel vm, HttpPostedFileBase files)
        {
            var repo = new UploadRepository();

            if (files != null && files.ContentLength > 0)
            {
                vm.location = files.FileName;
                vm.file = ConvertToBytes(files);
            }

            Upload x = new Upload();

            x.Id = vm.Id;
            x.file = vm.file;
            x.FileName = vm.location;

            repo.Insert(x);
        }
        DataContext db = new DataContext();
       
    }
}
