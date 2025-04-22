using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SwinAdventure2;
using NUnit.Framework;

namespace UnitTesting
{
	[TestFixture]
	class PlayerUnitTests
	{
		Item testItem;
		Inventory testInvestory;
		Player testPlayer;
		Location testLocation;
		[SetUp]
		public void SetUp()
		{
			string[] test = { "bronze", "sword", "mighty" };
			testItem = new Item(test, "sword", "a bronze sword");
			
			testInvestory = new Inventory();

			string[] location = { "location" };
			testLocation = new Location(location, "Location", "Empty Location");

			testPlayer = new Player("jedd", "main character", testLocation);
		}

		[Test]
		public void TestPlayerIdentifiable()
		{
			bool actual = testPlayer.AreYou("me");
			Assert.AreEqual(true, actual);
		}


		[Test]
		public void TestPlayerLocateItem()
		{
			testPlayer.Inventory.Put(testItem);
			GameObject actual = testPlayer.Locate("sword");

			Assert.AreEqual(testItem, actual);
		}


		[Test]
		public void TestPlayerLocateSelf()
		{
			GameObject actual = testPlayer.Locate("me");

			Assert.AreEqual(testPlayer, actual);
		}


		[Test]
		public void TestPlayerLocateNothing()
		{
			GameObject actual = testPlayer.Locate("Gun");

			Assert.AreEqual(null, actual);
		}


		[Test]
		public void TestPlayerDescription()
		{

			testPlayer.Inventory.Put(testItem);
			string actual = testPlayer.FullDescription;

			Assert.AreEqual($"You are carrying: {testItem.Name} {testItem.FullDescription} ", actual);
		}
	}
}
