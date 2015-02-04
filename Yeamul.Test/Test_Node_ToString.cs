using System;
using NUnit.Framework;

namespace Yeamul {
	[TestFixture]
	public class Test_Node_ToString {
		[Test]
		public void CanConstructImplicitlyFromBoolean() {
			Node node = true;
			Assert.AreEqual("true", node.ToString());
		}

		[Test]
		public void CanConstructImplicitlyFromInt16() {
			Node node = Int16.MaxValue;
			Assert.AreEqual("32767", node.ToString());
		}

		[Test]
		public void CanConstructImplicitlyFromInt32() {
			Node node = Int32.MaxValue;
			Assert.AreEqual("2147483647", node.ToString());
		}

		[Test]
		public void CanConstructImplicitlyFromInt64() {
			Node node = Int64.MaxValue;
			Assert.AreEqual("9223372036854775807", node.ToString());
		}

		[Test]
		public void CanConstructImplicitlyFromUInt16() {
			Node node = UInt16.MaxValue;
			Assert.AreEqual("65535", node.ToString());
		}

		[Test]
		public void CanConstructImplicitlyFromUInt32() {
			Node node = UInt32.MaxValue;
			Assert.AreEqual("4294967295", node.ToString());
		}

		[Test]
		public void CanConstructImplicitlyFromUInt64() {
			Node node = UInt64.MaxValue;
			Assert.AreEqual("18446744073709551615", node.ToString());
		}

		[Test]
		public void CanConstructImplicitlyFromGuid() {
			const string guidString = "2ea8d7c5-de5a-48f2-bb3c-a491f51a7ffe";
			Node node = Guid.ParseExact(guidString, "D");
			Assert.AreEqual(guidString, node.ToString());
		}

		[Test]
		public void CanConstructImplicitlyFromSingle() {
			Node node = Single.MaxValue;
			Assert.AreEqual("3.40282346638529E+38", node.ToString());
		}

		[Test]
		public void CanConstructImplicitlyFromDouble() {
			Node node = Double.MaxValue;
			Assert.AreEqual("1.79769313486232E+308", node.ToString());
		}

		[Test]
		public void CanConstructImplicitlyFromDecimal() {
			Node node = Decimal.MaxValue;
			Assert.AreEqual("79228162514264337593543950335", node.ToString());
		}

		[Test]
		public void CanConstructImplicitlyFromString() {
			const string expected = "expected";
			Node node = expected;
			Assert.AreEqual(expected, node.ToString());
		}
	}
}