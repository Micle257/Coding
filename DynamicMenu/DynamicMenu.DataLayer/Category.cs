using System;
using System.Collections.Generic;
using System.Text;

namespace DynamicMenu.DataLayer
{
    /// <summary>
    /// Represents a data model for category.
    /// </summary>
    public class Category
 {
        /// <summary>
        /// Gets the title.
        /// </summary>
        /// <value>
        /// The <see cref="String"/>.
        /// </value>
        public string Title => Menu.DisplayName;
        /// <summary>
        /// Gets or sets the reference to menu entity.
        /// </summary>
        /// <value>
        /// The <see cref="Menu"/>.
        /// </value>
        public Menu Menu { get; set; }
        /// <summary>
        /// Gets or sets the children categories.
        /// </summary>
        /// <value>
        /// The list of the <see cref="Category"/>.
        /// </value>
        public IList<Category> Children { get; set; }
    }
}
