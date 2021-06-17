using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentMarkManagement.Core.Models
{
   public class StudentDetails
    {

        [Key]
        public int StudentId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]  
        public string Email { get; set; }
        [Required]     
        public string Department { get; set; }
        public IList<Department> Departments { get; set; }
        [Required]      
        public string Gender { get; set; }
      
    }
}
