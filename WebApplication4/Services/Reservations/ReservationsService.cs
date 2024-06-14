using WebApplication4.Repositories.Reservations;

namespace WebApplication4.Services.Reservations;

public class ReservationsService : IReservationsService
{
    private readonly IReservationsRepository _reservationsRepository;

    public ReservationsService(IReservationsRepository reservationsRepository)
    {
        _reservationsRepository = reservationsRepository;
    }
    
}