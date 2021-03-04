using System;
using System.Collections.Generic;
using System.Text;

namespace DBCorp
{
	class Coin_01 : ICoin
	{
		public string	Name	{ get; private set; }
		public Decimal	Value	{ get; private set; }

		public Coin_01()
		{
			this.Name  = "um centavo";
			this.Value =  0.01m;
		}
	}


	class Coin_05 : ICoin
	{
		public string Name		{ get; private set; }
		public Decimal Value	{ get; private set; }

		public Coin_05()
		{
			this.Name  = "cinco centavos";
			this.Value = 0.05m;
		}
	}


	class Coin_25 : ICoin
	{
		public string Name { get; private set; }
		public Decimal Value { get; private set; }

		public Coin_25()
		{
			this.Name  = "vinte e cinco centavos";
			this.Value = 0.25m;
		}
	}
}
