using Microsoft.EntityFrameworkCore;
using WebApplication4.Data;
using WebApplication4.Models;

namespace WebApplication4.Repositories.BoatStandard;

public class BoatStandardsesRepository : IBoatStandardsRepository
{
    private readonly ApplicationContext _applicationContext;
    
    public BoatStandardsesRepository(ApplicationContext applicationContext)
    {
        _applicationContext = applicationContext;
    }

    public async Task<Models.BoatStandard> GetBoatStandard(int requestIdBoatStandard)
    {
        return await _applicationContext.BoatStandards.Where(e => e.IdBoatStandard == requestIdBoatStandard).FirstAsync();
    }
}