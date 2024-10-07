using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel.DTOs.Requests
{
    public class EmployeeLoginDto
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}