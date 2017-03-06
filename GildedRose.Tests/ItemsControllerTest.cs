using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GildedRose.DAO;
using GildedRose.Models;
using GildedRose.Controllers;
using System.Linq;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Results;

namespace GildedRose.Tests
{
    [TestClass]
    public class ItemsControllerTest
    {
        #region Init 

        ItemsController itemsController = new ItemsController();

        Item testItem1 = new Item
        {
            id = 1111,
            name = "Test Item 1111",
            description = "Test Item 1111 Description",
            price = 1000,
            available = true,
            soldToName = string.Empty
        };

        Item testItem2 = new Item
        {
            id = 2222,
            name = "Test Item 2222",
            description = "Test Item 2222 Description",
            price = 2500,
            available = true,
            soldToName = "Test User 2"
        };

        Item testItem3 = new Item
        {
            id = 3333,
            name = "Test Item 3333",
            description = "Test Item 3333 Description",
            price = 3333,
            available = true,
            soldToName = "Test User 3"
        };

        #endregion

        /// <summary>
        /// Verify that GET returns a non-empty inventory. 
        /// </summary>
        [TestMethod]
        public void TestInventoryCount()
        {
            var items = itemsController.GetAllItems();

            Assert.IsTrue(items.Count() > 0, "The inventory count was zero.");
        }

        /// <summary>
        /// Add a new item to inventory, and verify that the item exists when GET is called. 
        /// </summary>
        [TestMethod]
        public void TestGetInventory()
        {
            ItemDAO.AddItem(testItem1);

            var items = itemsController.GetAllItems();

            Item item = items.FirstOrDefault(x => x.id == testItem1.id);

            Assert.AreEqual(testItem1.id, item.id);
            Assert.AreEqual(testItem1.name, item.name);
            Assert.AreEqual(testItem1.description, item.description);
            Assert.AreEqual(testItem1.price, item.price);
            Assert.AreEqual(testItem1.available, item.available);
            Assert.AreEqual(testItem1.soldToName, item.soldToName);
        }

        /// <summary>
        /// Add a new item to inventory, then buy it and verify it is indeed sold to test user. 
        /// </summary>
        [TestMethod]
        public void TestBuyItem()
        {
            ItemDAO.AddItem(testItem2);

            IHttpActionResult result = itemsController.GetItem(testItem2.id);
            var contentResult = result as OkNegotiatedContentResult<Item>;

            Assert.AreEqual(contentResult.Content.id, testItem2.id);
            Assert.AreEqual(contentResult.Content.name, testItem2.name);
            Assert.AreEqual(contentResult.Content.description, testItem2.description);
            Assert.AreEqual(contentResult.Content.price, testItem2.price);
            Assert.AreEqual(contentResult.Content.available, false); // available is false, thus sold
            Assert.AreEqual(contentResult.Content.soldToName, testItem2.soldToName); 
        }

        /// <summary>
        /// Add a new item to inventory, then "Test User 3" buys it. Then "Test Late Buyer" tries
        /// buying an already sold item, and the soldToName doesn't change.
        /// </summary>
        [TestMethod]
        public void TestCannotSellAlreadySoldItem()
        {
            ItemDAO.AddItem(testItem3);

            IHttpActionResult result = itemsController.GetItem(testItem3.id);
            var contentResult = result as OkNegotiatedContentResult<Item>;

            Assert.AreEqual(contentResult.Content.id, testItem3.id);
            Assert.AreEqual(contentResult.Content.name, testItem3.name);
            Assert.AreEqual(contentResult.Content.description, testItem3.description);
            Assert.AreEqual(contentResult.Content.price, testItem3.price);
            Assert.AreEqual(contentResult.Content.available, false); // available is false, thus sold
            Assert.AreEqual(contentResult.Content.soldToName, testItem3.soldToName);

            testItem3.soldToName = "Test Late Buyer";
            result = itemsController.GetItem(testItem3.id);
            contentResult = result as OkNegotiatedContentResult<Item>;

            Assert.AreNotEqual(contentResult.Content.soldToName, testItem3.soldToName);
        }
    }
}
