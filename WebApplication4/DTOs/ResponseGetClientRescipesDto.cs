using System.ComponentModel.DataAnnotations;
using WebApplication4.Models;

namespace WebApplication4.DTOs;

public class ResponseGetClientRescipesDto
{
       [Required]
       public ClientDto Client { get; set; }
       public List<ReservationDto> Reservations { get; set; }
}

public class ReservationDto
{
       [Required]
       [DataType(DataType.DateTime)]
       public DateTime DateTo { get; set; } 

       [Required]
       [DataType(DataType.DateTime)]
       public DateTime DateFrom { get; set; }
       [Required]
       [Range(0,int.MaxValue)]
       public int Price;
}

public class ClientDto
{ 
       [Required]
       [Range(1,int.MaxValue)]
       public int Id { get; set; }

       [Required]
       [MaxLength(100)]
       public string Name { get; set; }
       [Required]
       [MaxLength(100)]
       public string LastName { get; set; }
}