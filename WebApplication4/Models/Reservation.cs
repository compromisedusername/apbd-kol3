using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlTypes;

namespace WebApplication4.Models;

public class Reservation
{
    

    [Key]
    public int IdReservation { get; set; }
    public int IdClient { get; set; }
    public DateTime DateFrom { get; set; }
    public DateTime DateTo { get; set; }
    public int IdBoatStandard { get; set; }
    public int Capacity { get; set; }
    public int NumOfBoats { get; set; }
    public bool Fulfilled { get; set; }
    public int Price { get; set; }
    [MaxLength(200)]
    public string? CancelReason { get; set; }
    
    
    
    [ForeignKey(nameof(IdClient))]
    public Client Client { get; set; }

    [ForeignKey(nameof(IdBoatStandard))]
    public BoatStandard BoatStandard { get; set; }
    
    public ICollection<Sallboat> Sallboats { get; set; }
}