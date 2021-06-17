using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentMarkManagement.Core.Models
{
   public class StudentMarks
    {
        [Key]
        public int StudentId { get; set; }
        public int Name { get; set; }
        public string StudentName { get; set; }
        [Required]
        public int Mark1 { get; set; }
        [Required]
        public int Mark2 { get; set; }
        public double Total { get; set; }
    }
}
