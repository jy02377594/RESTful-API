using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LXP.api.DbContexts;
using LXP.api.Entities;
using LXP.api.Services;
using Microsoft.EntityFrameworkCore;

namespace LXP.api.Services
{
    public class EmployeeRepository : IEmployeeRepository
    {

        private readonly RoutineDbContext _context;

        public EmployeeRepository(RoutineDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<Employee>> GetEmployeesAsync() {
            return await _context.Employees.ToListAsync();
        }

        //get all employees depends on firstname and lastname, name could be same
        public async Task<IEnumerable<Employee>> GetEmployeesAsnyc(string FirstName, string LastName)
        {
            if (FirstName == null)
            {
                throw new ArgumentNullException(nameof(FirstName));
            }
            if (LastName == null)
            {
                throw new ArgumentNullException(nameof(LastName));
            }
            return await _context.Employees
                .Where(x => x.FirstName == FirstName && x.LastName == LastName).ToListAsync();
        }

        //get an employee by id
        public async Task<Employee> GetEmployeesAsnyc(Guid EmployeeId)
        {
            if (EmployeeId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(EmployeeId));
            }

            return await _context.Employees.FirstOrDefaultAsync(x => x.Id == EmployeeId);
        }
        public void AddEmployee(Employee employee) {
            if (employee == null)
            {
                throw new ArgumentNullException(nameof(employee));
            }

            employee.Id = Guid.NewGuid();
            _context.Employees.Add(employee);
        }

        public void DeleteEmployee(Employee employee)
        {
            if (employee == null)
            {
                throw new ArgumentNullException(nameof(employee));
            }
            _context.Employees.Remove(employee);
        }

        public void UpdateEmployee(Employee employee)
        {
            // the reason why I can comment this line of core is EF Core realtimely trace entity。
            // _context.Entry(employee).State = EntityState.Modified;
        }

        public async Task<bool> EmployeeExistAsync(Guid employeeId)
        {
            if (employeeId == null)
            {
                throw new ArgumentNullException(nameof(employeeId));
            }
            return await _context.Employees
                .AnyAsync(x => x.Id == employeeId);
        }

        //get all tasks
        public async Task<IEnumerable<EmployeeTask>> GetTasksAsync()
        {
            return await _context.Tasks.ToListAsync();
        }

        //get task info by tasklist
        public async Task<IEnumerable<EmployeeTask>> GetTasksAsync(string TaskList)
        {
            if (TaskList == null || TaskList.Trim() == null)
            {
                throw new ArgumentNullException(nameof(TaskList));
            }

            return await _context.Tasks
                .Where(x => TaskList.Contains(x.TaskName))
                .OrderBy(x => x.Employee)
                .ToListAsync();
        }

        public async Task<EmployeeTask> GetOneTaskAsync(string TaskName)
        {
            if (TaskName == null)
            {
                throw new ArgumentNullException(nameof(TaskName));
            }

            return await _context.Tasks.FirstOrDefaultAsync(x => x.TaskName == TaskName);
        }



        public void AddTask(EmployeeTask task) {
            if (task == null)
            { 
               throw new ArgumentNullException(nameof(task));
            }

            _context.Tasks.Add(task);
        }
        public void UpdateTask(EmployeeTask task) {
            // the reason why I can comment this line of core is EF Core realtimely trace entity。
             _context.Entry(task).State = EntityState.Modified;
        }
        public void DeleteTask(EmployeeTask task) {
            if (task == null)
            {
                throw new ArgumentNullException(nameof(task));
            }

            _context.Tasks.Remove(task);
        }

        public async Task<bool> SaveAsync()
        {
            return (await _context.SaveChangesAsync()) >= 0;
        }
    }
}
