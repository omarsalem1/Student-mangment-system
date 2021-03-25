using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lab4MVC.Models
{
    public class department
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int dept_id { get; set; }
        [Required]
        
        public string dept_name { get; set; }
        public virtual List<student> Students { get; set; }
    }

}