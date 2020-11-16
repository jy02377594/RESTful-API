using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LXP.api.Models
{
    public class EmployeeTaskDto
    {

        [Display(Name = "TaskName")]
        [Required(ErrorMessage = "You have to filed up {0} field")]
        [MaxLength(50, ErrorMessage = "{0) maxlength could not exceed {1}")]
        public string TaskName { get; set; }
        public DateTimeOffset StartTime { get; set; }
        public DateTimeOffset DeadLine { get; set; }
    }
}
