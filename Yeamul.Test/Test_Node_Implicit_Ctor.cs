﻿using System;
using NUnit.Framework;

namespace Yeamul {
	[TestFixture]
	public class Test_Node_Implicit_Ctor {
		[Test]
		public void CanConstructImplicitlyFromBoolean() {
			Node node = true;
			AssertNodeIsDefinedScalar(node);
			Assert.That(node.IsBoolean);
			AssertNodeHasTypes(node, NodeType.Scalar, ScalarType.Boolean, NumberType.NotANumber, MapType.NotApplicable);
		}

		[Test]
		public void CanConstructImplicitlyFromInt16() {
			Node node = Int16.MaxValue;
			AssertNodeIsDefinedScalarNumber(node);
			AssertNodeHasTypes(node, NodeType.Scalar, ScalarType.Number, NumberType.Int16, MapType.NotApplicable);
		}

		[Test]
		public void CanConstructImplicitlyFromInt32() {
			Node node = Int32.MaxValue;
			AssertNodeIsDefinedScalarNumber(node);
			AssertNodeHasTypes(node, NodeType.Scalar, ScalarType.Number, NumberType.Int32, MapType.NotApplicable);
		}

		[Test]
		public void CanConstructImplicitlyFromInt64() {
			Node node = Int64.MaxValue;
			AssertNodeIsDefinedScalarNumber(node);
			AssertNodeHasTypes(node, NodeType.Scalar, ScalarType.Number, NumberType.Int64, MapType.NotApplicable);
		}

		[Test]
		public void CanConstructImplicitlyFromUInt16() {
			Node node = UInt16.MaxValue;
			AssertNodeIsDefinedScalarNumber(node);
			AssertNodeHasTypes(node, NodeType.Scalar, ScalarType.Number, NumberType.UInt16, MapType.NotApplicable);
		}

		[Test]
		public void CanConstructImplicitlyFromUInt32() {
			Node node = UInt32.MaxValue;
			AssertNodeIsDefinedScalarNumber(node);
			AssertNodeHasTypes(node, NodeType.Scalar, ScalarType.Number, NumberType.UInt32, MapType.NotApplicable);
		}

		[Test]
		public void CanConstructImplicitlyFromUInt64() {
			Node node = UInt64.MaxValue;
			AssertNodeIsDefinedScalarNumber(node);
			AssertNodeHasTypes(node, NodeType.Scalar, ScalarType.Number, NumberType.UInt64, MapType.NotApplicable);
		}

		[Test]
		public void CanConstructImplicitlyFromGuid() {
			Node node = Guid.NewGuid();
			AssertNodeIsDefinedScalarNumber(node);
			AssertNodeHasTypes(node, NodeType.Scalar, ScalarType.Number, NumberType.Guid, MapType.NotApplicable);
		}

		private static void AssertNodeIsDefinedScalar(Node node) {
			Assert.That(node.IsDefined);
			Assert.That(node.IsScalar);
		}

		private static void AssertNodeIsDefinedScalarNumber(Node node) {
			AssertNodeIsDefinedScalar(node);
			Assert.That(node.IsNumber);
		}

		private void AssertNodeHasTypes(Node node, NodeType nodeType, ScalarType scalarType, NumberType numberType, MapType mapType) {
			Assert.AreEqual(node.NodeType, nodeType);
			Assert.AreEqual(node.ScalarType, scalarType);
			Assert.AreEqual(node.NumberType, numberType);
			Assert.AreEqual(node.MapType, mapType);
		}
	}
}