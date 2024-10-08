using Hotel.Models;
using System.Threading.Tasks;

namespace Hotel.Services
{
    public interface IEmployeeService
    {
        Task<Employee> Authenticate(string email, string password); 
        Task Register(Employee employee, string password);
    }
}
