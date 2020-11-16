using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LXP.api.Entities
{
    public class EmployeeTask
    {
        [Key]
        public string TaskName { get; set; }
        public DateTimeOffset StartTime { get; set; }
        public DateTimeOffset DeadLine { get; set; }
        public Employee Employee { get; set; }
    }
}
