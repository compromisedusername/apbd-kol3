using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication4.Models;

public class Client
{
    [Key]
    public int IdClient { get; set; }
    [MaxLength(100)]
    public string Name { get; set; }
    [MaxLength(100)]
    public string LastName { get; set; }
    public DateTime Birthday { get; set; }
    [MaxLength(100)]
    public string Pesel { get; set; }
    [MaxLength(100)]
    public string Email { get; set; }
    public int IdClientCategory { get; set; }
    
    [ForeignKey(nameof(IdClientCategory))]
    public ClientCategory ClientCategory { get; set; }

    public ICollection<Reservation> Reservations { get; set; } = new HashSet<Reservation>();

}