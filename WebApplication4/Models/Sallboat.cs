using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlTypes;

namespace WebApplication4.Models;

public class Sallboat
{
    [Key]
    public int IdSallboat { get; set; }
    [MaxLength(100)]
    public string Name { get; set; }
    public int Capacity { get; set; }
    [MaxLength(100)]
    public string Description { get; set; }
    public int IdBoatStandard { get; set; }
    [ForeignKey(nameof(IdBoatStandard))]
    public BoatStandard BoatStandard { get; set; }
    public int Price { get; set; }

    public ICollection<Reservation> Reservations { get; set; } = new HashSet<Reservation>();
}