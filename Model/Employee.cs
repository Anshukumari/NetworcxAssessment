using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EmpManagement.Model
{
    public class Employee
    {
        
        [Key]
        public int Id { get; set; }

        [Column(TypeName="nvarchar(100)")]
        public string Name { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string Gender { get; set; }

        [Column(TypeName = "number(10)")]
        public int Age { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal Salary { get; set; }
    }
}
