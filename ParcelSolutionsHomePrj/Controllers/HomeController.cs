using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ParcelSolutionsHomePrj.Models;
using ParcelSolutionsHomePrj.Services;
using System.Diagnostics;

namespace ParcelSolutionsHomePrj.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IDbService _dbService;        

        public HomeController(ILogger<HomeController> logger, IDbService dbService)
        {
            _logger = logger;
            _dbService = dbService;            
        }

        public IActionResult Index()
        {
            List<CustomData> data = _dbService.GetCustomData();
            ViewBag.StoredProcedure = "Custom Data Load";

            return View(data);
        }       

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? Guid.NewGuid().ToString("N") });
        }        
    }
}
