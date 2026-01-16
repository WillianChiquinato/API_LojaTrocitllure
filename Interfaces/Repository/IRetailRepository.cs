using Api_LojaTricotllure.Models;

namespace Api_LojaTricotllure.Interfaces.Repository;

public interface IRetailRepository
{
    public Task<List<Retail>> GetRetails();
}