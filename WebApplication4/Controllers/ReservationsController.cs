using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using WebApplication4.DTOs;
using WebApplication4.Repositories;
using WebApplication4.Services.Reservations;

namespace WebApplication4.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ReservationsController : ControllerBase
{
    private IReservationsService _reservationsService;
    private IClientsRepository _clientsRepository;
    public ReservationsController(IReservationsService reservationService)
    {
        _reservationsService = reservationService;
    }
    

    [HttpPost("add")]
    public async Task<IActionResult> AddReservationForClient(RequestCreateReservationForClient reservationForClient)
    {
        try
        {
            var res = new
            {
                StatusCode = StatusCodes.Status201Created,
                IdReservation = await _reservationsService.CreateReservationAsync(reservationForClient)
            };
            
            return Ok(res);
        }
        catch (ArgumentException exc)
        {
            return BadRequest(new {StatusCode = 400, Message = exc});
        }


    }
    
    
}