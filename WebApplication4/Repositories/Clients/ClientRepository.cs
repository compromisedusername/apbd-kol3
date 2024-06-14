using Microsoft.EntityFrameworkCore;
using WebApplication4.Data;
using WebApplication4.DTOs;
using WebApplication4.Exceptions;
using WebApplication4.Models;

namespace WebApplication4.Repositories;

public class ClientRepository : IClientsRepository
{

    private readonly ApplicationContext _applicationContext;
    
    public ClientRepository(ApplicationContext applicationContext)
    {
        _applicationContext = applicationContext;
    }


    public async Task<bool> ClientDoesExist(int idClient)
    {
        return await _applicationContext.Client.FindAsync(idClient) is null;
    }

    public async Task<ResponseGetClientRescipesDto> GetClientReservations(int idClient)
    {
        var result = await _applicationContext.Client.Include(e => e.Reservations).Where(e=>e.IdClient==idClient).Select(e =>
            new ResponseGetClientRescipesDto()
            {
                Client = new ClientDto()
                {
                    Id = e.IdClient,
                    LastName = e.LastName,
                    Name = e.Name
                },
                Reservations = e.Reservations.Select(ee => new ReservationDto()
                {
                    Price = ee.Price,
                    DateTo = ee.DateTo,
                    DateFrom = ee.DateFrom
                }).ToList()
            }).FirstAsync();
        return result;
    }

    public async Task<bool> HasClientActiveReservations(int requestIdClient)
    {
       return await _applicationContext.Reservation.Include(e => e.Client).Where(e => e.IdClient == requestIdClient)
            .AnyAsync(e => !e.Fulfilled);
    }

    public async Task<Client> GetClient(int requestIdClient)
    {
        var client = await _applicationContext.Client.FindAsync(requestIdClient);
        if (client is null)
        {
            throw new DomainException(404, "Client for given ID " + requestIdClient + "not found ");
        }

        return client;
    }
}