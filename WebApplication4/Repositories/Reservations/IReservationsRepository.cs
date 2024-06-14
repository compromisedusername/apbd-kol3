using WebApplication4.Models;

namespace WebApplication4.Repositories.Reservations;

public interface IReservationsRepository
{
    Task AddReservationAsync(Reservation newReservation);
    Task SaveChangesAsync();
}