using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestRepo.Data.DataModels.BaseClass;

namespace TestRepo.Data.DataModels.FileUploads
{
    public class FileUploads:BasePrimaryKey
    {
        public byte[] File { get; set; }
        [Display(Name = "File Name")]
        public string FileName { get; set; }
    }
}
