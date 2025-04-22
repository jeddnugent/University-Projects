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
	class LookAtMeUnitTests
	{
		LookCommand LookCommandTest;
		Item testItem;
		Item testItem2;
		Bag testBag;
		Player testPlayer;
		Location testLocation;

		[SetUp]
		public void SetUp()
		{
			string[] test = { "gem", "glowing", "ruby" };
			string[] test2 = { "uke", "guitar"};
			string[] bag = { "pack" };
			
			string[] location = { "location" };
			testLocation = new Location(location, "Location", "Empty Location");

			testBag = new Bag(bag, "backpack", "holds the map");
			testItem = new Item(test, "gem", "a shiney Gem");
			testItem2 = new Item(test2, "unk", "a sharp Unk");
			

			testPlayer = new Player("jedd", "main character", testLocation);
			LookCommandTest = new LookCommand();
		}

		[Test]
		public void TestLookAtMe()
		{
			string[] lookTest1 = { "look", "at", "me" };
			string actual = LookCommandTest.Execute(testPlayer, lookTest1);
			Assert.AreEqual("You can see main character", actual);
		}

		[Test]
		public void TestLookAtGem()
		{
			string[] lookTest1 = { "look", "at", "gem" };
			testPlayer.Inventory.Put(testItem);
			string actual = LookCommandTest.Execute(testPlayer, lookTest1);
			Assert.AreEqual("You can see a shiney Gem", actual);
		}

		[Test]
		public void TestLookAtUke()
		{
			string[] lookTest1 = { "look", "at", "gem" };
			testPlayer.Inventory.Put(testItem2);
			string actual = LookCommandTest.Execute(testPlayer, lookTest1);
			Assert.AreEqual("gem cannot be found", actual);
		}

		[Test]
		public void TestLookAtGemInBag()
		{
			string[] lookTest1 = { "look", "at", "gem", "in", "pack" };

			testBag.Inventory.Put(testItem);
			testPlayer.Inventory.Put(testBag);

			
			string actual = LookCommandTest.Execute(testPlayer, lookTest1);
			Assert.AreEqual("You can see a shiney Gem", actual);
		}
		
		[Test]
		public void TestLookAtGemInNoBag()
		{
			string[] lookTest1 = { "look", "at", "gem", "in", "pack" };
			string actual = LookCommandTest.Execute(testPlayer, lookTest1);
			Assert.AreEqual("I cannot find the pack", actual);
		}

		[Test]
		public void TestLookAtNoGemInBag()
		{
			string[] lookTest1 = { "look", "at", "gem", "in", "pack" };
			testPlayer.Inventory.Put(testBag);
			string actual = LookCommandTest.Execute(testPlayer, lookTest1);
			Assert.AreEqual("gem cannot be found", actual);
		}

		[Test]
		public void TestInvalidLook()
		{
			string[] lookTest1 = { "look", "around" };
			string actual = LookCommandTest.Execute(testPlayer, lookTest1);
			Assert.AreEqual("I don’t know how to look like that", actual);
		}
	}
}
	
