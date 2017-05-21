using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DynamicMenu.Web.ViewModels
{
    using DataLayer;

    public class MenusViewModel
    {
        public IList<Category> Categories { get; set; }
    }
}
