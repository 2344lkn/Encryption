// Program.cs
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.AccessControl;

using fileEncrypt.Encryption;

namespace fileEncrypt
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("--------------------------------");
			Console.WriteLine("----- File Encrypt/Decrypt -----");
			Console.WriteLine("---------------------Ver-1.0.1.3");
			Console.WriteLine("");
			Console.WriteLine("This console program will encrypt or decrypt files");
			Console.WriteLine("using a unique key/pass system to secure the file");
			Console.WriteLine("only the correct password can unlock/decrypt the file.");
			Console.WriteLine("");
			Console.ForegroundColor = ConsoleColor.Green;
			Console.WriteLine("Press any key to get started.");
			Console.ResetColor();
			Console.ReadKey();

			Console.WriteLine("");
			Console.WriteLine("");

			Console.WriteLine("Select an option below by typing in the number and hitting enter.");
			Console.ForegroundColor = ConsoleColor.Cyan;
			Console.WriteLine("  (1) Encrypt a File");
			Console.WriteLine("  (2) Decrypt a File");
			Console.WriteLine("  (3) Testing");
			Console.ResetColor();

			Console.ForegroundColor = ConsoleColor.DarkCyan;
			Console.Write("Enter your choice: ");

			int input = Console.Read();
			char choice = Convert.ToChar(input);

			Console.ResetColor();
			Console.WriteLine("");

			switch (choice)
			{
				case '1':
					fileFunc.encryptFile();
					break;
				case '2':
					fileFunc.decryptFile();
					break;
				case '3':
					fileCrypt.crypt();
					break;
			}

			Console.ReadKey();
		}
	}
}
