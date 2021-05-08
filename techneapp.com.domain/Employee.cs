using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace techneapp.com.domain
{
    [Table(name: "Employee")]
    public class Employee
    {
        [ForeignKey("ID")]
        public int ID { get; set; }

        [Column(TypeName = "varchar(500)")]
        [Required]
        public string EmployeeName { get; set; }

        [Column(TypeName = "varchar(500)")]
        [Required]
        public string Email { get; set; }

        [Column(TypeName = "varchar(500)")]
        [Required]
        public Department Depatment { get; set; }

        [Column(TypeName = "varchar(500)")]
        [Required]
        public string ImageURL { get; set; }
    }
}
