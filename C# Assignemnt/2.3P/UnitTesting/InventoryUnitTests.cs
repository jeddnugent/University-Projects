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
	class InventoryUnitTests
	{
		Item testItem;
		Inventory testInvestory;
		[SetUp]
		public void SetUp()
		{
			string[] test = { "bronze", "sword", "mighty" };

			testItem = new Item(test, "sword", "a bronze sword");
			testInvestory = new Inventory();
			testInvestory.Put(testItem);

		}


		[Test]
		public void TestFindItem()
		{
			bool actual = testInvestory.HasItem("sword");
			Assert.AreEqual(true, actual);
		}


		[Test]
		public void TestNotFindItem()
		{
			bool actual = testInvestory.HasItem("gun");
			Assert.AreEqual(false, actual);
		}


		[Test]
		public void TestFetchItem()
		{
			testInvestory.Fetch("sword");
			bool actual = testInvestory.HasItem("sword");
			Assert.AreEqual(true, actual);
		}


		[Test]
		public void TestTakeItem()
		{
			testInvestory.Take("sword");
			bool actual = testInvestory.HasItem("sword");
			Assert.AreEqual(false, actual);
		}

		[Test]
		public void TestItemList()
		{
			string actual = testInvestory.ItemList;
			Assert.AreEqual("sword a bronze sword ", actual);
		}
	}
}