using WebApplication4.DTOs;

namespace WebApplication4.Repositories;

public interface IClientsRepository
{
    Task<bool> ClientDoesExist(int idClient);
    Task<ResponseGetClientRescipesDto> GetClientReservations(int idClient);
}