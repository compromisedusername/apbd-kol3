using System.ComponentModel.DataAnnotations;

namespace WebApplication4.Models;

public class BoatStandard
{
    [Key]
    public int IdBoatStandard { get; set; }
    [MaxLength(100)] public string Name { get; set; }
    public int Level { get; set; }

    public ICollection<Sallboat> Sallboats { get; set; } = new HashSet<Sallboat>();
}