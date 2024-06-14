using WebApplication4.Models;

namespace WebApplication4.Repositories.Boats;

public interface IBoatsRepository
{
    Task<List<Sallboat>> GetFreeSailBoatsAsync(int boatStandardLevel, DateTime newReservationDateFrom, DateTime newReservationDateTo);
}