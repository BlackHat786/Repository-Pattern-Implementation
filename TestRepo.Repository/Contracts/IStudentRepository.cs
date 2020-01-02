using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TestRepo.Data.DataModels.Students;

namespace TestRepo.Repository.Contracts
{
    public interface IStudentRepository : IDisposable
    {
        //todo : change data model references

        Students GetById(int id);
        List<Students> GetAll();
        void Insert(Students model);
        void Update(Students model);
        void Delete(Students model);
        IEnumerable<Students> Find(Expression<Func<Students, bool>> predicate);

    }
}
