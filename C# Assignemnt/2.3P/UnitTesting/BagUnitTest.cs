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
	class BagUnitTest
	{
		Item testItem;
		Inventory testInvestory;
		Bag testBag;
		Bag nestedBag;
		[SetUp]
		public void SetUp()
		{
			string[] test = { "bronze", "sword", "mighty" };
			string[] bag = {"pack"};
			string[] bag2 = {"nested"};
			testItem = new Item(test, "sword", "a bronze sword");

			testInvestory = new Inventory();

			testBag = new Bag(bag, "backpack", "holds the map");
			
			nestedBag = new Bag(bag2, "nested", "holds the maps");
		}

		[Test]
		public void TestBagLocateItems()
		{
			testBag.Inventory.Put(testItem);
			GameObject actual = testBag.Locate("sword");

			Assert.AreEqual(testItem, actual);
		}


		[Test]
		public void TestBagLocateItself()
		{
			testBag.Inventory.Put(testItem);
			GameObject actual = testBag.Locate("pack");

			Assert.AreEqual(testBag, actual);
		}


		[Test]
		public void TestBagLocateNothing()
		{
			testBag.Inventory.Put(testItem);
			GameObject actual = testBag.Locate("Gun");

			Assert.AreEqual(null, actual);
		}


		[Test]
		public void TestBagLocateNested()
		{
			testBag.Inventory.Put(nestedBag);
			GameObject actual = testBag.Locate("nested");

			Assert.AreEqual(nestedBag, actual);
		}

		[Test]
		public void TestBagLocateNestedOther()
		{
			testBag.Inventory.Put(nestedBag);
			testBag.Inventory.Put(testItem);
			GameObject actual = testBag.Locate("sword");

			Assert.AreEqual(testItem, actual);
		}


		[Test]
		public void TestBagNotLocateNestedItems()
		{
			testBag.Inventory.Put(nestedBag);
			nestedBag.Inventory.Put(testItem);
			GameObject actual = testBag.Locate("sword");

			Assert.AreEqual(null, actual);
		}
	}
}
