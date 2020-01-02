using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestRepo.Data;
using TestRepo.Data.DataModels.FileUploads;
using TestRepo.Repository.Repository;
using TestRepo.ViewModel.ViewModels.FileUploadsViewModel;
using TestRepo.ViewModel.ViewModels.FileViewModel;

namespace TestRepo.Business.FileUploadBusiness
{
   public class FileUploadBusiness
    {
        public List<FileViewModel> Index()
        {
            var repo = new FileUplodRepository();
            var result=repo.GetAll();
            List<FileViewModel> vm = new List<FileViewModel>();

            foreach (var item in result)
            {
                FileViewModel vms = new FileViewModel();
                vms.FileName = item.FileName;

                vm.Add(vms);
            }

            return vm;
        }


        //public FileUploadsViewModel FileUploadProcess()
        //{
        //    var model = new FileUploadsViewModel();
        //    return model;
        //}

        public void FileUploadProcess(FileUploadsViewModel model)
        {
            FileUploads fileUpload = new FileUploads();
            var repo = new FileUplodRepository();
            byte[] uploadFile = new byte[model.File.InputStream.Length];

            model.File.InputStream.Read(uploadFile, 0, uploadFile.Length);

            fileUpload.FileName = model.File.FileName;
            fileUpload.File = uploadFile;

            repo.Insert(fileUpload);                  
        }

        DataContext db = new DataContext();
        public FileUploads SearchFile(int? id)
        {
            FileUploads fileRecord = db.fileUpload.Find(id);
            return fileRecord;
        }
        public string fileName(FileUploads fileRecord)
        {
            return fileRecord.FileName;
        }
        public byte[] fileData(FileUploads fileData)
        {
            return (byte[])fileData.File.ToArray();
        }
    }
}
