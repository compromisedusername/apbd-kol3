using WebApplication4.DTOs;
using WebApplication4.Exceptions;
using WebApplication4.Repositories;

namespace WebApplication4.Services;

public class ClientsService : IClientsService
{
    private readonly IClientsRepository _clientsRepository;

    public ClientsService(IClientsRepository clientsRepository)
    {
        _clientsRepository = clientsRepository;
    }

    public async Task<ResponseGetClientRescipesDto> GetClientReservations(int idClient)
    {
        if (await _clientsRepository.ClientDoesExist(idClient)) {
            throw new DomainException(404, "Client with ID " + idClient + " doesnt exists!" );
        }

        var client = await _clientsRepository.GetClientReservations(idClient);

        return client;
    }
}


