using System.ComponentModel.DataAnnotations;

namespace WebApplication4.DTOs;

public class RequestCreateReservationForClient
{
    [Required]
    [Range(1,Int32.MaxValue)]
    public int IdClient { get; set; }
    
    [Required]
    [DataType(DataType.DateTime)] 
    public DateTime DateFrom { get; set; }
    
    [Required]
    [DataType(DataType.DateTime)] 
    public DateTime DateTo { get; set; }
    
    [Required]
    [Range(0,int.MaxValue)]
    public int IdBoatStandard { get; set; }
    [Required]
    [Range(0,int.MaxValue)]
    public int NumOfBoats { get; set; }
}