using System;
using System.Globalization;

namespace Intel8086
{
    internal class Program
    {

        static void printRej(string[] data, string[] name)
        {
            for (int i = 0; i < data.Length; i++)
            {
                int j = i + 1;
                Console.WriteLine("Rejestr " + j + " " + name[i] + " miesci " + data[i]);
            }
        }


        static void Main(string[] args)
        {
            string[] name = {"AL", "AH", "BL", "BH", "CL", "CH", "DL", "DH"};
            string[] data = new string[8];

            for (int i = 0; i < data.Length; i++)
            {
                Console.WriteLine("Podaj zawartosc rejestru " + name[i] +": ");
                data[i] = Console.ReadLine();
            }
            action:
            Console.WriteLine("co chcesz zrobic?");
            Console.WriteLine("skopiowac to 1");
            Console.WriteLine("wymienić to 2");
            int opt = int.Parse(Console.ReadLine());

            Console.Clear();
            Console.WriteLine("z jakimi rejestrami chcesz pracowac?");
            printRej(data, name);

            int st = int.Parse(Console.ReadLine());
            --st;
            int nd = int.Parse(Console.ReadLine());
            --nd;

            switch (opt)
            {
                case 1:
                    data[st] = data[nd];
                    Console.Clear();
                    printRej(data, name);
                    break;
                case 2:
                    string temp = data[st];
                    data[st] = data[nd];
                    data[nd] = temp;
                    Console.Clear();
                    printRej(data, name);
                    break;
                default:
                    Console.WriteLine("nie ma takiej mozliwosci");
                    return ;
            }
            Console.WriteLine("chcesz przeprowadzic jescze jakas operacje?");
            Console.WriteLine("T/N");
            string odp = Console.ReadLine();
            string odpd = odp.ToUpper(new CultureInfo("en-US", false));
            if (odpd=="T")
            {
                goto action;
            }
            else
            {
                Console.Clear();
                Console.WriteLine("to koniec");
            }

        }
    }
}