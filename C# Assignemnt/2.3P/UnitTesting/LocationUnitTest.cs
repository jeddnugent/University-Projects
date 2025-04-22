using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using SwinAdventure2;

namespace UnitTesting
{

	[TestFixture]
	class LocationUnitTest
	{
		Item testItem;
		Location testLocation;
		Player testPlayer;
		LookCommand testLook;

		[SetUp]
		public void SetUp()
		{
			string[] test = { "bronze", "sword", "mighty" };
			testItem = new Item(test, "sword", "a bronze sword");

			string[] location = { "location", "here" , "beach"};
			testLocation = new Location(location, "Location", "Empty Location");

			testPlayer = new Player("jedd", "main character", testLocation);

			testLook = new LookCommand();

		}

		[Test]
		public void TestLocateSelf()
		{
			GameObject actual = testLocation.Locate("here");
			Assert.AreEqual(testLocation, actual);
		}

		[Test]
		public void CheckPlayerLocation()
		{
			bool actual = testPlayer.CheckLocation("beach");
			Assert.AreEqual(true, actual);
		}

		[Test]
		public void TestLocationitems()
		{
			testLocation.Inventory.Put(testItem);
			GameObject actual = testLocation.Locate("sword");
			Assert.AreEqual(testItem, actual);
		}

		[Test]
		public void TestLookAtLocation()
		{
			testLocation.Inventory.Put(testItem);
			string[] lookTest1 = { "look", "at", "sword", "in", "beach" };
			string actual = testLook.Execute(testPlayer, lookTest1);
			Assert.AreEqual("You can see a bronzesword sword", actual);
		}
	}
}
