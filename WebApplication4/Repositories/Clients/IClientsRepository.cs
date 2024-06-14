using WebApplication4.DTOs;
using WebApplication4.Models;

namespace WebApplication4.Repositories;

public interface IClientsRepository
{
    Task<bool> ClientDoesExist(int idClient);
    Task<ResponseGetClientRescipesDto> GetClientReservations(int idClient);
    Task<bool> HasClientActiveReservations(int requestIdClient);
    Task<Client> GetClient(int requestIdClient);
}