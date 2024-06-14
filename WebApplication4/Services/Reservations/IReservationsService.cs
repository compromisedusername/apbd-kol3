using WebApplication4.DTOs;

namespace WebApplication4.Services.Reservations;

public interface IReservationsService
{
    Task<int> CreateReservationAsync(RequestCreateReservationForClient request);
}