// -----------------------------------------------------------------------
//  <copyright file="MenuEntityTests.cs">
//   Copyright (c) Michal Pokorný. All Rights Reserved.
//  </copyright>
// -----------------------------------------------------------------------

namespace DynamicMenu.DataLayer.Tests.UnitTests
{
    using System;
    using Entities;
    using Xunit;

    public class MenuEntityTests
    {
        [Fact]
        public void ShouldGenerateSlugThrowWhenTheDisplayNameIsNullOrWhiteSpace()
        {
            var menu = new Menu();
            var menu1 = new Menu {DisplayName = "      "};
            Assert.Throws<ArgumentNullException>(() => menu.GenerateSlug());
            Assert.Throws<ArgumentNullException>(() => menu1.GenerateSlug());
        }

        [Fact]
        public void ShouldMenuGenerateSlug()
        {
            var menu = new Menu {DisplayName = "New category"};
            menu.GenerateSlug();
            Assert.Equal("new-category", menu.Slug);
        }

        [Fact]
        public void ShouldGenerateSlugThrowWhenDisplayNameHasNotValidFormat()
        {
            var menu = new Menu {DisplayName = "wrong'-\n\r\0"};
            Assert.Throws<FormatException>(() => menu.GenerateSlug());
        }
    }
}