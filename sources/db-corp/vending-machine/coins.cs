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
			this.Name  = "one cent";
			this.Value =  0.01m;
		}
	}


	class Coin_05 : ICoin
	{
		public string	Name	{ get; private set; }
		public Decimal	Value	{ get; private set; }

		public Coin_05()
		{
			this.Name  = "five cents";
			this.Value = 0.05m;
		}
	}


	class Coin_25 : ICoin
	{
		public string	Name	{ get; private set; }
		public Decimal	Value	{ get; private set; }

		public Coin_25()
		{
			this.Name  = "25 cents";
			this.Value =  0.25m;
		}
	}


	class Coin_50 : ICoin
	{
		public string	Name	{ get; private set; }
		public Decimal	Value	{ get; private set; }

		public Coin_50()
		{
			this.Name  = "50 cents";
			this.Value =  0.50m;
		}
	}


	class Coin_100 : ICoin
	{
		public string	Name	{ get; private set; }
		public Decimal	Value	{ get; private set; }

		public Coin_100()
		{
			this.Name  = "one real";
			this.Value =  1.00m;
		}
	}
}

