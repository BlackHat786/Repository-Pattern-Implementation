using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TestRepo.Data;
using TestRepo.Data.DataModels;
using TestRepo.Data.RepositoryServices;
using TestRepo.Data.RepositoryServices.Contracts;
using TestRepo.Repository.Contracts;

namespace TestRepo.Repository.Repository
{
    public class UploadRepository:IUploadRepository
    {
        private DataContext _dbContext = null;
        private readonly IRepository<Upload> _repository;


        public UploadRepository()
        {
            _dbContext = new DataContext();
            _repository = new RepositoryService<Upload>(_dbContext);
        }

        public Upload GetById(int id)
        {
            return _repository.Find(x => x.Id == id).FirstOrDefault();
        }

        public List<Upload> GetAll()
        {
            return _repository.GetAll().ToList();
        }

        public void Insert(Upload model)
        {
            _repository.Insert(model);
        }

        public void Update(Upload model)
        {

            var std = GetById(model.Id);

            //std.StudentName = model.StudentName;
            //std.Surname = model.Surname;
            //std.Initials = model.Initials;
            //std.StudentNumber = model.StudentNumber;
            //std.Surname = model.Surname;
            //std.email = model.email;
            //std.Contact = model.Contact;
            //std.GroupId = model.GroupId;
            //std.Address = model.Address;
            //_dbContext.Entry(std).State = System.Data.Entity.EntityState.Modified;
            _repository.Update(std);

        }

        public void Delete(Upload model)
        {
            _repository.Delete(model);
        }

        public IEnumerable<Upload> Find(Expression<Func<Upload, bool>> predicate)
        {
            return _dbContext.Set<Upload>().Where(predicate);
        }

        public void Dispose()
        {
            _dbContext.Dispose();
            _dbContext = null;
        }
    }
}
