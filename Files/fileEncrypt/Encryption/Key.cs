// Key.cs
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace fileEncrypt.Encryption
{
	class Key
	{
		/* TODO: Properly secure functions with protection levels */

		public static string create64Key()
		{
			var chars = "!@#$%^&*()-=[];',./ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789abcdefghijklmnopqrstuvwxyz";
			var random = new Random();
			var rKey = new string(
				Enumerable.Repeat(chars, 8)
				.Select(s => s[random.Next(s.Length)])
				.ToArray());

			Console.ForegroundColor = ConsoleColor.Yellow;
			Console.WriteLine("Your key is {0}", result);
			Console.ResetColor();
			Console.WriteLine("");

			return result;
		}
	}
}
