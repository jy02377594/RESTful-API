using AutoMapper;
using LXP.api.Models;
using LXP.api.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LXP.api.Controllers
{
    [ApiController]
    [Route(template: "api/Tasks")]
    public class TasksController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;

        public TasksController(IEmployeeRepository employeeRepository, IMapper mapper)
        {
            _employeeRepository = employeeRepository ?? throw new ArgumentNullException(nameof(employeeRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeeTaskDto>>> GetTasksAsync()
        {
            var tasks = await _employeeRepository.GetTasksAsync();
            var taskDto = _mapper.Map<IEnumerable<EmployeeTaskDto>>(tasks);

            return Ok(taskDto);
        }

        [HttpGet(template: "{TaskList}")] //api/Tasks/{TaskList}
        public async Task<ActionResult<IEnumerable<EmployeeTaskDto>>> GetTasksAsync(string TaskList)
        {
            var tasks = await _employeeRepository.GetTasksAsync(TaskList);
            var taskDto = _mapper.Map<IEnumerable<EmployeeTaskDto>>(tasks);

            return Ok(taskDto);
        }
        // Ambiguous between GetTasksAsync and GetOneTaskAsync, so comment this function

        //[HttpGet(template: "{TaskName}")] //api/Tasks/{TaskName}
        //public async Task<ActionResult<EmployeeTaskDto>> GetOneTaskAsync(string TaskName)
        //{
        //    var task = await _employeeRepository.GetOneTaskAsync(TaskName);
        //    var taskDto = _mapper.Map<EmployeeDto>(task);

        //    return Ok(taskDto);
        //}
    }
}
