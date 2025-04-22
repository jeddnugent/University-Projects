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
	class ItemUnitTest
	{
		Item testItem;
		[SetUp]
		public void SetUp()
		{
			string[] test = { "bronze", "sword", "mighty" };

			testItem = new Item(test, "sword", "a bronze sword");
		}

		[Test]
		public void TestItemIdentifiable()
		{
			bool actual = testItem.AreYou("sword");
			Assert.AreEqual(true, actual);
		}

		[Test]
		public void TestShortDescrption()
		{
			string actual = testItem.ShortDescription;
			Assert.AreEqual("sword bronze", actual);
		}

		[Test]
		public void TestDescrption()
		{
			string actual = testItem.FullDescription;
			Assert.AreEqual("a bronze sword", actual);
		}


	}
}
