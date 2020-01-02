using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TestRepo.Data;
using TestRepo.Data.DataModels.FileUploads;
using TestRepo.Data.RepositoryServices;
using TestRepo.Data.RepositoryServices.Contracts;
using TestRepo.Repository.Contracts;

namespace TestRepo.Repository.Repository
{
    public class FileUplodRepository : IFileUploadRepository
    {
        //todo : change data model references
        private DataContext _dbContext = null;
        private readonly IRepository<FileUploads> _repository;


        public FileUplodRepository()
        {
            _dbContext = new DataContext();
            _repository = new RepositoryService<FileUploads>(_dbContext);
        }

        public FileUploads GetById(int id)
        {
            return _repository.Find(x => x.Id == id).FirstOrDefault();
        }

        public List<FileUploads> GetAll()
        {
            return _repository.GetAll().ToList();
        }

        public void Insert(FileUploads model)
        {
            _repository.Insert(model);
        }

        public void Update(FileUploads model)
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

        public void Delete(FileUploads model)
        {
            _repository.Delete(model);
        }

        public IEnumerable<FileUploads> Find(Expression<Func<FileUploads, bool>> predicate)
        {
            return _dbContext.Set<FileUploads>().Where(predicate);
        }

        public void Dispose()
        {
            _dbContext.Dispose();
            _dbContext = null;
        }
        
}
}
