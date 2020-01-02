using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestRepo.Data.DataModels.Students;
using TestRepo.Repository.Repository;
using TestRepo.ViewModel.ViewModels.StudentViewModel;

namespace TestRepo.Business.StudentBusiness
{
    public class StudentBusiness
    {
        public List<StudentViewModel> GetStudents()
        {
            List<StudentViewModel> vm = new List<StudentViewModel>();
            var repo = new StudentRepository();
            var result = repo.GetAll();
            foreach (var item in result)
            {
                StudentViewModel vms = new StudentViewModel();
                vms.Id = item.Id;
                vms.Name = item.Name;
                vms.StudentNumber = item.StudentNumber;
                vms.Surname = item.Surname;
                vms.email = item.email;
                vm.Add(vms);
            }
            return vm;
        }

        public void Create(StudentViewModel student)
        {
            StudentRepository s = new StudentRepository();
            var std = new Students();

            std.Id = student.Id;
            std.Name = student.Name;
            std.Surname = student.Surname;
            std.StudentNumber = student.StudentNumber;
            std.email = student.email;

            s.Insert(std);
        }


        public void Details(StudentViewModel student)
        {
            StudentRepository s = new StudentRepository();
            s.GetById(student.Id);
        }

        public StudentViewModel FindIdStd(int id)
        {
            StudentRepository student = new StudentRepository();

            var r = student.GetById(id);
            var students = new StudentViewModel()
            {
                Id = r.Id,
                Name=r.Name,
                Surname= r.Surname,
                StudentNumber=r.StudentNumber,
                email=r.email
            };
            return students;
        }

        public void Edit(StudentViewModel student)
        {
            var repo = new StudentRepository();

            var s = new Students()
            {
                Id=student.Id,
                Name = student.Name,
                Surname = student.Surname,
                StudentNumber=student.StudentNumber,
                email=student.email
            };
            repo.Update(s);
        }
    }
}
