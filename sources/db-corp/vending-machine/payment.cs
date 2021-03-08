using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;


namespace DBCorp
{
	class Payment
	{
		private List<ICoin> coins;

		public void Add(ICoin coin)
		{
			this.coins.Add(coin);
			this.coins.Sort(delegate (ICoin left, ICoin right)
			{
				if (left.Value < right.Value) return -1;
				if (left.Value > right.Value) return +1;
				return 0;
			});
		}


		public void Clear()
		{
			this.coins.Clear();
		}


		public Decimal Total 
		{
			get
			{
				Decimal sum;

				sum = 0;
				foreach (ICoin coin in this.coins)
				{
					sum += coin.Value;
				}

				return sum;
			}
		}


		public string Description
		{
			get
			{
				Dictionary<int, int> mapping = new Dictionary<int, int>();

				foreach(ICoin coin in coins)
				{
					int value = Decimal.ToInt32(coin.Value * 100);
					if (!mapping.ContainsKey(value))
					{
						mapping[value] = 0;
					}
					mapping[value]++;
				}

				List<string> result = new List<string>();
				foreach (KeyValuePair<int, int> mapped in mapping)
				{
					ICoin item = null;

					switch (mapped.Key)
					{
						case 1:
							item = new Coin_01();
							break;

						case 5:
							item = new Coin_05();
							break;

						case 25:
							item = new Coin_25();
							break;

						case 50:
							item = new Coin_50();
							break;

						case 100:
							item = new Coin_100();
							break;

					}
					if (item != null)
						result.Add(String.Format("{0} coin{1} of {2}", mapped.Value, mapped.Value > 1 ? "s" : "", item.Name));
				}

				return String.Join(", ", result);
			}
		}


		public List<ICoin> Remove(Func<ICoin, Boolean> filter = null)
		{
			IEnumerable<ICoin> removed = coins.Where(filter ?? (s => true));
			List<ICoin> transfer = removed.ToList();
			coins.RemoveAll(coin => removed.Contains(coin));

			return transfer;
		}


		public Payment()
		{
			this.coins = new List<ICoin>();
		}

	}
}
