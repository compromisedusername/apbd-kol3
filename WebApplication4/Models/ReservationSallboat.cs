using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebApplication4.Models;
[PrimaryKey(nameof(IdSallboat), nameof(IdReservation))]
public class ReservationSallboat
{
 public int? IdSallboat { get; set; }
 public int? IdReservation { get; set; }
 
 [ForeignKey(nameof(IdSallboat))]
 public Sallboat? Sallboat { get; set; }
 [ForeignKey(nameof(IdReservation))]
 public Reservation? Reservation { get; set; }
}