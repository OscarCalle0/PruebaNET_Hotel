using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel.DTOs.Response
{
    public class RoomResponseDto
    {
        public int Id { get; set; }

        public string RoomNumber { get; set; }

        public int RoomTypeId { get; set; }

        public double PricePerNight { get; set; }

        public bool Availability { get; set; }

        public int MaxOccupancyPersons { get; set; }
    }
}