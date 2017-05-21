// -----------------------------------------------------------------------
//  <copyright file="DataService.asmx.cs">
//   Copyright (c) Michal Pokorný. All Rights Reserved.
//  </copyright>
// -----------------------------------------------------------------------

namespace DynamicMenu.jQuery
{
    using System.ComponentModel;
    using System.Linq;
    using System.Web.Script.Services;
    using System.Web.Services;
    using DataLayer;

    /// <summary> Represents a web service used to communicate between database and front-end. </summary>
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [ToolboxItem(false)]
    [ScriptService]
    public class DataService : WebService
    {
        /// <summary> Gets the menus entities from data context and converts them into JSON. </summary>
        /// <returns> A <see cref="string" /> in JSON. </returns>
        [WebMethod]
        public string GetMenus()
        {
            using (var bc = new BussinesContext(default(DataContext)))
            {
                var c = bc.AddMenu("New category", MenuHierarchyLevel.Root, null);
                bc.AddMenu("Sub category", MenuHierarchyLevel.TopCategory, c);
                bc.AddMenu("Root category", MenuHierarchyLevel.Root, null);
                var menus = bc.DataContext.Menus?.ToList();
                return JsonHelpers.Serialize(menus);
            }
        }
    }
}