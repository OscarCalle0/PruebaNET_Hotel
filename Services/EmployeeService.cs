using Hotel.Data;
using Hotel.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using BCrypt.Net; 

namespace Hotel.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly ApplicationDbContext _context;

        public EmployeeService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Employee> Authenticate(string email, string password)
        {
           
            var employee = await _context.Employees.SingleOrDefaultAsync(e => e.Email == email);
            
            if (employee == null || !BCrypt.Net.BCrypt.Verify(password, employee.Password))
            {
               
                return null;
            }

            return employee;
        }

        public async Task Register(Employee employee, string password)
        {
         
            employee.Password = BCrypt.Net.BCrypt.HashPassword(password);

            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();
        }
    }
}
