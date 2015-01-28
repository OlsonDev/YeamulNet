using System;

namespace Yeamul {
	public class Node {
		public NodeType Type { get; set; }
		public ScalarType ScalarType { get; set; }

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