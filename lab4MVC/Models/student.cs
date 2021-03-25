using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace lab4MVC.Models
{
    [Table("student")]
    public class student
    {
        [Key]
        public int id { get; set; }
        [Required]
        [MaxLength(30)]
        public string name { get; set; }
        [Range(10,40,ErrorMessage ="Age must be in range of 10  , 40")]
        public int age { get; set; }
       [DataType(DataType.EmailAddress)]
       [RegularExpression(@"[a-zA-Z0-9_]*@[a-zA-Z]*.[a-zA-Z]{2,4}")]
        public string email { get; set; }
        [ForeignKey("Department")]
        public int Dept_id { get; set; }
        [Required]
        public string password { get; set; }
        [NotMapped]
        [System.ComponentModel.DataAnnotations.Compare("password")]
        public string co_password { get; set; }
        [Required]
        [Remote("checkun","student")]
        public string username { get; set; }

        public virtual department Department { get; set; }

    }
}