using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestRepo.Data.DataModels;
using TestRepo.Data.DataModels.FileUploads;
using TestRepo.Data.DataModels.Students;
using TestRepo.Data.RepositoryServices.Contracts;

namespace TestRepo.Data
{
    public class DataContext : DbContext, IDbContext
    {
        public DataContext()
           : base("TestRepoContext")
        {
            Database.SetInitializer<DbContext>(null);
        }

        public DbSet<Students> students { get; set; }
        public DbSet<FileUploads> fileUpload { get; set; }
        public DbSet<Upload> uploads { get; set; }
        public new IDbSet<TEntity> Set<TEntity>() where TEntity : class
        {
            return base.Set<TEntity>();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }

     }
}
