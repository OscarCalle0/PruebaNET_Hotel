using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hotel.Models;

[Table("rooms")]
public class Room
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("id")]
    public int Id { get; set; }

    [Required]
    [StringLength(10)]
    [Column("room_number")]
    public string RoomNumber { get; set; }

    [Required]
    [Column("room_type_id")]
    public int RoomTypeId { get; set; }

    [ForeignKey("RoomTypeId")]
    public RoomType RoomType { get; set; }

    [Required]
    [Range(0, double.MaxValue)]
    [Column("price_per_night")]
    public double PricePerNight { get; set; }

    [Required]
    [Column("availability")]
    public bool Availability { get; set; }

    [Required]
    [Range(1, 10)]
    [Column("max_occupancy_persons")]
    public int MaxOccupancyPersons { get; set; }
}
