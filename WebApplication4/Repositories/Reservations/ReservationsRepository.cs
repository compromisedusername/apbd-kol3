using WebApplication4.Data;
using WebApplication4.Services.Reservations;

namespace WebApplication4.Repositories.Reservations;

public class ReservationsRepository : IReservationsRepository
{
    private readonly ApplicationContext _applicationContext;

    public ReservationsRepository(ApplicationContext applicationContext)
    {
        _applicationContext = applicationContext;
    }
}