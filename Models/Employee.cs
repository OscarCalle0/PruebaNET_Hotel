using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hotel.Models;

[Table("employees")]
public class Employee
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("id")]
    public int Id { get; set; }

    [Required]
    [StringLength(50)]
    [Column("first_name")]
    public string FirstName { get; set; }

    [Required]
    [StringLength(50)]
    [Column("last_name")]
    public string LastName { get; set; }

    [Required]
    [EmailAddress]
    [StringLength(255)]
    [Column("email")]
    public string Email { get; set; }

    [Required]
    [StringLength(20)]
    [Column("identification_number")]
    public string IdentificationNumber { get; set; }

    [Required]
    [StringLength(255)]
    [Column("password")]
    public string Password { get; set; }
}
