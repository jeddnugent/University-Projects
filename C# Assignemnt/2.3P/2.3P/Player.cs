using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinAdventure2
{
	public class Player : GameObject, IHaveInventory
	{
		private Inventory _inventory;
		private Location _location;

		public Player(string name, string desc, Location location) : base (new string[] {"me", "inventory"}, name, desc)
		{
			_inventory = new Inventory();
			_location = location;
			
		}

		public GameObject Locate(string id)
		{
			if (AreYou(id)) return this;
			else if (CheckLocation(id)) return Location;
			else return Inventory.Fetch(id);
		}

		public override string FullDescription
		{
			get
			{
				return $"You are carrying: {Inventory.ItemList}";
			}
		}

		public bool CheckLocation(string id)
		{
			if (Location.AreYou(id)) return true;
			else return false;
		}

		public Inventory Inventory
		{
			get
			{
				return _inventory;
			}
		}

		public Location Location
		{
			get
			{
				return _location;
			}
		}
		

	}
}
