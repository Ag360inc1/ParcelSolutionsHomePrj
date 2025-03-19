using ParcelSolutionsHomePrj.Data;
using ParcelSolutionsHomePrj.Models;

namespace ParcelSolutionsHomePrj.Services
{
    public class DbService : IDbService
    {
        private readonly IDataRepository _repo;
        private readonly ILogger<DbService> _logger;

        public DbService(IDataRepository repo, ILogger<DbService> logger)
        {
            _repo = repo;
            _logger = logger;
        }

        public List<CustomData> GetCustomData()
        {
            try
            {
                _logger.LogInformation("Loading data from repo.");
                
                var data = _repo.GetDataResult();

                _logger.LogInformation("Data loaded from repo.");
                return data;
            }
            catch (Exception exception) 
            {
                _logger.LogError("Failed to Load data. Error {0}", exception.Message);         
                return [];
            }
            
        }        
    }
}
