// -----------------------------------------------------------------------
//  <copyright file="CategoryController.cs">
//   Copyright (c) Michal Pokorný. All Rights Reserved.
//  </copyright>
// -----------------------------------------------------------------------

namespace DynamicMenu.Web.Controllers
{
    using System.Linq;
    using Infrastructure;
    using Infrastructure.ViewModels;
    using Microsoft.AspNetCore.Mvc;

    /// <summary> Represents a controller for category. </summary>
    public class CategoryController : Controller
    {
        /// <summary> Initializes a new instance of the <see cref="CategoryController" /> class. </summary>
        /// <param name="dataContext"> The data context. </param>
        public CategoryController(DataContext dataContext)
        {
            DataContext = dataContext;
        }

        /// <summary> Gets the data context. </summary>
        /// <value> The <see cref="DataContext" />. </value>
        public DataContext DataContext { get; }

        /// <summary> Defines the index action. </summary>
        /// <param name="slug"> The slug of the category. </param>
        /// <returns> An <see cref="IActionResult" /> </returns>
        [Route("/{slug}")]
        public IActionResult Index(string slug)
        {
            var menu = DataContext.Menus.FirstOrDefault(a => a.Slug == slug);
            if (menu == null)
                return RedirectToAction("Index", "Home");
            var viewModel = new CategoryContentViewModel {Title = menu.DisplayName};
            return View(viewModel);
        }
    }
}