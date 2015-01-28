using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.InteropServices;

namespace Yeamul {
	[StructLayout(LayoutKind.Explicit)]
	public class Node { // TODO: Consider converting to struct
		[FieldOffset(0)] private NodeType type;
		[FieldOffset(4)] private ScalarType scalarType;

		[FieldOffset(8)] private NumberType numberType;
		[FieldOffset(8)] private MapType mapType;

		[FieldOffset(12)] private string stringValue; // TODO: Consider always having this (own field offset)
		[FieldOffset(12)] private List<Node> sequenceValue; // TODO: Consider common cases List<long>, List<double>, List<string>
		[FieldOffset(12)] private Dictionary<Node, Node> mapValueNodeKey;
		[FieldOffset(12)] private Dictionary<string, Node> mapValueStringKey;

		[FieldOffset(20)] private bool booleanValue;
		[FieldOffset(20)] private long longValue;
		[FieldOffset(20)] private ulong ulongValue;
		[FieldOffset(20)] private Guid guidValue;
		[FieldOffset(20)] private double doubleValue;
		[FieldOffset(20)] private decimal decimalValue;
		
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
					return "broken";
					//return stringValue;
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