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

			Node n32 = -5;
			Console.WriteLine(n32);

			Node nu32 = 5u;
			Console.WriteLine(nu32);

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