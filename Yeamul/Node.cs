﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.InteropServices;

namespace Yeamul {
	[StructLayout(LayoutKind.Explicit)]
	public class Node { // TODO: Consider converting to struct
		[FieldOffset(0)] private NodeType type;
		[FieldOffset(1)] private ScalarType scalarType;

		[FieldOffset(2)] private NumberType numberType;
		[FieldOffset(2)] private MapType mapType;

		[FieldOffset(3)] private bool booleanValue;
		[FieldOffset(3)] private long longValue;
		[FieldOffset(3)] private ulong ulongValue;
		[FieldOffset(3)] private Guid guidValue;
		[FieldOffset(3)] private double doubleValue;
		[FieldOffset(3)] private decimal decimalValue;
		[FieldOffset(3)] private string stringValue; // TODO: Consider always having this (own field offset)
		[FieldOffset(3)] private List<Node> sequenceValue;
		[FieldOffset(3)] private Dictionary<Node, Node> mapValueNodeKey;
		[FieldOffset(3)] private Dictionary<string, Node> mapValueStringKey;
		
		public NodeType Type {
			get { return type; }
			private set { type = value; }
		}

		public ScalarType ScalarType {
			get { return scalarType; }
			private set { scalarType = value; }
		}

		public bool IsUndefined => Type == NodeType.Undefined;
		public bool IsDefined   => Type != NodeType.Undefined;
		public bool IsScalar    => Type == NodeType.Scalar;
		public bool IsMap       => Type == NodeType.Map;
		public bool IsSequence  => Type == NodeType.Sequence;

		public bool IsNull      => Type == NodeType.Scalar && ScalarType == ScalarType.Null;
		public bool IsBoolean   => Type == NodeType.Scalar && ScalarType == ScalarType.Boolean;
		public bool IsNumber    => Type == NodeType.Scalar && ScalarType == ScalarType.Number;
		public bool IsString    => Type == NodeType.Scalar && ScalarType == ScalarType.String;

		public override string ToString() {
			switch (Type) {
				case NodeType.Undefined:
					throw new InvalidOperationException();
				case NodeType.Scalar:
					return ToStringAsScalar();
				case NodeType.Sequence:
					return ToStringAsSequence();
				case NodeType.Map:
					return ToStringAsMap();
				default:
					throw new ArgumentOutOfRangeException();
			}
		}

		private string ToStringAsScalar() {
			switch (scalarType) {
				case ScalarType.NonScalar:
					throw new InvalidOperationException();
				case ScalarType.Null:
					return "~";
				case ScalarType.Boolean:
					return booleanValue.ToString();
				case ScalarType.Number:
					return ToStringAsNumber();
				case ScalarType.String:
					return stringValue;
				default:
					throw new ArgumentOutOfRangeException();
			}
		}

		private string ToStringAsNumber() {
			switch (numberType) {
				case NumberType.Byte:	// TODO: InvalidOperationException?
				case NumberType.Char: // TODO: InvalidOperationException?
				case NumberType.Int16:
				case NumberType.Int32:
				case NumberType.Int64:
					return longValue.ToString();
				case NumberType.UInt16:
				case NumberType.UInt32:
				case NumberType.UInt64:
					return ulongValue.ToString();
				case NumberType.Guid:
					return guidValue.ToString();
				case NumberType.Float:
				case NumberType.Double:
				case NumberType.Extended:
					return doubleValue.ToString(CultureInfo.InvariantCulture);
				case NumberType.Decimal:
					return decimalValue.ToString(CultureInfo.InvariantCulture);
				default:
					throw new ArgumentOutOfRangeException();
			}
		}

		private string ToStringAsSequence() {
			throw new NotImplementedException();
		}

		private string ToStringAsMap() {
			throw new NotImplementedException();
		}
	}
}