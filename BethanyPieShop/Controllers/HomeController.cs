using BethanyPieShop.Models;
using BethanyPieShop.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BethanyPieShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPieRepository _pieRepository;

        public HomeController(IPieRepository pieRepository)
        {
            _pieRepository = pieRepository;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            ViewBag.Title = "Pie overview";

            IEnumerable<Pie> pies = _pieRepository.GetAllPies().OrderBy(p => p.Name);

            HomeViewModel homeViewModel = new HomeViewModel()
            {
                Title = "Welcome to Bethany's Pie Shop",
                Pies = pies.ToList()
            };

            return View(homeViewModel);
        }
    }
}
