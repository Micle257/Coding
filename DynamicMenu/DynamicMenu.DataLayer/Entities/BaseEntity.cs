// -----------------------------------------------------------------------
//  <copyright file="BaseEntity.cs">
//   Copyright (c) Michal Pokorný. All Rights Reserved.
//  </copyright>
// -----------------------------------------------------------------------

namespace DynamicMenu.DataLayer.Entities
{
    using System;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    /// <summary> Represents a base model class for all entities in this application. </summary>
    public abstract class BaseEntity
    {
        /// <summary> Gets or sets the primary identifier of this entity. </summary>
        /// <value> The <see cref="int" />. </value>
        [Key]
        public int Id { get; set; }

        /// <summary> Gets or sets the created time. </summary>
        /// <value> The <see cref="DateTimeOffset" />. </value>
        [DefaultValue("getutcdate()")]
        public DateTimeOffset CreatedAt { get; set; }

        /// <summary> Gets or sets the last updated time. </summary>
        /// <value> The <see cref="DateTimeOffset" />. </value>
        [DefaultValue("getutcdate()")]
        public DateTimeOffset LastUpdated { get; set; }
    }
}