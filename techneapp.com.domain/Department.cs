using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace techneapp.com.domain
{
    [Table(name: "Department")]
    public class Department
    {
        [ForeignKey("ID")]
        public int ID { get; set; }

        [Column(TypeName = "varchar(500)")]
        [Required]
        public string DepartmentName { get; set; }

        public ICollection<Employee> Employees { get; set; }
    }
}
