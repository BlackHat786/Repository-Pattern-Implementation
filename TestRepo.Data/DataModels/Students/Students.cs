using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestRepo.Data.DataModels.BaseClass;

namespace TestRepo.Data.DataModels.Students
{
    public class Students:BasePrimaryKey
    {
        public int StudentNumber { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string email { get; set; }

    }
}
