// // using System;
// // using System.Collections.Generic;
// // using System.Linq;
// // using System.Threading.Tasks;
// // using Hotel.config;
// // using Hotel.DTOs.Requests;
// // using Hotel.DTOs.Response;
// // using Microsoft.AspNetCore.Mvc;


// // namespace Hotel.Controllers.v1.Auth
// // {
// //     [ApiController]
// //     [Route("api/v1/auth")]
// //     public class AuthController : ControllerBase
// //     {
// //         protected readonly IUserRespository servicios;

// //         public AuthController(IUserRespository userRepository)
// //         {
// //             servicios = userRepository;
// //         }

// //         // metodo que me genera un JWT
// //         [HttpPost]
// //         public async Task<IActionResult> GenerateToken(User user)
// //         {
// //             var token = JWT.GenerateJwtToken(user);

// //             return Ok($"ACA ESTA SU TOKEN: {token}");
// //         }

// //         [HttpPost("login")]
// // public IActionResult Login([FromBody] LoginRequestDto loginRequest)
// // {
// //     var employee = _employeeService.Authenticate(loginRequest.Username, loginRequest.Password);
// //     if (employee == null)
// //         return Unauthorized();

// //     var tokenHandler = new JwtSecurityTokenHandler();
// //     var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]);
// //     var tokenDescriptor = new SecurityTokenDescriptor
// //     {
// //         Subject = new ClaimsIdentity(new Claim[]
// //         {
// //             new Claim(ClaimTypes.Name, employee.Id.ToString())
// //         }),
// //         Expires = DateTime.UtcNow.AddMinutes(Convert.ToDouble(_configuration["Jwt:ExpiresInMinutes"])),
// //         SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
// //     };
// //     var token = tokenHandler.CreateToken(tokenDescriptor);
// //     var tokenString = tokenHandler.WriteToken(token);

// //     return Ok(new LoginResponseDto { Token = tokenString });
// // }
// //     }
// // }


// [ApiController]
// [Route("api/v1/auth")]
// public class AuthController : ControllerBase
// {
//     private readonly IEmployeeService _employeeService;
//     private readonly IConfiguration _configuration;

//     public AuthController(IEmployeeService employeeService, IConfiguration configuration)
//     {
//         _employeeService = employeeService;
//         _configuration = configuration;
//     }

//     [HttpPost("login")]
//     public IActionResult Login([FromBody] LoginRequestDto loginRequest)
//     {
//         var employee = _employeeService.Authenticate(loginRequest.Username, loginRequest.Password);
//         if (employee == null)
//             return Unauthorized();

//         var tokenHandler = new JwtSecurityTokenHandler();
//         var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]);
//         var tokenDescriptor = new SecurityTokenDescriptor
//         {
//             Subject = new ClaimsIdentity(new Claim[]
//             {
//                 new Claim(ClaimTypes.Name, employee.Id.ToString())
//             }),
//             Expires = DateTime.UtcNow.AddMinutes(Convert.ToDouble(_configuration["Jwt:ExpiresInMinutes"])),
//             SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
//         };
//         var token = tokenHandler.CreateToken(tokenDescriptor);
//         var tokenString = tokenHandler.WriteToken(token);

//         return Ok(new LoginResponseDto { Token = tokenString });
//     }
// }
