using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
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

        public Students search(int stdnum)
        {
            StudentRepository repo = new StudentRepository();
            var std = repo.StudentNumber(stdnum);
            return std;
        }

        public string ImportStudents(HttpPostedFileBase FileUpload, StudentViewModel student)
        {
            String output = "";
            ExcelPackage package = new ExcelPackage();
            bool check = false;

            output = "The excel consists of the following:";
            int correct = 0;
            int dup = 0;
            int errors = 0;
            try
            {
                if (FileUpload != null && FileUpload.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(FileUpload.FileName);
                    if ((Path.GetExtension(fileName).Equals(".xlsx")))
                    {
                        var excel = new ExcelPackage(FileUpload.InputStream);

                        ExcelWorksheet workSheet = excel.Workbook.Worksheets.First();

                        DataTable dataTable = new DataTable();
                        foreach (var firstRowCell in workSheet.Cells[1, 1, 1, workSheet.Dimension.End.Column])
                        {

                            dataTable.Columns.Add(firstRowCell.Text);
                        }
                        for (var rowNumber = 2; rowNumber <= workSheet.Dimension.End.Row; rowNumber++)
                        {
                            bool a = false;

                            var StudentNumber = Convert.ToInt32(workSheet.Cells[rowNumber, 1].Value.ToString());
                            var Name = workSheet.Cells[rowNumber, 2].Value;
                            var Surname = workSheet.Cells[rowNumber, 3].Value;
                            var email = workSheet.Cells[rowNumber, 4].Value.ToString();

                            if (StudentNumber == null || Name == null || Surname == null || email == null)
                            {
                                errors++;

                                output = output + "\n" + " Line :" + rowNumber;
                                check = true;
                                if (StudentNumber == null)
                                {
                                    output = output + "\n" + " Student Number field is empty or is not the proper data type";
                                }
                                if (Name == null)
                                {
                                    output = output + "\n" + "Name field is empty or is not the proper data type";
                                }
                                if (Surname == null)
                                {
                                    output = output + "\n" + "Surname field is empty or is not the proper data type";
                                }
                                if (email == null)
                                {
                                    output = output + "\n" + " Email field is empty or is not the proper data type";
                                }

                            }
                            else
                            {

                                Students v = new Students();
                                v.StudentNumber = Convert.ToInt32(workSheet.Cells[rowNumber, 1].Value.ToString());
                                v.Name = workSheet.Cells[rowNumber, 2].Value.ToString();


                                v.Surname = workSheet.Cells[rowNumber, 3].Value.ToString();
                                v.email = workSheet.Cells[rowNumber, 4].Value.ToString();

                                var repo = new StudentRepository();
                                var result = repo.GetAll();
                                a = false;
                                foreach (var item in result)
                                {

                                    if (item.StudentNumber == v.StudentNumber)
                                    {
                                        dup++;
                                        a = true;
                                        Students m = new Students()
                                        {
                                            Id = item.Id,
                                            StudentNumber = v.StudentNumber,
                                            Name = v.Name,
                                            Surname = v.Surname,
                                            email = v.email
                                        };


                                        var repos = new StudentRepository();
                                        repos.Update(m);
                                    }
                                }

                                if (a == false)
                                {

                                    var ad = new StudentRepository();
                                    var aa = ad.GetAll();
                                    int num = 0;

                                    correct++;
                                    Students l = new Students()
                                    {
                                        Id = num,
                                        StudentNumber = v.StudentNumber,
                                        Name = v.Name,
                                        Surname = v.Surname,
                                        email = v.email
                                    };

                                    var repos = new StudentRepository();
                                    repos.Insert(l);


                                }
                            }
                        }

                    }
                    else
                    {
                        output = "Please ensure the import file is in excel format.";
                    }

                }
                else
                {
                    output = "No file chosen";
                }

            }
            catch (Exception e)
            {
                return output;
            }
            output = output + "\n" + correct + " correct imported rows." + "\n" + dup + " duplicate imports were made. Duplicates are removed" + "\n" + errors + " errors were found.";
            return output;
        }


        public void Student_Export()
        {
            List<StudentViewModel> vm = new List<StudentViewModel>();
            var repo = new StudentRepository();
            var results = repo.GetAll();
            foreach (var item in results)
            {
                StudentViewModel vms = new StudentViewModel();
                vms.StudentNumber = item.StudentNumber;
                vms.Name = item.Name;
                vms.Surname = item.Surname;
                vms.email = item.email;
                vm.Add(vms);
            }
            ExcelPackage pck = new ExcelPackage();
            ExcelWorksheet ws = pck.Workbook.Worksheets.Add("Report");
            ws.Cells["A1"].Value = "Student Number";
            ws.Cells["B1"].Value = "Name";
            ws.Cells["C1"].Value = "Surname";
            ws.Cells["D1"].Value = "Email";
            int rowStart = 2;
            foreach (var item in vm)
            {
                ws.Cells[string.Format("A{0}", rowStart)].Value = item.StudentNumber;
                ws.Cells[string.Format("B{0}", rowStart)].Value = item.Name;
                ws.Cells[string.Format("C{0}", rowStart)].Value = item.Surname;
                ws.Cells[string.Format("D{0}", rowStart)].Value = item.email;
                rowStart++;
            }
            ws.Cells["A:AZ"].AutoFitColumns();
            HttpContext.Current.Response.Clear();
            HttpContext.Current.Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            HttpContext.Current.Response.AddHeader("content-disposition", "attachment: filename" + "ExcelReport.xlsx");
            HttpContext.Current.Response.BinaryWrite(pck.GetAsByteArray());
            HttpContext.Current.Response.End();
        }

        public void Format()
        {
            ExcelPackage pck = new ExcelPackage();
            ExcelWorksheet ws = pck.Workbook.Worksheets.Add("Format");
            ws.Cells["A1"].Value = "Student Number";
            ws.Cells["B1"].Value = "Name";
            ws.Cells["C1"].Value = "Surname";
            ws.Cells["D1"].Value = "Email";
            ws.Cells["A:AZ"].AutoFitColumns();
            HttpContext.Current.Response.Clear();
            HttpContext.Current.Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            HttpContext.Current.Response.AddHeader("content-disposition", "attachment: filename" + "ExcelReport.xlsx");
            HttpContext.Current.Response.BinaryWrite(pck.GetAsByteArray());
            HttpContext.Current.Response.End();
        }
    }
}
