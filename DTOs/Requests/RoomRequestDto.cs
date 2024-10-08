using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel.DTOs.Requests
{
    public class RoomRequestDto
    {
        [Required]
        public string RoomNumber { get; set; }

        [Required]
        public int RoomTypeId { get; set; }

        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "Price per night must be a positive value.")]
        public double PricePerNight { get; set; }

        public bool Availability { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Max occupancy must be at least 1.")]
        public int MaxOccupancyPersons { get; set; }
    }

}
