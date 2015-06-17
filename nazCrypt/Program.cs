using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

using nazCrypt.Data;
using nazCrypt.EncryptionDemos;

namespace nazCrypt
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Select an option:");
            Console.WriteLine("1. Create your own key");
            Console.WriteLine("2. Randomly generate key");
            
            Console.WriteLine("Enter your choice: ");
            int input = Console.Read();
            char choice = Convert.ToChar(input);
            
            switch (choice)
            {
                case'1':
                    Console.Write("Type in your key: ", Console.ReadLine());
                    string key = Key.createKey(Console.ReadLine());
                    Console.Write("Write your key pass: ", Console.ReadLine());
                    string pass = Console.ReadLine();
                    string keyPass = Key.authKey(pass);
                    string hash = Salt.hashPassword(pass);
                    
                    // string hash = Salt.hashPassword(key);
                    Salt.VerifyHashedPassword(pass, hash);
                    Console.WriteLine("hash: " + hash);
                    
                    Key.Verify(key, keyPass);
                    Console.Write("HashCheck Type your password: ", Console.ReadLine());
                    string hPass = Console.ReadLine();
                    bool verify = Salt.VerifyHashedPassword(hash, hPass);
                    break;
                case'2':
                    string rkey = Key.randomKey();
                    Console.Write("Write your key pass: ", Console.ReadLine());
                    string rpass = Console.ReadLine();
                    string rkeyPass = Key.authKey(rpass);
                    Key.Verify(rkey, rkeyPass);
                    break;
                case '3':
                    string test = "2dskfsdkl";
                    demo.DemoMain();
                    break;
            }
            Console.ReadKey();
        }
    }
}
