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
            [Key]
            public int ID { get; set; }

            [Column(TypeName = "varchar(500)")]
            [Required]
            public string DepartmentName { get; set; }
        }
    }
