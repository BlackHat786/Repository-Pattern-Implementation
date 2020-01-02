using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TestRepo.Data.DataModels;

namespace TestRepo.Repository.Contracts
{
    interface IUploadRepository : IDisposable
    {
        //todo : change data model references

        Upload GetById(int id);
        List<Upload> GetAll();
        void Insert(Upload model);
        void Update(Upload model);
        void Delete(Upload model);
        IEnumerable<Upload> Find(Expression<Func<Upload, bool>> predicate);
    }
}
