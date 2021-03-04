using System;
using System.Collections.Generic;

namespace DBCorp
{
	class Program
	{
		static void Usage()
		{
			string[] usage = new String[] {
				"DBCorp Vending Machine",
				"",
				"   > dbcvm --help",
				"   > dbcvm  -h",
				"",
				"        Show this help usage",
				"",
				"",
				"   > dbcvm --products",
				"",
				"        Show products list",
				"",
				"   > dbcvm --order [product_id]    1:[a]   5:[b]   10:[c]",
				"",
				"        Make an order of a product with product id number obtained on product",
				"        list, followed by quantity of coins separated by colon. First the coin ",
				"        value and after the quantity of that value. The values allowed is",
                "        1, 10, 25, 50, 100. So as example",
                "",
				"          > dbcvm --order  2  1:4  5:3  25:3  30:6  100:4",
				"",
				"               product_id  is  2",
				"",
				"                      4 coins of 0,01 sums 0,03",
                "                      3 coins of 0,05 sums 0,15",
				"                      3 coins of 0,25 sums 0,75",
				"                      6 coins of 0,30 sums 0,00    -- because 30 is NOT ALLOWED",
				"                      4 coins of 1,00 sums 4,00",
				"",
				"               The total sum is 4,93",
				"",
				""
			};

			foreach (string line in usage)
			{
				Console.WriteLine(line);
			}
		}

		static void Main(string[] args)
		{
			Usage();
	
			var VendingMachine = new VendingMachineTemplate();

			


			var payment = new Payment();
			payment.Add( new Coin_01() );
			//payment.Add( Coin.coin_10  );
			payment.Add( new Coin_05() );
			payment.Add( new Coin_05() );
			payment.Add( new Coin_01() );
			//payment.Add( Coin.coin_100 );
			//payment.Add( Coin.coin_01  );
			payment.Add( new Coin_25()  );
			payment.Add( new Coin_25() );

			payment.Add(new Coin_25());
			payment.Add(new Coin_25()); 
			payment.Add(new Coin_25());
			payment.Add(new Coin_25()); 
			payment.Add(new Coin_25());
			payment.Add(new Coin_25()); 
			payment.Add(new Coin_25());
			payment.Add(new Coin_25());
			payment.Add(new Coin_25());
			payment.Add(new Coin_25());
			payment.Add(new Coin_25());
			payment.Add(new Coin_25());
			payment.Add(new Coin_25());
			payment.Add(new Coin_25());
			payment.Add(new Coin_25());
			payment.Add(new Coin_25());




			Decimal Payed = payment.Total;

			var exchange = VendingMachine.OrderExchange(1, payment);
			if (payment.Total == 0)
			{
				Console.WriteLine("All payment is devolved because removing rejected coins it is not enough");
			}

			Console.WriteLine("Payment  {0,8:C2}", Payed);
			Console.WriteLine("Exchange {0,8:C2}", exchange.Total);






			Console.WriteLine(String.Join('\n', exchange));

		}
	}
}
