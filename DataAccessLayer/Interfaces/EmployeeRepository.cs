using DataAccessLayer.Data;
using DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces
{
    public class EmployeeRepository : IEmployeeRepository //implementing the interace, meaning we have to implement all of the methods that exist in it
    {
        private readonly ApplicationDbContext _context;

        public EmployeeRepository(ApplicationDbContext applicationDbContext)
        {
            this._context = applicationDbContext;
        }

        //Implement GetEmployeesAsync method from our IEmployeeRepository interface
        
        //Adding employee for when we create 
        public async Task AddEmployeeAsync(Employee employee)
        {
            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();
        }

        public async Task EditEmployeeAsync(Employee employeeEdited)
        {
            _context.Employees.Update(employeeEdited);
            await _context.SaveChangesAsync();
        }
        public async Task GetDetailsAsync(Employee employeeDetials)
        {
            var employee = await _context.Employees.FindAsync(employeeDetials.Id);
        }
        public async Task<Employee> GetEmployeeByIdAsync(int id)
        {
            return await _context.Employees.FindAsync(id); //returns employee from DbSet that matches ID
        }
        public async Task<IEnumerable<Employee>> GetEmployeesAsync() 
        {
            return await _context.Employees.ToListAsync();
        }
    }
}
