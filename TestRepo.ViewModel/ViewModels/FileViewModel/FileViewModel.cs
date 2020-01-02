using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestRepo.ViewModel.ViewModels.FileViewModel
{
    public class FileViewModel
    {

        [Key]
        public int Id { get; set; }
        public byte[] File { get; set; }
        [Display(Name = "File Name")]
        public string FileName { get; set; }
    }
}
