using LXP.api.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LXP.api.Services
{
    public interface IEmployeeRepository
    {
        // get all employees' info 
        Task<IEnumerable<Employee>> GetEmployeesAsync();
        Task<IEnumerable<Employee>> GetEmployeesAsnyc(string FirstName, string LastName);
        Task<Employee> GetEmployeesAsnyc(Guid EmployeeId);
        void AddEmployee(Employee employee);
        void UpdateEmployee(Employee employee);
        void DeleteEmployee(Employee employee);
        Task<bool> EmployeeExistAsync(Guid employeeId);

        //get all tasks' info
        Task<IEnumerable<EmployeeTask>> GetTasksAsync();
        Task<IEnumerable<EmployeeTask>> GetTasksAsync(string TaskList);
        // get a task by name
        Task<EmployeeTask> GetOneTaskAsync(string TaskName);
        void AddTask(EmployeeTask task);
        void UpdateTask(EmployeeTask task);
        void DeleteTask(EmployeeTask task);


        Task<bool> SaveAsync();
    }
}
