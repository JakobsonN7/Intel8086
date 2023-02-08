using System;
using System.Globalization;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Intel8086
{
    internal class Program
    {

        static void printRej(int[] data, string[] name)
        {
            for (int i = 0; i < data.Length; i++)
            {
                int j = i + 1;
                Console.WriteLine("Rejestr " + j + " " + name[i] + " miesci " + data[i].ToString("X"));
            }
        }

        static void selRej()
        {
            int st = int.Parse(Console.ReadLine());
            --st;
            int nd = int.Parse(Console.ReadLine());
            --nd;
        }


        static void Main(string[] args)
        {
            string[] name = {"AL", "AH", "BL", "BH", "CL", "CH", "DL", "DH"};
            int[] data = new int[8];
            string[] var = {"MOV", "XNG", "NOT", "INC", "DEC", "OR", "AND", "XOR", "ADD", "SUB"}

            for (int i = 0; i < data.Length; i++)
            {               
                Console.WriteLine("Podaj zawartosc rejestru (nie wiekszą niż 255)" + name[i] +": ");
                data[i] = int.Parse(Console.ReadLine());
                if(data[i] > 256)
                {
                    Console.WriteLine("Podaj zawartosc rejestru " + name[i] +" jescze raz");
                    data[i] = int.Parse(Console.ReadLine());
                }
            }
            Console.Clear();
            action:

            Console.WriteLine("Wybierz mozliwa opcje");
            for (int i =0; i < var.Length; i++) 
            {
                int j = i + 1;
                Console.WriteLine(j + ". " + var[i]);
            }
            Console.WriteLine("11. Wyjscie z programu");
            int opt = int.Parse(Console.ReadLine());

            Console.Clear();
            Console.WriteLine("z jakimi rejestrami chcesz pracowac?");

            switch (opt)
            {
                case 1:
                    Console.WriteLine("Wybrales opcje MOV");
                    selRej;
                    data[st] = data[nd];
                    Console.Clear();
                    printRej(data, name);
                    break;
                case 2:
                    Console.WriteLine("Wybrales opcje XNG");
                    selRej;
                    int temp = data[st];
                    data[st] = data[nd];
                    data[nd] = temp;
                    Console.Clear();
                    printRej(data, name);
                    break;
                case 3:
                    Console.WriteLine("Wybrales opcje NOT");
                    break;
                case 4:
                    Console.WriteLine("Wybrales opcje INC");
                    break;
                case 5:
                    Console.WriteLine("Wybrales opcje DEC");
                    break; 
                case 6:
                    Console.WriteLine("Wybrales opcje OR");
                    break; 
                case 7:
                    Console.WriteLine("Wybrales opcje AND");
                    break; 
                case 8:
                    Console.WriteLine("Wybrales opcje XOR");
                    break;
                case 9:
                    Console.WriteLine("Wybrales opcje ADD");
                    break;
                case 10:
                    Console.WriteLine("Wybrales opcje SUB");
                    break; 
                case 11:
                    Console.WriteLine("Wybrales opcje Wyjscie z programu");
                    Console.WriteLine("Czy napewno?");
                    Console.WriteLine("T/N");
                    string wyjscie = Console.ReadLine()
                    string wyjscied = wyjscie.ToUpper(new CultureInfo("en-US", false));
                    if (odpd == "T")
                    {
                        goto action;
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("to koniec");
                    }
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