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
	class IdentifiableObjectUnitTests
	{
		IdentifiableObject testObject;
		[SetUp]
		public void SetUp()
		{
			string[] test = { "fred", "bob", "jedd", "ryan" };

			testObject = new IdentifiableObject(test);
		}

		[Test]

		public void TestAreYou()
		{
			bool actual = testObject.AreYou("Fred");
			Assert.AreEqual(true, actual);
		}
		
		[Test]
		public void TestNotAreYou()
		{
			bool actual = testObject.AreYou("William");
			Assert.AreEqual(false, actual);
		}

		[Test]
		public void CaseSensitive()
		{
			bool actual = testObject.AreYou("JEDD");
			Assert.AreEqual(true, actual);
		}

		[Test]
		public void FirstID()
		{
			string actual = testObject.FirstID;
			Assert.AreEqual("fred", actual);
		}

		[Test]
		public void AddID()
		{
			testObject.AddIdentifier("sam");
			bool actual = testObject.AreYou("Sam");
			Assert.AreEqual(true, actual);
		}

	}
}
