using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace DynamicMenu.Web.Controllers
{
    using DataLayer;
    using ViewModels;

    public class CategoryController : Controller
    {
        public DataContext DataContext { get; }

        public CategoryController(DataContext dataContext)
        {
            DataContext = dataContext;
        }

        [Route("/{slug}")]
        public IActionResult Index(string slug)
        {
            var menu = DataContext.Menus.FirstOrDefault(a => a.Slug == slug);
            if (menu == null) {
                return RedirectToAction("Index","Home");
                }
            var viewModel = new CategoryContentViewModel { Title = menu.DisplayName };
            return View(viewModel);
        }
    }
}