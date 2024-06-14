using Microsoft.EntityFrameworkCore;
using WebApplication4.Data;
using WebApplication4.Models;

namespace WebApplication4.Repositories.Boats;

public class BoatsRepository : IBoatsRepository
{
    private readonly ApplicationContext _applicationContext;
    
    public BoatsRepository(ApplicationContext applicationContext)
    {
        _applicationContext = applicationContext;
    }

    public async Task<List<Sallboat>> GetFreeSailBoatsAsync(int boatStandardLevel, DateTime newReservationDateFrom, DateTime newReservationDateTo)
    {
        return await _applicationContext.Sallboat.Include(e => e.Reservations).Where(e =>
                e.IdBoatStandard >= boatStandardLevel && !e.Reservations.Any(r =>
                    r.DateFrom <= newReservationDateTo && r.DateTo >= newReservationDateFrom && !r.Fulfilled &&
                    r.CancelReason == null))
            .ToListAsync();
    }
}
