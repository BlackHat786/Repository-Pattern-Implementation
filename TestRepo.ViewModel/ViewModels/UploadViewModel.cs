using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestRepo.ViewModel.ViewModels
{
    public class UploadViewModel
    {
        public int Id { get; set; }

        public string location { get; set; }

        public byte[] file { get; set; }
    }
}
