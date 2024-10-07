using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hotel.Models;

[Table("bookings")]
public class Booking
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("id")]
    public int Id { get; set; }

    [Required]
    [Column("room_id")]
    public int RoomId { get; set; }

    [ForeignKey("RoomId")]
    public Room Room { get; set; }

    [Required]
    [Column("guest_id")]
    public int GuestId { get; set; }

    [ForeignKey("GuestId")]
    public Guest Guest { get; set; }

    [Required]
    [Column("employee_id")]
    public int EmployeeId { get; set; }

    [ForeignKey("EmployeeId")]
    public Employee Employee { get; set; }

    [Required]
    [Column("start_date")]
    [DataType(DataType.DateTime)]
    public DateTime StartDate { get; set; }

    [Required]
    [Column("end_date")]
    [DataType(DataType.DateTime)]
    public DateTime EndDate { get; set; }

    [Required]
    [Column("total_cost")]
    [Range(0, double.MaxValue)]
    public double TotalCost { get; set; }
}
