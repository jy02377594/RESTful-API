using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LXP.api.Models
{
    public class EmployeeAddDto
    {
        [Display(Name = "FirstName")]
        [Required(ErrorMessage = "You have to filed up {0} field")]
        [MaxLength(50, ErrorMessage = "{0) maxlength could not exceed {1}")]
        public string FirstName { get; set; }

        [Display(Name = "LastName")]
        [Required(ErrorMessage = "You have to filed up {0} field")]
        [MaxLength(50, ErrorMessage = "{0) maxlength could not exceed {1})")]
        public string LastName { get; set; }

        public DateTimeOffset HiredDate { get; set; }
        //[StringLength(500, MinimumLength = 10, ErrorMessage = "{0}length should between {2} and {1} ")]
        [MaxLength(500, ErrorMessage = "{0) maxlength could not exceed {1})")]
        public string TaskList { get; set; }
    }
}
