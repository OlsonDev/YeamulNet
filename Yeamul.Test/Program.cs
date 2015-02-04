using System;

namespace Yeamul.Test {
	class Program {
		static void Main(string[] args) {
			Node nn = Node.Null;
			Console.WriteLine(nn);

			Node nbt = true;
			Console.WriteLine(nbt);

			Node nbf = false;
			Console.WriteLine(nbf);

			Node n16 = short.MinValue;
			Console.WriteLine(n16);

			Node n32 = int.MinValue;
			Console.WriteLine(n32);

			Node n64 = long.MinValue;
			Console.WriteLine(n64);

			Node nu16 = ushort.MaxValue;
			Console.WriteLine(nu16);

			Node nu32 = uint.MaxValue;
			Console.WriteLine(nu32);

			Node nu64 = ulong.MaxValue;
			Console.WriteLine(nu64);

			Node nf = 1.2f;
			Console.WriteLine(nf);

			Node nd = Math.PI;
			Console.WriteLine(nd);

			Node nm = 1.2345678901234567890m;
			Console.WriteLine(nm);

			Node ng = Guid.NewGuid();
			Console.WriteLine(ng);

			Node ns = "derp";
			Console.WriteLine(ns);

			Console.ReadKey();
		}
	}
}