using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace EX_2B_Password
{
    public class Tasks
    {
        public static SortedList<string, string> accountsSaved = new SortedList<string, string>();
        public static int valid;
        public static int exist;
        public static void NewUser()
        {
            Console.WriteLine("\nPlease input a username ");
            string username = noSameUsers(Console.ReadLine());
            Console.WriteLine("\nPlease input a Password");
            string password = Console.ReadLine();
            StringBuilder hash = new StringBuilder();
            MD5CryptoServiceProvider md5provider = new MD5CryptoServiceProvider();
            byte[] bytes = md5provider.ComputeHash(new UTF8Encoding().GetBytes(password));

            for (int i = 0; i < bytes.Length; i++)
            {
                hash.Append(bytes[i].ToString("x2"));
            }
            password = hash.ToString();
            accountsSaved.Add(username, password);
            Console.WriteLine("\n\nthis is your encrypted password");
            Console.WriteLine(password);
            Console.WriteLine();

        }
        public static void isYouReal()
        {
            Console.WriteLine("\nTo validate your account\n Please input your username ");
            string username = Console.ReadLine();
            foreach (KeyValuePair<string, string> user in accountsSaved)
            {
                string userCheck = user.Key;

                if (username == userCheck)
                {
                    exist = 1;
                }
            }
            if (exist == 1)
            {
                exist = 2;
            }
            else
            {
                Console.WriteLine("\nthat username does not exist");
                    goto NoExist;
            }

            Console.WriteLine("\nPlease input your Password");
            string password = Console.ReadLine();

            StringBuilder hash = new StringBuilder();
            MD5CryptoServiceProvider md5provider = new MD5CryptoServiceProvider();
            byte[] bytes = md5provider.ComputeHash(new UTF8Encoding().GetBytes(password));

            for (int i = 0; i < bytes.Length; i++)
            {
                hash.Append(bytes[i].ToString("x2"));
            }
            password = hash.ToString();
            foreach (KeyValuePair<string, string> users in accountsSaved)
            {
                string trueUser = users.Key;
                string truePass = users.Value;
                if (trueUser == username && truePass == password)
                {
                    valid = 1;
                }
            }
            if (valid == 1)
            {
                Console.WriteLine("the user has been properly authenticated");
                valid = 2;
            }
            else
            {
                Console.WriteLine("the user was not authenticated");
            }
        NoExist:
            Console.WriteLine("press enter to return to home screen");
            Console.ReadKey();
            Console.Clear();
        }
       
        public static void ExitApp()
        {
            Console.WriteLine("Thanks for using my app here is a list of all on the accounts");
            Console.WriteLine("\t-username-\t-password-");
            foreach (KeyValuePair<string, string> users in accountsSaved)
            {
                string username = users.Key;
                string password = users.Value;
                Console.WriteLine($"\t {username} \t {password}");

            }
            Console.WriteLine("press any key to exit");
            Console.ReadKey();
        }
        public static double isItAnOption(string x1)
        {
            double x;
            while (!double.TryParse(x1, out x))
            {
                Console.WriteLine(" please input a VALID choice.(1,2,or 3)");
                x1 = Console.ReadLine();
            }
            return x;
        }
        public static string noSameUsers(string x1)
        {
          
            foreach (KeyValuePair<string, string> users in accountsSaved)
            {
                string trueUser = users.Key;
                while (x1 == trueUser)
                {
                    Console.WriteLine("that username is not available, please enter a new one");
                    x1 = Console.ReadLine();
                }
            }
            return x1;
        }
    }
}
