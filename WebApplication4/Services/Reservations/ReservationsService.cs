using WebApplication4.DTOs;
using WebApplication4.Exceptions;
using WebApplication4.Models;
using WebApplication4.Repositories;
using WebApplication4.Repositories.Boats;
using WebApplication4.Repositories.BoatStandard;
using WebApplication4.Repositories.Reservations;

namespace WebApplication4.Services.Reservations;

public class ReservationsService : IReservationsService
{
    private readonly IReservationsRepository _reservationsRepository;
    private readonly IClientsRepository _clientsRepository;
    private readonly IBoatsRepository _boatsRepository;
    private readonly IBoatStandardsRepository _boatStandardsRepository;

    public ReservationsService(IReservationsRepository reservationsRepository, IClientsRepository clientsRepository, IBoatsRepository boatsRepository, IBoatStandardsRepository boatStandardsRepository)
    {
        _reservationsRepository = reservationsRepository;
        _clientsRepository = clientsRepository;
        _boatsRepository = boatsRepository;
        _boatStandardsRepository = boatStandardsRepository;
    }

    public async Task<int> CreateReservationAsync(RequestCreateReservationForClient request)
    {
        ValidateDateRange(request);
        
        var client = await GetClientAsync(request);
        var boatStandard = await GetBoatStandard(request);

        var newReservation = new Reservation
        {
            IdClient = request.IdClient,
            DateFrom = (request.DateFrom),
            DateTo = (request.DateTo),
            IdBoatStandard = request.IdBoatStandard,
            Fulfilled = true,
            
        };

        await EnsureClientHasNoActiveReservations(request);

        var freeSallBoats = await _boatsRepository.GetFreeSailBoatsAsync(boatStandard.Level,
            newReservation.DateFrom, newReservation.DateTo);

        var enoughFreeBoats = CheckIfWeHaveEnoughFreeBoats(request, freeSallBoats);

        if (!enoughFreeBoats)
        {
            newReservation.CancelReason = "Not enough boats";
            await _reservationsRepository.AddReservationAsync(newReservation);
            await _reservationsRepository.SaveChangesAsync();
            return newReservation.IdReservation;
        }

        newReservation.Price = CalculateFinalPrice(request, freeSallBoats, client);
        AssignFreeBoatsToReservation(request, freeSallBoats, newReservation);
        await _reservationsRepository.AddReservationAsync(newReservation);
        await _reservationsRepository.SaveChangesAsync();

        return newReservation.IdReservation;
    }

    private static void AssignFreeBoatsToReservation(RequestCreateReservationForClient request, List<Sallboat> freeSallBoats, Reservation newReservation)
    {
        foreach (var boat in freeSallBoats.Take(request.NumOfBoats))
        {
            newReservation.Sallboats.Add(boat);
        }
    }

    private int CalculateFinalPrice(RequestCreateReservationForClient request, List<Sallboat> freeSallBoats, Client client)
    {
        var price = freeSallBoats.Take(request.NumOfBoats).Sum(e => e.Price);
        return price - price * client.ClientCategory.DiscountPerc;
    }

    private static bool CheckIfWeHaveEnoughFreeBoats(RequestCreateReservationForClient request, List<Sallboat> freeSallBoats)
    {
        return request.NumOfBoats <= freeSallBoats.Count;
    }

    private async Task EnsureClientHasNoActiveReservations(RequestCreateReservationForClient request)
    {
        var hasClientActiveReservation = await _clientsRepository.HasClientActiveReservations(request.IdClient);
        if (hasClientActiveReservation)
        {
            throw new DomainException(404, "Client has active reservation!");
        }
    }

    private async Task<BoatStandard> GetBoatStandard(RequestCreateReservationForClient request)
    {
        var boatStandard = await _boatStandardsRepository.GetBoatStandard(request.IdBoatStandard);
        if (boatStandard is null) throw new DomainException(400, "Boat standard does not exist");
        return boatStandard;
    }

    private async Task<Client> GetClientAsync(RequestCreateReservationForClient request)
    {
        var client = await _clientsRepository.GetClient(request.IdClient);
        if (client is null) throw new DomainException(404, "Client does not exist!");

        return client;
    }

    private void ValidateDateRange(RequestCreateReservationForClient request)
    {
        if (request.DateFrom >= request.DateTo)
        {
            throw new DomainException(400,"DateFrom is later than DateTo!");
        }
    }
}