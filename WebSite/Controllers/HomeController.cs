using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebSite.Http;
using WebSite.Models;

namespace WebSite.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly HttpAPI _http;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            this._http = new HttpAPI();
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public async Task<IActionResult> Category()
        {
            var data = await this._http.Get<BaseResponse<List<CategoryModel>>>("https://localhost:7190/api/category/all", "", new Dictionary<string, string>());
            return View(data.Data);
        }

        public async Task<IActionResult> Products()
        {
            var data = await this._http.Get<BaseResponse<List<ProductModel>>>("https://localhost:7190/api/product/all", "", new Dictionary<string, string>());
            return View(data.Data);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}