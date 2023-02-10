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
                Console.WriteLine("Rejestr " + j + " " + name[i] + " miesci " + data[i].ToString("X")/*.PadLeft(8,'0')*/);
            }
        }

        static int[] selRej(int[] which)
        {
            Console.WriteLine("pierwszy rejestr");
            int fit = int.Parse(Console.ReadLine());
            Console.WriteLine("drugi rejestr");
            int seco = int.Parse(Console.ReadLine());
            which[0] = fit;
            which[1] = seco;
            --which[0];
            --which[1];
            return which;
        }

        //static string toBinSt(string binarySt, int[] which, int[] data)
        //{
        //    string std = data[which[0]].ToString();
        //    binarySt = Convert.ToString(Convert.ToInt32(std, 10), 2).PadLeft(8, '0');
        //    return binarySt;
        //}

        //static string toBinNd(string binaryNd, int[] which, int[] data)
        //{
        //    string ndd = data[which[0]].ToString();
        //    binaryNd = Convert.ToString(Convert.ToInt32(ndd, 10), 2).PadLeft(8, '0');
        //    return binaryNd;
        //}

        //static char[] toBinArraySt(char[] binaryStCharArray, string binarySt)
        //{
        //    binaryStCharArray = binarySt.ToCharArray();
        //    return binaryStCharArray;
        //}

        //static char[] toBinArrayNd(char[] binaryNdCharArray, string binaryNd)
        //{
        //    binaryNdCharArray = binaryNd.ToCharArray();
        //    return binaryNdCharArray;
        //}

        static void Main(string[] args)
        {
            string[] name = {"AL", "AH", "BL", "BH", "CL", "CH", "DL", "DH"};
            int[] data = new int[8];
            string[] var = { "MOV", "XNG", "NOT", "INC", "DEC", "OR", "AND", "XOR", "ADD", "SUB" };
            int[] which = new int[2];
            string binarySt = "";
            string binaryNd = "";
            char[] binaryStCharArray = { '0', '0', '0', '0', '0', '0', '0', '0' };
            char[] binaryNdCharArray = { '0', '0', '0', '0', '0', '0', '0', '0' };
            string std, ndd;
            string binarySum;
            char[] binarySumArray = { '0', '0', '0', '0', '0', '0', '0', '0' };
            int sum;

            Console.WriteLine("Uzupelnienie rejestrow");
            Console.WriteLine("1. Reczne");
            Console.WriteLine("2. Automatyczne");
            int uzu = int.Parse(Console.ReadLine());

            if (uzu == 1)
            {
                for (int i = 0; i < data.Length; i++)
                {
                    Console.WriteLine("Podaj zawartosc rejestru (nie wiekszą niż 255)" + name[i] + ": ");
                    data[i] = int.Parse(Console.ReadLine());
                    if (data[i] > 255)
                    {
                        Console.WriteLine("Podaj zawartosc rejestru " + name[i] + " jescze raz");
                        data[i] = int.Parse(Console.ReadLine());
                    }
                }
            }
            else
            {
                Random random = new Random();
                for (int i = 0; i < data.Length; i++)
                {
                    data[i] = random.Next(1, 255);
                }
            }
           
            Console.Clear();
            action:
            printRej(data, name);
            Console.WriteLine("\nWybierz mozliwa opcje");
            for (int i =0; i < var.Length; i++) 
            {
                int j = i + 1;
                Console.WriteLine(j + ". " + var[i]);
            }
            Console.WriteLine("11. Wyjscie z programu");
            int opt = int.Parse(Console.ReadLine());

            Console.Clear();

            int rd = 0;
            switch (opt)
            {
                case 1:
                    Console.WriteLine("Wybrales opcje MOV");
                    Console.WriteLine("z jakimi rejestrami chcesz pracowac?");
                    printRej(data, name);
                    selRej(which);

                    data[which[0]] = data[which[1]];

                    Console.Clear();
                    printRej(data, name);
                    break;
                case 2:
                    Console.WriteLine("Wybrales opcje XNG");
                    Console.WriteLine("z jakimi rejestrami chcesz pracowac?");
                    printRej(data, name);
                    selRej(which);

                    int temp = data[which[0]];
                    data[which[0]] = data[which[1]];
                    data[which[1]] = temp;

                    Console.Clear();
                    printRej(data, name);
                    break;
                case 3:
                    Console.WriteLine("Wybrales opcje NOT");
                    Console.WriteLine("z jakim rejestrem chcesz pracowac?");
                    printRej(data, name);

                    Console.WriteLine("Podaj rejestr");
                    rd = int.Parse(Console.ReadLine());
                    --rd;
                    string ds = data[rd].ToString();
                    string binary = Convert.ToString(Convert.ToInt32(ds, 10), 2).PadLeft(8,'0');
                    Console.WriteLine(binary);
                    char[] binaryCharArray= binary.ToCharArray();
                    for (int i = 0; i < binaryCharArray.Length; i++)
                    {
                        if (binaryCharArray[i] == '0') { binaryCharArray[i] = '1'; }
                        else if (binaryCharArray[i] == '1') { binaryCharArray[i] = '0'; }
                    }
                    string revBinaryString = new string(binaryCharArray);
                    string strHex = Convert.ToInt32(revBinaryString, 2).ToString("X");
                    data[rd] = Convert.ToInt32(revBinaryString, 2);

                    Console.Clear();
                    printRej(data, name);
                    break;
                case 4:
                    Console.WriteLine("Wybrales opcje INC");
                    Console.WriteLine("z jakim rejestrem chcesz pracowac?");
                    printRej(data, name);

                    Console.WriteLine("Podaj rejestr");
                    rd = int.Parse(Console.ReadLine());
                    --rd;
                    data[rd]++;

                    Console.Clear();
                    printRej(data, name);
                    break;
                case 5:
                    Console.WriteLine("Wybrales opcje DEC");
                    Console.WriteLine("z jakimi rejestrami chcesz pracowac?");
                    printRej(data, name);

                    rd = int.Parse(Console.ReadLine());
                    --rd;
                    data[rd]--;

                    Console.Clear();
                    printRej(data, name);
                    break; 
                case 6:
                    Console.WriteLine("Wybrales opcje OR");
                    Console.WriteLine("z jakimi rejestrami chcesz pracowac?");
                    printRej(data, name);
                    selRej(which);

                    std = data[which[0]].ToString();
                    ndd = data[which[1]].ToString();
                    binarySt = Convert.ToString(Convert.ToInt32(std, 10), 2).PadLeft(8, '0');
                    binaryStCharArray = binarySt.ToCharArray();
                    binaryNd = Convert.ToString(Convert.ToInt32(ndd, 10), 2).PadLeft(8, '0');
                    binaryNdCharArray = binaryNd.ToCharArray();
                    for (int i = 0;i < 8; i++)
                    {
                        if ((binaryStCharArray[i] == binaryNdCharArray[i]) && (binaryStCharArray[i] == '0')) { binarySumArray[i] = '0'; };
                        if ((binaryStCharArray[i] == binaryNdCharArray[i]) && (binaryStCharArray[i] == '1')) { binarySumArray[i] = '1'; };
                        if (binaryStCharArray[i] != binaryNdCharArray[i]) { binarySumArray[i] = '1'; };
                        Console.WriteLine(binarySumArray[i]);
                    }
                    binarySum = new string(binarySumArray);
                    data[which[0]] = Convert.ToInt32(binarySum, 2);

                    Console.Clear();
                    printRej(data, name);

                    break; 
                case 7:
                    Console.WriteLine("Wybrales opcje AND");
                    Console.WriteLine("z jakimi rejestrami chcesz pracowac?");
                    printRej(data, name);
                    selRej(which);

                    std = data[which[0]].ToString();
                    binarySt = Convert.ToString(Convert.ToInt32(std, 10), 2).PadLeft(8, '0');
                    ndd = data[which[1]].ToString();
                    binaryNd = Convert.ToString(Convert.ToInt32(ndd, 10), 2).PadLeft(8, '0');
                    binaryStCharArray = binarySt.ToCharArray();
                    binaryNdCharArray = binaryNd.ToCharArray();
                    for (int i = 0; i < 8; i++)
                    {
                        if ((binaryStCharArray[i] == binaryNdCharArray[i]) && (binaryStCharArray[i] == '0')) { binarySumArray[i] = '0'; };
                        if ((binaryStCharArray[i] == binaryNdCharArray[i]) && (binaryStCharArray[i] == '1')) { binarySumArray[i] = '1'; };
                        if (binaryStCharArray[i] != binaryNdCharArray[i]) { binarySumArray[i] = '0'; };
                        Console.Write(binarySumArray[i]);
                    }
                    binarySum = new string(binarySumArray);
                    data[which[0]] = Convert.ToInt32(binarySum, 2);

                    Console.Clear();
                    printRej(data, name);
                    break; 
                case 8:
                    Console.WriteLine("Wybrales opcje XOR");
                    Console.WriteLine("z jakimi rejestrami chcesz pracowac?");
                    printRej(data, name);
                    selRej(which);

                    std = data[which[0]].ToString();
                    ndd = data[which[1]].ToString();
                    binarySt = Convert.ToString(Convert.ToInt32(std, 10), 2).PadLeft(8, '0');
                    binaryStCharArray = binarySt.ToCharArray();
                    binaryNd = Convert.ToString(Convert.ToInt32(ndd, 10), 2).PadLeft(8, '0');
                    binaryNdCharArray = binaryNd.ToCharArray();
                    for (int i = 0; i < 8; i++)
                    {
                        if (binaryStCharArray[i] == binaryNdCharArray[i]) { binarySumArray[i] = '0'; };                        
                        if (binaryStCharArray[i] != binaryNdCharArray[i]) { binarySumArray[i] = '1'; };
                        Console.WriteLine(binarySumArray[i]);
                    }
                    binarySum = new string(binarySumArray);
                    data[which[0]] = Convert.ToInt32(binarySum, 2);

                    Console.Clear();
                    printRej(data, name);
                    break;
                case 9:
                    Console.WriteLine("Wybrales opcje ADD");
                    Console.WriteLine("z jakimi rejestrami chcesz pracowac?");
                    printRej(data, name);
                    selRej(which);

                    sum = data[which[0]] + data[which[1]];
                    if (sum > 255) { sum = sum % 255; }
                    data[which[0]] = sum;

                    Console.Clear();
                    printRej(data, name);
                    break;
                case 10:
                    Console.WriteLine("Wybrales opcje SUB");
                    Console.WriteLine("z jakimi rejestrami chcesz pracowac?");
                    printRej(data, name);
                    selRej(which);

                    sum = data[which[0]] - data[which[1]];
                    if (sum < 0) { sum = 255 - Math.Abs(sum); }
                    data[which[0]] = sum;

                    Console.Clear();
                    printRej(data, name);
                    break; 
                case 11:
                    Console.WriteLine("Wybrales opcje Wyjscie z programu");
                    Console.WriteLine("Czy napewno?");
                    Console.WriteLine("T/ ");
                    string wyjscie = Console.ReadLine();
                    string wyjscied = wyjscie.ToUpper(new CultureInfo("en-US", false));
                    if (wyjscied == "T")
                    {
                        Environment.Exit(0);
                    }
                    else
                    {
                        Console.Clear();
                        goto action;
                    }
                    break;
                default:
                    Console.WriteLine("nie ma takiej mozliwosci");
                    return ;
            }
            Console.WriteLine("chcesz przeprowadzic jescze jakas operacje?");
            Console.WriteLine("T/ ");
            string odp = Console.ReadLine();
            string odpd = odp.ToUpper(new CultureInfo("en-US", false));
            if (odpd == "T")
            {
                Console.Clear();
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