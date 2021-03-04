using System;
using System.Collections.Generic;
using System.Text;

namespace DBCorp
{
	class Product
	{
		public string  Name   { get; private set; }
		public Decimal Price  { get; private set; }

		public Product(string Name, Decimal Price)
		{
			this.Name  = Name;
			this.Price = Price;
		}

		public Product()
		{

		}
	}


	class VendingMachineBase
	{
		protected List<Product> mProducts;

		public Payment OrderExchange(int productIndex, Payment payment)
		{
			if (productIndex > this.mProducts.Count)
				throw new Exception("Invalide product index");

			Decimal Price = this.mProducts[productIndex - 1].Price;

			List<ICoin> rejected = payment.Remove( value => (value is Coin_01) || (value is Coin_05) );

			Payment exchange = new Payment();
			foreach (ICoin coin in rejected)
			{
				exchange.Add(coin);
			}

			if (Price > payment.Total)
			{
				List<ICoin> remaining = payment.Remove();
				foreach (ICoin coin in remaining)
				{
					exchange.Add(coin);
				}

				return exchange;
			}

			Decimal remainingValue = payment.Total - Price;
			while ( remainingValue > 0.25m )
			{
				exchange.Add( new Coin_25() );
				remainingValue -= 0.25m;
			}

			while (remainingValue > 0.05m)
			{
				exchange.Add(new Coin_05());
				remainingValue -= 0.05m;
			}

			while (remainingValue > 0.01m)
			{
				exchange.Add(new Coin_01());
				remainingValue -= 0.01m;
			}

			return exchange;
		}

		protected VendingMachineBase()
		{
			this.mProducts = new List<Product>();
		}
	}


	class VendingMachineTemplate : VendingMachineBase
	{
		public List<Product> Products 
		{ 
			get { return mProducts;  } 
		}

		public VendingMachineTemplate()
		{
			mProducts.Add( new Product(Name: "Cappuccino",     Price: 3.50m ));
			mProducts.Add( new Product(Name: "Mocha",          Price: 4.00m ));
			mProducts.Add( new Product(Name: "Café com leite", Price: 3.00m ));
		}
	}

}
