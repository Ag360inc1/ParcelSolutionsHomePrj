using ParcelSolutionsHomePrj.Models;

namespace ParcelSolutionsHomePrj.Services
{
    public interface IDbService
    {
        List<CustomData> GetCustomData();
    }
}