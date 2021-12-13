using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Challenge1.Repo;
using System.Collections.Generic;
using Challenge1;

namespace Challenge1.Testing
{
    [TestClass]
    public class CRDTests
    {

        private static MenuRepo _menuRepo = new MenuRepo();

        public List<Menu> _menuItems;

        [TestInitialize]
        public void MyStockItem()
        {
            Menu expected = new Menu(1, "GoodStuff", "It's real good", 12.59m);
            _menuRepo.AddMenuItem(expected);
        }

        [TestMethod]
        public void TestAddMenuitem()
        {
            Menu item = new Menu(1, "GoodStuff", "It's real good", 12.59m);

            bool actual = _menuRepo.AddMenuItem(item);

            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void TestReturnMenuItems()
        {
            MyStockItem();
            List<Menu> listOfAllMenuItems = _menuRepo.ReturnMenuItems();
        }

        [TestMethod]
        public void TestDeleteMenuItem()
        {
            Menu item = new Menu(1, "GoodStuff", "It's real good", 12.59m);
            bool expected = true;

            bool actual = _menuRepo.DeleteMenuItem(item);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestGetMenuItemByMealNumber()
        {
            Menu expected = new Menu(1, "GoodStuff", "It's real good", 12.59m);
            _menuRepo.AddMenuItem(expected);
            Menu actual = _menuRepo.GetMenuItemByMealNumber(1);
        }
    }
}
