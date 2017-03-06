using GildedRose.DAO;
using GildedRose.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GildedRose.Controllers
{
    public class ItemsController : ApiController
    {
        public IEnumerable<Item> GetAllItems()
        {
            return ItemDAO.GetItems();
        }

        [Authorize]
        public IHttpActionResult GetItem(int id)
        {
            string userName = string.Empty;
            if (Request != null)
            {
                userName = Request.GetOwinContext().Authentication.User.Identity.Name;
            }
            Item i = ItemDAO.BuyItem(id, userName);            
            return Ok(i);

            //
            var products = ItemDAO.GetItems();
            var product = products.FirstOrDefault((p) => p.id == id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }
    }
}
