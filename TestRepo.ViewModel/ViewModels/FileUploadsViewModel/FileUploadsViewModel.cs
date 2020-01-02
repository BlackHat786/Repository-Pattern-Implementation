using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace TestRepo.ViewModel.ViewModels.FileUploadsViewModel
{
   public class FileUploadsViewModel
    {
        [Key]
        public int key { get; set; }
        [DisplayName("Select File to Upload")]
        public HttpPostedFileBase File { get; set; }
        [Display(Name = "File Name")]
        [Required]
        public string FileName { get; set; }
    }
}
