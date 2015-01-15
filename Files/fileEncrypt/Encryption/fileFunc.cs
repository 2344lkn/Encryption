// github.... the place 4 indents do not exist...

// fileFunc.cs
using System;
using System.IO;
using System.Text;
using System.Security;
using System.Security.Cryptography;
using System.Security.AccessControl;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace fileEncrypt.Encryption;
{
	class fileCrypt
	{
		// Call this function to clear memory after use for security
		[System.Runtime.InteropServices.DllImport("KERNEL32.DLL", EntryPoint = "RtlZeroMemory")]
		public static extern bool ZeroMemory(IntPtr Destination, int Length);

		// We are using DES to test basic program function and file/encryption methods
		// testing all vectors to see which need to be secured.
		// The point of this project will be to eventually create our own algorithm.
		public static string GenerateKey()
		{
			// Create an instance of Symetric Algorithm. Key and IV is generated automatically.
			DESCryptoServiceProvider desCrypto = (DESCryptoServiceProvider)DESCryptoServiceProvider.Create();

			// Use the automatically generated key for Encryption.
			return ASCIIEncoding.ASCII.GetString(desCrypto.Key);
		}

		static void EncryptFile(string sInputFilename,
                                string sOutputFilename,
                                string sKey)
        {
            try
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("Encrypting File...");
                Console.ResetColor();

                FileStream fsInput = new FileStream(sInputFilename,
                    FileMode.Open,
                    FileAccess.Read);

                FileStream fsEncrypted = new FileStream(sOutputFilename,
                    FileMode.Create,
                    FileAccess.Write);

                DESCryptoServiceProvider DES = new DESCryptoServiceProvider();
                DES.Key = ASCIIEncoding.ASCII.GetBytes(sKey);
                DES.IV = ASCIIEncoding.ASCII.GetBytes(sKey);
                ICryptoTransform desencrypt = DES.CreateEncryptor();
                CryptoStream cryptostream = new CryptoStream(fsEncrypted,
                    desencrypt,
                    CryptoStreamMode.Write);

                byte[] bytearrayinput = new byte[fsInput.Length];
                fsInput.Read(bytearrayinput, 0, bytearrayinput.Length);
                cryptostream.Write(bytearrayinput, 0, bytearrayinput.Length);

                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("Encrypting Complete.");
                Console.ResetColor();

                cryptostream.Close();
                fsInput.Close();
                fsEncrypted.Close();

                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("Streams and Memory Cleared for security purposes.");
                Console.ResetColor();
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(e);
                Console.ResetColor();
            }
        }

        static void DecryptFile(string sInputFilename,
                                string sOutputFilename,
                                string sKey)
        {
            try
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("Decrypting File...");
                Console.ResetColor();

                DESCryptoServiceProvider DES = new DESCryptoServiceProvider();
                DES.Key = ASCIIEncoding.ASCII.GetBytes(sKey);
                DES.IV = ASCIIEncoding.ASCII.GetBytes(sKey);

                FileStream fsread = new FileStream(sInputFilename,
                    FileMode.Open,
                    FileAccess.Read);

                ICryptoTransform desdecrypt = DES.CreateDecryptor();
                CryptoStream cryptostreamDecr = new CryptoStream(fsread,
                    desdecrypt,
                    CryptoStreamMode.Read);

                StreamWriter fsDecrypted = new StreamWriter(sOutputFilename);
                fsDecrypted.Write(new StreamReader(cryptostreamDecr).ReadToEnd());

                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("Streams and Memory Cleared for security purposes.");
                Console.ResetColor();

                fsDecrypted.Flush();
                fsDecrypted.Close();

            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(e);
                Console.ResetColor();
            }
        }

        public static void crypt()
        {
        	csCrypt();
        }
        static void csCrypt()
        {
        	string sKey;

        	sKey = Key.create64Key();

        	// Pinned memory for later secure removal
        	GCHandle gch = GCHandle.Alloc(sKey, GCHandleType.Pinned);

        	//Encrypt file.
        	EncryptFile(@"C:\Data.txt",
        				@"C:\Encrypted.txt",
        				sKey);

        	fileFunc.AddEncryption(@"C:\Encrypted.txt");

        	//Decrypt file.
        	DecryptFile(@"C:\Encrypted.txt",
        				@"C:\Decrypted.txt",
        				sKey)

        	fileFunc.RemoveEncryption(@"C:\Decrypted.txt")

        	ZeroMemory(gch.AddOfPinnedObject(), sKey.Length * 2)
        	gch.Free();
        }
	}
}
