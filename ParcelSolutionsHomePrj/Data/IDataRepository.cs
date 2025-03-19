using ParcelSolutionsHomePrj.Models;

namespace ParcelSolutionsHomePrj.Data
{
    public interface IDataRepository
    {
        List<CustomData> GetDataResult();
    }
}