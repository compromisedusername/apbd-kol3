namespace WebApplication4.Repositories.BoatStandard;

public interface IBoatStandardsRepository
{
    Task<Models.BoatStandard> GetBoatStandard(int requestIdBoatStandard);
}