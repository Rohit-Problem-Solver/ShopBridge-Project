using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopBridge.Models
{
    public class ItemRepository
    {
        // 1) fetch based on flag or not
        public ICollection<Item> GetItems(bool IsInventory)
        {
            List<Item> items = new List<Item>();
            using (ShopBridgeEntities db = new ShopBridgeEntities())
            {
                if (IsInventory)
                {
                    // Inventory bucket
                    items = db.Items.Where(x => x.IsInventory == true).ToList();
                }
                else
                {
                    // Component Bucket
                    items = db.Items.Where(x => x.IsInventory == false).ToList();
                }
            }
            return items;
        }

        // Get Item By ID
        public Item GetItemByID(int Id)
        {
            Item item = new Item();
            using (ShopBridgeEntities db = new ShopBridgeEntities())
            {
                if (Id !=0)
                {
                   
                    item = db.Items.Where(x => x.ItemId == Id).ToList().FirstOrDefault();
                }
                else
                {
                    return null;
                }
            }
            return item;
        }

        // 2) Add item to the inventory
        public bool AddItem(int Id)
        {
            if (Id != 0)
            {
                using (ShopBridgeEntities db = new ShopBridgeEntities())
                {
                    Item result = db.Items.Where(x => x.ItemId == Id).ToList().FirstOrDefault();
                    result.IsInventory = true;
                    db.SaveChanges();
                    return true;
                }
            }
            else
                return false;
        }

        //3) Remove Item frpom the inventory
        public bool RemoveItem(int Id)
        {
            if (Id != 0)
            {
                using (ShopBridgeEntities db = new ShopBridgeEntities())
                {
                    Item result = db.Items.Where(x => x.ItemId == Id).ToList().FirstOrDefault();
                    result.IsInventory = false;
                    db.SaveChanges();
                    return true;
                }
            }
            else
                return false;
        }


    }
}