using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestRepo.Data.DataModels.BaseClass
{
    public class BasePrimaryKey
    {
        [Key]
        public int Id { get; set; }
    }
}
