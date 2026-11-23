using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            this._employeeRepository = employeeRepository;
        }

        public async Task AddEmployeeAsync(Employee employee)
        {
            if(employee.Salary <= 250_000) //restriction from last class
            {
                await _employeeRepository.AddEmployeeAsync(employee);
            }

            else
            {
               
            }
        }

        public async Task EditEmployeeAsync(Employee employeeEdited)
        {
            Employee employee = await _employeeRepository.GetEmployeeByIdAsync(employeeEdited.Id); // gets original employee with that id, so we can update it

            if (employee != null)//if the employee id does exist
            {
                employee.FirstName = employeeEdited.FirstName;
                employee.LastName = employeeEdited.LastName;
                employee.Position = employeeEdited.Position;
                employee.Salary = employeeEdited.Salary;

                await _employeeRepository.EditEmployeeAsync(employee);
                
            }

            else
            {
                //simply doesnt run it 
            }
        }

        public async Task GetDetailsAsync(Employee employee)
        {
            await _employeeRepository.GetDetailsAsync(employee);
        }
        public async Task<IEnumerable<Employee>> GetEmployeesAsync()
        {
            //business logic would be written here 
            return await _employeeRepository.GetEmployeesAsync();
        } 

        public async Task<Employee> GetEmployeeByIdAsync(int id)
        {
            return await _employeeRepository.GetEmployeeByIdAsync(id);
        }

    }
}
