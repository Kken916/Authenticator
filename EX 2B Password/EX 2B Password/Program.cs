using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EX_2B_Password
{
    class Program
    {
        static void Main(string[] args)
        {
           Begin:
            Console.WriteLine("--------------------------------------------------------------------------------");
            Console.WriteLine("\n\n\t\t PASSWORD AUTHENTICATION SYSTEM ");
            Console.WriteLine("\n\n\t\t Please select one option: ");
            Console.WriteLine("\t\t 1. Establish an account");
            Console.WriteLine("\t\t 2. Authenticate a user ");
            Console.WriteLine("\t\t 3. Exit the system ");
            Console.WriteLine("\n\n\t\t Enter selection: ");
            Console.WriteLine("\n\n--------------------------------------------------------------------------------");
            double PAS = Tasks.isItAnOption(Console.ReadLine());
            Console.Clear();
            switch (PAS)
            {
                case 1:
                    Tasks.NewUser();
                    Console.WriteLine("press enter to return to home screen");
                    Console.ReadLine();
                    Console.Clear();
                    goto Begin;

                case 2:
                    Tasks.isYouReal();
                    
                    goto Begin;
                case 3:
                    Tasks.ExitApp();
                    Console.ReadLine();
                    break;
            }
           
        }
    }
}
