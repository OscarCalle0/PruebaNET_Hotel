// // // using System;
// // // using System.Collections.Generic;
// // // using System.Linq;
// // // using System.Threading.Tasks;
// // // using Hotel.config;
// // // using Hotel.DTOs.Requests;
// // // using Hotel.DTOs.Response;
// // // using Microsoft.AspNetCore.Mvc;


// // // namespace Hotel.Controllers.v1.Auth
// // // {
// // //     [ApiController]
// // //     [Route("api/v1/auth")]
// // //     public class AuthController : ControllerBase
// // //     {
// // //         protected readonly IUserRespository servicios;

// // //         public AuthController(IUserRespository userRepository)
// // //         {
// // //             servicios = userRepository;
// // //         }

// // //         // metodo que me genera un JWT
// // //         [HttpPost]
// // //         public async Task<IActionResult> GenerateToken(User user)
// // //         {
// // //             var token = JWT.GenerateJwtToken(user);

// // //             return Ok($"ACA ESTA SU TOKEN: {token}");
// // //         }

// // //         [HttpPost("login")]
// // // public IActionResult Login([FromBody] LoginRequestDto loginRequest)
// // // {
// // //     var employee = _employeeService.Authenticate(loginRequest.Username, loginRequest.Password);
// // //     if (employee == null)
// // //         return Unauthorized();

// // //     var tokenHandler = new JwtSecurityTokenHandler();
// // //     var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]);
// // //     var tokenDescriptor = new SecurityTokenDescriptor
// // //     {
// // //         Subject = new ClaimsIdentity(new Claim[]
// // //         {
// // //             new Claim(ClaimTypes.Name, employee.Id.ToString())
// // //         }),
// // //         Expires = DateTime.UtcNow.AddMinutes(Convert.ToDouble(_configuration["Jwt:ExpiresInMinutes"])),
// // //         SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
// // //     };
// // //     var token = tokenHandler.CreateToken(tokenDescriptor);
// // //     var tokenString = tokenHandler.WriteToken(token);

// // //     return Ok(new LoginResponseDto { Token = tokenString });
// // // }
// // //     }
// // // }


// // [ApiController]
// // [Route("api/v1/auth")]
// // public class AuthController : ControllerBase
// // {
// //     private readonly IEmployeeService _employeeService;
// //     private readonly IConfiguration _configuration;

// //     public AuthController(IEmployeeService employeeService, IConfiguration configuration)
// //     {
// //         _employeeService = employeeService;
// //         _configuration = configuration;
// //     }

// //     [HttpPost("login")]
// //     public IActionResult Login([FromBody] LoginRequestDto loginRequest)
// //     {
// //         var employee = _employeeService.Authenticate(loginRequest.Username, loginRequest.Password);
// //         if (employee == null)
// //             return Unauthorized();

// //         var tokenHandler = new JwtSecurityTokenHandler();
// //         var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]);
// //         var tokenDescriptor = new SecurityTokenDescriptor
// //         {
// //             Subject = new ClaimsIdentity(new Claim[]
// //             {
// //                 new Claim(ClaimTypes.Name, employee.Id.ToString())
// //             }),
// //             Expires = DateTime.UtcNow.AddMinutes(Convert.ToDouble(_configuration["Jwt:ExpiresInMinutes"])),
// //             SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
// //         };
// //         var token = tokenHandler.CreateToken(tokenDescriptor);
// //         var tokenString = tokenHandler.WriteToken(token);

// //         return Ok(new LoginResponseDto { Token = tokenString });
// //     }
// // }












// using Microsoft.AspNetCore.Mvc;
// using Microsoft.Extensions.Configuration;
// using Microsoft.IdentityModel.Tokens;
// using System.IdentityModel.Tokens.Jwt;
// using System.Security.Claims;
// using System.Text;

// namespace Hotel.Controllers.v1
// {
//     [ApiController]
//     [Route("api/v1/auth")]
//     public class AuthController : ControllerBase
//     {
//         private readonly IConfiguration _config;

//         public AuthController(IConfiguration config)
//         {
//             _config = config;
//         }

//         [HttpPost("login")]
//         public IActionResult Login([FromBody] EmployeeLoginDto loginDto)
//         {
//             // Example: Validate the employee (hardcoded for simplicity)
//             if (loginDto.Username == "admin" && loginDto.Password == "password")
//             {
//                 var token = GenerateJwtToken();
//                 return Ok(new { Token = token });
//             }

//             return Unauthorized();
//         }

//         private string GenerateJwtToken()
//         {
//             var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JWT_KEY"]));
//             var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

//             var claims = new[]
//             {
//                 new Claim(ClaimTypes.Name, "admin")
//             };

//             var token = new JwtSecurityToken(
//                 _config["JWT_ISSUER"],
//                 _config["JWT_AUDIENCE"],
//                 claims,
//                 expires: DateTime.Now.AddHours(1),
//                 signingCredentials: creds);

//             return new JwtSecurityTokenHandler().WriteToken(token);
//         }
//     }
// }
