using ShopBridge.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopBridge.Controllers
{
    public class ItemsController : Controller
    {
        // GET: HomePage
        public ActionResult HomePage()
        {
            return View();
        }

        // Get Details of Items
        public ActionResult GetDetails(int Id)
        {
            ItemRepository itemRepository = new ItemRepository();
            Item result = itemRepository.GetItemByID(Id);
            if (result == null)
            {
                ViewBag.result = "Item details not found";
            }
            return View(result);
        }
    }
}