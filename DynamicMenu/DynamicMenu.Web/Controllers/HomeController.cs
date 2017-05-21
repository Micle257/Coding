using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace DynamicMenu.Web.Controllers
{
    using DataLayer;
    using ViewModels;

    public class HomeController : Controller
    {
        public DataContext DataContext { get; }

        public HomeController(DataContext dataContext)
        {
            DataContext = dataContext;
        }

        public IActionResult Index()
        {
            ViewData["Title"] = "Domovska stranka";
            return View();
        }

        public IActionResult Menu()
        {
            using (var bc = new BussinesContext(DataContext))
            {
                var categories = bc.GetCategories(bc.GetMenus());
                var viewModel = new MenusViewModel { Categories = categories.Where(c=>c.Menu.MenuHierarchyLevel==MenuHierarchyLevel.Root).ToList()};
                return PartialView("_CategoryMenu", viewModel);
            }
        }

        public IActionResult About()
        {
            ViewData["Title"] = "O nas";
            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Title"] = "Kontakt";
            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
