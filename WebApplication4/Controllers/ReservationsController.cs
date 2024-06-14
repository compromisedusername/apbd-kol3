using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using WebApplication4.DTOs;
using WebApplication4.Repositories;
using WebApplication4.Services.Reservations;

namespace WebApplication4.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ReservationsController
{
    private IReservationsService _reservationsService;
    private IClientsRepository _clientsRepository;
    public ReservationsController(IReservationsService reservationService)
    {
        _reservationsService = reservationService;
    }
    

    [HttpPost]
    public async Task<IActionResult> AddReservationForClient(RequestCreateReservationForClient reservationForClient)
    {

        await _clientsRepository.ClientDoesExist(reservationForClient.IdClient);
        await _reservationsService.IsDateFromIsLaterThanDue(reservationForClient.DateFrom, reservationForClient.DateTo);
        await _reservationsService.ClientDoesHaveAlreadyActiveReservation(reservationForClient.IdClient); // Active reservation -- reservation which is nor accepted nor cancelled
    }
    
    
}