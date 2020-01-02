using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestRepo.Data.DataModels.BaseClass;

namespace TestRepo.Data.DataModels
{
    public class Upload:BasePrimaryKey
    {
        public string FileName { get; set; }

        public byte[] file { get; set; }
    }
}
