using Cinema.Data.Models;
using System.Threading.Tasks;

namespace Cinema.BLL.Services.Interfaces
{
    public interface ITokenService
    {
        Task<string> GenerateTokenAsync(User user);
    }
}
