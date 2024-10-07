using Hotel.config;
using Hotel.DTOs.Requests;
using Hotel.DTOs.Response;
using Hotel.Models;
using Hotel.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Hotel.Controllers.v1
{
    [ApiController]
    [Route("api/v1/auth")]
    public class AuthController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public AuthController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] EmployeeRegisterDto registerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var employee = new Employee
            {
                FirstName = registerDto.FirstName,
                LastName = registerDto.LastName,
                Email = registerDto.Email,
                IdentificationNumber = registerDto.IdentificationNumber
            };

            await _employeeService.Register(employee, registerDto.Password);
            return Ok(new { message = "Employee registered successfully." });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] EmployeeLoginDto loginDto)
        {
            // Autenticar usando el email
            var employee = await _employeeService.Authenticate(loginDto.Email, loginDto.Password);
            if (employee == null)
                return Unauthorized();

            var token = JWT.GenerateJwtToken(employee);
            return Ok(new LoginResponseDto { Token = token });
        }
    }
}
