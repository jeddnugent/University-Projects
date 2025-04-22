using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinAdventure2
{
	class Program
	{
		public static void Main() 
		{
			string playerName;
			string playerDescription;
			Player myPlayer;
			Item sword;
			string[] swordAtt = { "sword", "iron", "weapon" };
			Item rope;
			string[] ropeAtt = { "rope", "long", "equipment" };
			Item compass;
			string[] compassAtt = { "compass", "tool", "equipment" };
			Bag backpack;
			string[] backpackAtt = { "backpack", "bag" };
			LookCommand ItemSearch;
			bool look = true;
			Location spawn;
			string[] spawnAtt = { "spawn", "loading", "location" };



			Console.WriteLine("********* Welcome to Swin Adventure *********");

			//Creating Player
			Console.WriteLine("What is your name Adventurer?");
			playerName = Console.ReadLine().Trim();

			Console.WriteLine($"Hello {playerName}, How would you describe yourself?");
			playerDescription = Console.ReadLine().Trim();
			spawn = new Location(spawnAtt, "Spawn", "default location");
			myPlayer = new Player(playerName, playerDescription, spawn);

			//Creating GameObjects
			ItemSearch = new LookCommand();
			sword = new Item(swordAtt, "sword", "a strong iron sword");
			rope = new Item(ropeAtt, "rope", "a long peice of rope");
			compass = new Item(compassAtt, "compass", "a compass for navigating");
			backpack = new Bag(backpackAtt, "backpack", "a black backpack for storing items");

			myPlayer.Inventory.Put(sword);
			myPlayer.Inventory.Put(compass);
			backpack.Inventory.Put(rope);
			myPlayer.Inventory.Put(backpack);
			
			do
			{
				Console.WriteLine("Are you looking for anything? (yes or no)");
				string YesNo = Console.ReadLine();
				if (YesNo == "yes")
				{
					Console.WriteLine("What are you looking for?");
					string[] itemLook = Console.ReadLine().Trim().Split();
					Console.WriteLine(ItemSearch.Execute(myPlayer, itemLook));
				} 
				else look = false;

			} while (look == true);


			Console.ReadLine();

		}

	}
}
