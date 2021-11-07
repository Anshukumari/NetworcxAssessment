using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmpManagement.Data.Model
{
    public class Employee
    {
        
        [Key]
        [Column(TypeName = "int(100)")]
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
