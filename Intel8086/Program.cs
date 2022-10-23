namespace Intel8086
{
    internal class Program
    {

        static void MOV()
        {
            data[a] = data[b]
        }

        static void XCHG()
        {




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


            for (int i = 0; i < data.Length; i++)
            {
                Console.WriteLine("Rejesrt " + name[i] + " miesci "+data[i]);
            }
        }
    }
}