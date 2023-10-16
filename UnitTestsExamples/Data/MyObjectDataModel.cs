using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestsExamples.Data
{
    public class MyObjectDataModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string FName { get; set; }
        
        [Required]
        public string LName { get; set; }

    }
}
