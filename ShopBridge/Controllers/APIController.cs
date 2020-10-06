using ShopBridge.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Routing;

namespace ShopBridge.Controllers
{
    [RoutePrefix("MyAPI")]
    public class APIController : ApiController
    {       
        ItemRepository repository = new ItemRepository();

        // 1) Get Items for both the buckets
        [Route("GetItemsList")]
        public HttpResponseMessage GetItemsList(bool IsInventory)
        {
            
            List<Item> items = repository.GetItems(IsInventory).ToList();

            return Request.CreateResponse(HttpStatusCode.OK, items);
        }



        //3) Add Item to inventory
        [Route("AddInventory")]
        [HttpGet]
        public HttpResponseMessage AddInventory(int Id)
        {
            if(Id != 0)
            {
                bool val = repository.AddItem(Id);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            else
                return Request.CreateResponse(HttpStatusCode.NotFound);
        }

        // 4) Remove Item from inventory: RemoveItem
        [Route("RemoveInventory")]
        [HttpGet]
        public HttpResponseMessage RemoveInventory(int Id)
        {
            if (Id != 0)
            {
                bool val = repository.RemoveItem(Id);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            else
                return Request.CreateResponse(HttpStatusCode.NotFound);
        }
    }
}
