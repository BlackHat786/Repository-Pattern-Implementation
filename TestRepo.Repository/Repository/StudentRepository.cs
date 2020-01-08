using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TestRepo.Data;
using TestRepo.Data.DataModels.Students;
using TestRepo.Data.RepositoryServices;
using TestRepo.Data.RepositoryServices.Contracts;
using TestRepo.Repository.Contracts;

namespace TestRepo.Repository.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private DataContext _dbContext = null;
        private readonly IRepository<Students> _repository;


        public StudentRepository()
        {
            _dbContext = new DataContext();
            _repository = new RepositoryService<Students>(_dbContext);
        }

        public Students GetById(int id)
        {
            return _repository.Find(x => x.Id == id).FirstOrDefault();
        }

        public List<Students> GetAll()
        {
            return _repository.GetAll().ToList();
        }
        public Students StudentNumber(int studntNumber)
        {            
            var std = GetAll();
            return std.Find(x => x.StudentNumber == studntNumber);
        }
        public void Insert(Students model)
        {
            _repository.Insert(model);
        }

        public void Update(Students model)
        {
             using (var repo = new StudentRepository())
            {
                var std = repo.GetById(model.Id);
                std.Name = model.Name;
                std.Surname = model.Surname;
                std.StudentNumber = model.StudentNumber;
                std.email = model.email;
                _dbContext.Entry(std).State = System.Data.Entity.EntityState.Modified;
                _repository.Update(std);
                
            }
             
        }

        public void Delete(Students model)
        {
            _repository.Delete(model);
        }

        public IEnumerable<Students> Find(Expression<Func<Students, bool>> predicate)
        {
            return _dbContext.Set<Students>().Where(predicate);
        }

        public void Dispose()
        {
            _dbContext.Dispose();
            _dbContext = null;
        }
    }
}
