using System;


namespace DBCorp
{
	class Service
	{
		private static VendingMachineTemplate mVendingMachine = null;

		static public VendingMachineTemplate VendingMachine 
		{
			get
			{
				return mVendingMachine ?? new VendingMachineTemplate();
			}
		}

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


		static void DecodeProducts(String[] arguments)
		{
			int index;

			Console.WriteLine("DBCorp Vending Machine - Products List");
			Console.WriteLine();

			index = 0;
			foreach (Product product in VendingMachine.Products)
			{
				Console.WriteLine("{0,3} - {1}", ++index, product.Name);
			}
		}


		static void DecodeOrder(String[] arguments)
		{
			int productIndex;

			try
			{
				if (arguments.Length < 2)
					throw new Exception("The product index should be the second argument. It should be a number obtained in the products list");

				productIndex = Int32.Parse(arguments[1]) - 1;
				Console.WriteLine("Product index is {0}", productIndex);

				Payment payment = new Payment();
				for (int index = 2; index < arguments.Length; index++)
				{
					string[] parts = arguments[index].Split(':');
					if (parts.Length != 2)
						throw new Exception(String.Format("Wrong format on parameter {0} : '{1}'" , index, arguments[index]));

					int kind = Int32.Parse(parts[0]);
					try
					{
						for (int input = 0; input < Int32.Parse(parts[1]); input++)
						{
							switch (kind)
							{
								case 1:
									payment.Add(new Coin_01());
									break;

								case 5:
									payment.Add(new Coin_05());
									break;

								case 25:
									payment.Add(new Coin_25());
									break;

								default:
									throw new Exception();
									break;
							}
						}
					}
					catch (Exception)
					{
						Console.WriteLine("Invalid prefix {0} in parameter '{1}'", kind, arguments[index]);
					}

				}

				Decimal Payed = payment.Total;
				String PayedDescription = payment.Description;

				var exchange = VendingMachine.OrderExchange(productIndex, payment);
				if (payment.Total == 0)
				{
					Console.WriteLine("All payment is devolved because removing rejected coins it is not enough");
				}

				Console.WriteLine("Product   : '{0}'",            VendingMachine.Products[productIndex].Name);
				Console.WriteLine("Price     :  {0,8:C2}",        VendingMachine.Products[productIndex].Price);
				Console.WriteLine("Payment   :  {0,8:C2} ({1})",  Payed, PayedDescription);
				Console.WriteLine("Exchange  :  {0,8:C2} ({1})",  exchange.Total, exchange.Description);
			}
			catch (Exception e)
			{
				throw e;
			}
		}


		static int DecodeArguments(String[] arguments)
		{
			switch (arguments[0])
			{
				case "-h":
				case "--help":
					Usage();
					return 0;

				case "-p":
				case "--products":
					DecodeProducts(arguments);
					return 0;

				case "-o":
				case "--order":
					DecodeOrder(arguments);
					return 0;

				default:
					Usage();
					return 0;
			}
		}


		static int Main(string[] arguments)
		{
			try
			{
				return DecodeArguments(arguments);
			}
			catch (Exception e)
			{
				Console.WriteLine("Error: {0}", e.Message);
				return 1;
			}
			
		}
	}
}
