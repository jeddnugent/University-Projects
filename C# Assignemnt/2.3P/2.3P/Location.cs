using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinAdventure2
{
	public class Location : GameObject, IHaveInventory
	{
		private Inventory _inventory;
		public Location(string[] ids,  string name, string desc) : base(ids, name, desc)
		{
			_inventory = new Inventory();
		}

		public GameObject Locate(string id)
		{
			if (AreYou(id))
			{
				return this;
			}
			else
			{
				return Inventory.Fetch(id);
			}
		}

		
		public Inventory Inventory 
		{
			get
			{
				return _inventory;
			}
		}


		public override string FullDescription
		{
			get
			{
				return $"In the {Name} you can see: {Inventory.ItemList}";
			}
		}

	}
}
