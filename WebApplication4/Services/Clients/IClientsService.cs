using WebApplication4.DTOs;

namespace WebApplication4.Services;

public interface IClientsService
{
    Task<ResponseGetClientRescipesDto> GetClientReservations(int idClient);
}