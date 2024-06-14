using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Identity.Client;
using WebApplication4.Models;
using WebApplication4.Services;

namespace WebApplication4.Controllers;


[ApiController]
[Route("api/[controller]")]
public class ClientsController : ControllerBase
{

    private readonly IClientsService _clientsService;
    
    public ClientsController(IClientsService clientsService)
    {
        _clientsService = clientsService;
    }
    
    
    [HttpGet("{idClient:int}")]
    public async Task<IActionResult> GetClientReservations(int idClient)
    {
        var result = await _clientsService.GetClientReservations(idClient);

        return Ok(result);
    }
    
    
}