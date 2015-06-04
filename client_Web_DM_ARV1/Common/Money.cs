using System;

namespace Common
{
	/// <summary>
	/// Summary description for Money.
	/// </summary>
	public class Money
	{
		private decimal val;
		//private string currency;

		public Money(decimal val)
		{
			this.val = val;
		}

		public decimal[] Allocate(int n)
		{
			return Money.Allocate(this.val, n);
		}
		public decimal[] Allocate(int[] ratios)
		{
			return Money.Allocate(this.val, ratios);
		}

		public decimal Amount
		{
			get { return val; }
		}

//		public string Currency
//		{
//			get { return currency; }
//		}

		public override string ToString()
		{
			return val.ToString();
		}

		public override bool Equals(object obj)
		{
			try
			{
				Money x = (Money)obj;
				return x.val == this.val;
			}
			catch (InvalidCastException /* ex */)
			{
				return false;
			}
		}

		public override int GetHashCode()
		{
			// dumb implementation
			return val.GetHashCode ();
		}

		/*  from Martin Fowler's PoEAA (pg. 130-131) */
		public static decimal[] Allocate(decimal v, int n)
		{
			decimal low = v / n;
			low = decimal.Round(low, 2);
			decimal high = low + 0.01m;
			decimal[] results = new decimal[n];
			int remainder = (int) v % n;
			for (int i = 0; i < remainder; i++)
				results[i] = high;
			for (int i = remainder; i < n; i++)
				results[i] = low;
			return results;
		}

		/*  from Martin Fowler's PoEAA (pg. 488) */
		public static decimal[] Allocate(decimal v, int[] ratios)
		{
			int total = 0;
			for (int i = 0; i < ratios.Length; i++)
				total += ratios[i];
			decimal remainder = v;
			decimal[] results = new decimal[ratios.Length];
			for (int i = 0; i < results.Length; i++)
			{
				results[i] = v * ratios[i] / total;
				remainder -= results[i];
			}
			for (int i = 0; i < remainder; i++)
			{
				results[i]++;
			}
			return results;
		}
	}
}
