using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinAdventure2
{
	public class Inventory
	{
		private List<Item> _items;

		public Inventory() 
		{
			_items = new List<Item>();
		}

		public bool HasItem(string id)
		{
			foreach(Item item in _items)
			{
				if (item.Name == id) return true;
			}
			return false;
		}

		public void Put(Item itm)
		{
			_items.Add(itm);
		}

		public Item Take(string id)
		{
			foreach (Item item in _items)
			{
				if (item.AreYou(id))
				{
					_items.Remove(item);
					return item;
				}
			}
			return null;
		}

		public Item Fetch(string id)
		{
			foreach(Item item in _items)
			{
				if (item.AreYou(id))
				{
					return item;
				}
			}

			return null;
		}


		public string ItemList
		{
			get
			{
				string ItemList = "";
				foreach(Item item in _items)
				{
					ItemList = ItemList + $"{item.Name} {item.FullDescription} ";
				}
				return ItemList;
			}
		}
	}
}
