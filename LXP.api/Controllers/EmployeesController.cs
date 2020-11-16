using AutoMapper;
using LXP.api.Entities;
using LXP.api.Models;
using LXP.api.Services;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LXP.api.Controllers
{
    [ApiController]
    //[Route(template: "api/[controller]")]
    [Route(template: "api/employees")]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeRepository _EmployRepository;
        private readonly IMapper _mapper;

        public EmployeesController(IEmployeeRepository employeeRepository, IMapper mapper)
        {
            _EmployRepository = employeeRepository ?? throw new ArgumentNullException(nameof(employeeRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public async Task<IActionResult> GetEmployees()
        {
            var employees = await _EmployRepository.GetEmployeesAsync();
            //automapper
            var employeeDtos = _mapper.Map<IEnumerable<EmployeeDto>>(employees);
            return Ok(employeeDtos);
        }

        [HttpGet(template: "{employeeId}", Name = nameof(GetEmployee))] //api/employees/{employeeId}
        //[Route(template: "{employeeId}")]
        public async Task<IActionResult> GetEmployee(Guid employeeId)
        {
            //var exist = await _EmployRepository.EmployeeExitAsync(employeeId);
            //if (!exist)
            //{
            //    return NotFound();
            //}

            var employees = await _EmployRepository.GetEmployeesAsnyc(employeeId);
            // 404 NotFound();
            if (employees == null)
            {
                return NotFound();
            }
            return new JsonResult(employees);
        }

        [HttpGet(template: "{FirstName}/{LastName}")]
        public async Task<ActionResult<IEnumerable<EmployeeDto>>> GetEmployee(string firstname, string lastname)
        {
            var employees = await _EmployRepository.GetEmployeesAsnyc(firstname, lastname);
            var employeeDtos = new List<EmployeeDto>();
            // without Automapper
            foreach (var employee in employees)
            {
                employeeDtos.Add(new EmployeeDto
                {
                    Id = employee.Id,
                    FirstName = employee.FirstName,
                    LastName = employee.LastName,
                    HiredDate = employee.HiredDate,
                    TaskList = employee.TaskList
                });
            }

            return Ok(employees);
        }

        [HttpPost]
        public async Task<ActionResult<EmployeeDto>> CreateEmployee([FromBody]EmployeeAddDto employee)
        {
            // add this code if without  [ApiController]
            //if (employee == null)
            //{
            //    return BadRequest();
            //}

            var entity = _mapper.Map<Employee>(employee);
            _EmployRepository.AddEmployee(entity);
            await _EmployRepository.SaveAsync();

            var ReturnDto = _mapper.Map<EmployeeDto>(entity);
            return CreatedAtRoute(nameof(GetEmployee), routeValues: new { employeeId = ReturnDto.Id }, value: ReturnDto);
        }

        [HttpDelete(template: "{employeeId}")]
        public async Task<IActionResult> DeleteEmployeeById(Guid employeeId)
        {
            if (!await _EmployRepository.EmployeeExistAsync(employeeId))
            {
                return NotFound();
            }

            var employeeEntity = await _EmployRepository.GetEmployeesAsnyc(employeeId);
            if (employeeEntity == null)
            {
                return NotFound();
            }

            //load employee if use cascade delete 
            //await _EmployRepository.GetEmployeesAsnyc(employeeId);
            _EmployRepository.DeleteEmployee(employeeEntity);
            await _EmployRepository.SaveAsync();

            return NoContent();
        }

        [HttpPatch(template: "{employeeId}")]
        public async Task<IActionResult> UpdateEmployee(Guid employeeId, JsonPatchDocument<EmployeeUpdateDto> patchDocument)
        {
            if (!await _EmployRepository.EmployeeExistAsync(employeeId))
            {
                return NotFound();
            }

            var employeeEntity = await _EmployRepository.GetEmployeesAsnyc(employeeId);
            if (employeeEntity == null)
            {
                return NotFound();
            }

            var dtoToPatch = _mapper.Map<EmployeeUpdateDto>(employeeEntity);
            patchDocument.ApplyTo(dtoToPatch);

            _mapper.Map(dtoToPatch, employeeEntity);
            _EmployRepository.UpdateEmployee(employeeEntity);

            await _EmployRepository.SaveAsync();

            return NoContent();
        }
    }
}
