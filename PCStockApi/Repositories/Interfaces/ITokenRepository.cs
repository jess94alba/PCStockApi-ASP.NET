using System.Threading.Tasks;

namespace PCStockApi.Repositories
{
    public interface ITokenRepository
    {
        Task<bool> ValidarTokenAsync(string token);
    }
}
