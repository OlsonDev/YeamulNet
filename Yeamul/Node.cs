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

		[FieldOffset(12)] private bool booleanValue;
		[FieldOffset(12)] private long longValue;
		[FieldOffset(12)] private ulong ulongValue;
		[FieldOffset(12)] private Guid guidValue;	// 16 bytes (unsafe: http://stackoverflow.com/questions/6949598/can-i-assume-sizeofguid-16-at-all-times)
		[FieldOffset(12)] private double doubleValue;
		[FieldOffset(12)] private decimal decimalValue; // 16 bytes (safe)

		[FieldOffset(28)] private string stringValue; // TODO: Consider always having this (own field offset)
		[FieldOffset(28)] private List<Node> sequenceValue; // TODO: Consider common cases List<long>, List<double>, List<string>
		[FieldOffset(28)] private Dictionary<Node, Node> mapValueNodeKey;
		[FieldOffset(28)] private Dictionary<string, Node> mapValueStringKey;
		
		public static readonly Node Null = new Node { type = NodeType.Scalar, scalarType = ScalarType.Null };

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

		public static implicit operator Node(bool value) {
			return new Node {
				type = NodeType.Scalar,
				scalarType = ScalarType.Boolean,
				booleanValue = value
			};
		}

		public static implicit operator Node(Int16 value) {
			return new Node {
				type = NodeType.Scalar,
				scalarType = ScalarType.Number,
				numberType = NumberType.Int16,
				longValue = value
			};
		}

		public static implicit operator Node(Int32 value) {
			return new Node {
				type = NodeType.Scalar,
				scalarType = ScalarType.Number,
				numberType = NumberType.Int32,
				longValue = value
			};
		}

		public static implicit operator Node(Int64 value) {
			return new Node {
				type = NodeType.Scalar,
				scalarType = ScalarType.Number,
				numberType = NumberType.Int64,
				longValue = value
			};
		}


		public static implicit operator Node(UInt16 value) {
			return new Node {
				type = NodeType.Scalar,
				scalarType = ScalarType.Number,
				numberType = NumberType.UInt16,
				ulongValue = value
			};
		}

		public static implicit operator Node(UInt32 value) {
			return new Node {
				type = NodeType.Scalar,
				scalarType = ScalarType.Number,
				numberType = NumberType.UInt32,
				ulongValue = value
			};
		}

		public static implicit operator Node(UInt64 value) {
			return new Node {
				type = NodeType.Scalar,
				scalarType = ScalarType.Number,
				numberType = NumberType.UInt64,
				ulongValue = value
			};
		}

		public static implicit operator Node(Guid value) {
			return new Node {
				type = NodeType.Scalar,
				scalarType = ScalarType.Number,
				numberType = NumberType.Guid,
				guidValue = value
			};
		}

		public static implicit operator Node(float value) {
			return new Node {
				type = NodeType.Scalar,
				scalarType = ScalarType.Number,
				numberType = NumberType.Float,
				doubleValue = value
			};
		}


		public static implicit operator Node(double value) {
			return new Node {
				type = NodeType.Scalar,
				scalarType = ScalarType.Number,
				numberType = NumberType.Double,
				doubleValue = value
			};
		}

		public static implicit operator Node(decimal value) {
			return new Node {
				type = NodeType.Scalar,
				scalarType = ScalarType.Number,
				numberType = NumberType.Decimal,
				decimalValue = value
			};
		}

		public static implicit operator Node(string value) {
			return new Node {
				type = NodeType.Scalar,
				scalarType = ScalarType.String,
				stringValue = value
			};
		}
	}
}