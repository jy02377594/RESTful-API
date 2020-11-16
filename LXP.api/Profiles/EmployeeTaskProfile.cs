using LXP.api.Entities;
using LXP.api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;

namespace LXP.api.Profiles
{
    public class EmployeeTaskProfile : Profile
    {
        public EmployeeTaskProfile()
        {
            CreateMap<EmployeeTask, EmployeeTaskDto>();
        }
    }
}
