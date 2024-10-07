using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel.DTOs.Requests
{
    public class GuestDto
    {
        [Required]
        [StringLength(255)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(255)]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [RegularExpression(@"\d{10}", ErrorMessage = "Invalid Identification Number.")]
        public string IdentificationNumber { get; set; }

        [Phone]
        public string PhoneNumber { get; set; }

        [Required]
        public DateTime BirthDate { get; set; }
    }

}
