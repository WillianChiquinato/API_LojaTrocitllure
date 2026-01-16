using Api_LojaTricotllure.Models;
using Api_LojaTricotllure.Response;

namespace Api_LojaTricotllure.Interfaces;

public interface IRetailService
{
    public Task<CustomResponse<List<Retail>>> GetRetails();
}