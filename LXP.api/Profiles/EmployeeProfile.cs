using AutoMapper;
using LXP.api.Entities;
using LXP.api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LXP.api.Profiles
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            CreateMap<Employee, EmployeeDto>();

            // if the name of two objects is different, use ForMember() to transform

            //CreateMap<Employee, EmployeeDto>()
            //    .ForMember(
            //        destinationMember: dest => dest.Name,
            //        memberOptions: opt => opt.MapFrom(mapExpression: src => $"{src.FirstName} {src.LastName}"))
            //    .ForMember(
            //    destinationMember: dest => dest.TaskList,
            //    memberOptions: opt => opt.MapFrom(mapExpression: src => src.TaskList)
            //    );

            CreateMap<EmployeeAddDto, Employee>();
            CreateMap<EmployeeUpdateDto, Employee>();
            CreateMap<Employee, EmployeeUpdateDto>();

        }
    }
}
