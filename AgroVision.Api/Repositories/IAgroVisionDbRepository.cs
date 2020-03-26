using AgroVision.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AgroVision.Api.Repositories
{
    public interface IAgroVisionDbRepository
    {
        Task<UserCalculationModel> CreateUserCalculation(UserCalculationModel model);
        Task DeleteUserCalculation(int id);
        Task<UserCalculationModel> GetUserCalculation(int id);
        Task<List<UserCalculationModel>> GetUserCalculationFilter(GetUserCalculationModel model);
        Task<UserCalculationModel> UpdateUserCalculation(UserCalculationModel model);
    }
}