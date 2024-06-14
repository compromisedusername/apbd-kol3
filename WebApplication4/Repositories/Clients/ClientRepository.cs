using Microsoft.EntityFrameworkCore;
using WebApplication4.Data;
using WebApplication4.DTOs;

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
}