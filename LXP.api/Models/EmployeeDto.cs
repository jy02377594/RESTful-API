using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LXP.api.Models
{
    public class EmployeeDto
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTimeOffset HiredDate { get; set; }
        public string TaskList { get; set; }
    }
}
