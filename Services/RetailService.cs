using Api_LojaTricotllure.Interfaces;
using Api_LojaTricotllure.Interfaces.Repository;
using Api_LojaTricotllure.Models;
using Api_LojaTricotllure.Response;

namespace Api_LojaTricotllure.Services;

public class RetailService : IRetailService
{
    private readonly ILogger<RetailService> _logger;
    private readonly IRetailRepository _retailRepository;
    
    public RetailService(ILogger<RetailService> logger, IRetailRepository retailRepository)
    {
        _logger = logger;
        _retailRepository = retailRepository;
    }
    
    public async Task<CustomResponse<List<Retail>>> GetRetails()
    {
        try
        {
            var retails = await _retailRepository.GetRetails();

            return CustomResponse<List<Retail>>.SuccessTrade(retails);
        }
        catch (Exception ex)
        {
            return CustomResponse<List<Retail>>.Fail("Erro ao buscar lojas", ex.Message);
        }
    }
}