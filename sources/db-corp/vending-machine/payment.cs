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
