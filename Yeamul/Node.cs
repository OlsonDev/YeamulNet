using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Yeamul {
	[StructLayout(LayoutKind.Explicit)]
	public class Node {
		[FieldOffset(0)] private NodeType type;
		[FieldOffset(1)] private ScalarType scalarType;

		[FieldOffset(2)] private bool booleanValue;
		[FieldOffset(2)] private long longValue;
		[FieldOffset(2)] private double doubleValue;
		[FieldOffset(2)] private string stringValue;
		[FieldOffset(2)] private List<Node> sequenceValue;
		[FieldOffset(2)] private Dictionary<Node, Node> mapValue;
		[FieldOffset(2)] private Dictionary<string, Node> mapValueCommonCase;   

		// ReSharper disable once ConvertToAutoProperty
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
			throw new NotImplementedException();
		}

		private string ToStringAsSequence() {
			throw new NotImplementedException();
		}

		private string ToStringAsMap() {
			throw new NotImplementedException();
		}
	}
}