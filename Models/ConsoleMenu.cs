using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostalService.Models
{
    public class ConsoleMenu
    {
        public void Menu(){
            bool loopMenu = true;

            while (loopMenu)
            {

                Console.WriteLine("*******************************");
                Console.WriteLine("   Paketleverans och spårning  ");
                Console.WriteLine("*******************************");
                Console.WriteLine("1. Registrera paket");
                Console.WriteLine("2. Spåra paket med försendelse-id");
                Console.WriteLine("3. Logga in som administratör");
                Console.WriteLine("4. Avsluta");
                Console.Write("Gör ett val mellan 1-4: ");

                string userInputFromMenu = Console.ReadLine();
                Console.Clear();

                switch (userInputFromMenu)
                {
                    case "1":
                        //Lägg in objekt från createparcel
                        Console.WriteLine("Du har valt 1");
                        break;
                    case "2":
                        //Lägg in metod från ParcelRegistry
                        Console.WriteLine("Du har valt 2");
                        break;
                    case "3":
                        //Skapa klass för inlogg administratör som kan spåra paket och få ut mer information än kunden. 
                        Console.WriteLine("Du har valt 3");
                        break;
                    case "4":
                        Console.WriteLine("*************************");
                        Console.WriteLine("*                       *");
                        Console.WriteLine("*  Programmet avslutas  *");
                        Console.WriteLine("*                       *");
                        Console.WriteLine("*************************");
                        Environment.Exit(0);
                        break;

                    default:
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Gör ett val mellan 1-4");
                        Console.ResetColor();
                        break;
                }
            }
        }
    }
}
