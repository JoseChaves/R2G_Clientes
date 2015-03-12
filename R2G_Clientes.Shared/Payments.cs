using System;

namespace R2G_Clientes.Shared
{
	public class Payments
	{
			

			public static bool check(string ccNumber)
			{
			int sum = 0; 
			bool alternate = false;
			int length = ccNumber.Length;
			try{
			for (int i = length - 1; i >= 0; i--)
			{
				int n = Int32.Parse(ccNumber.Substring (i, i + 1));  //Integer.parseInt(ccNumber.substring(i, i + 1));
				if (alternate)
				{
					n *= 2;
					if (n > 9)
					{
						n = (n % 10) + 1;
					}
				}
				sum += n;
				alternate = !alternate;
			}
			}catch(ArgumentOutOfRangeException e) {
			}
			return (sum % 10 == 0);
		}
	}
		}
