using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TestRepo.Data.DataModels.FileUploads;

namespace TestRepo.Repository.Contracts
{
    public interface IFileUploadRepository:IDisposable
    {
        FileUploads GetById(int id);
        List<FileUploads> GetAll();
        void Insert(FileUploads model);
        void Update(FileUploads model);
        void Delete(FileUploads model);
        IEnumerable<FileUploads> Find(Expression<Func<FileUploads, bool>> predicate);
    }
}
