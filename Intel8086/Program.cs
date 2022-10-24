namespace Intel8086
{
    internal class Program
    {

        static void MOV(int[] data)
        {
            data[1] = data[2];



        }

        static void XCHG()
        {




        }


        static void Main(string[] args)
        {
            string[] name = {"AL", "AH", "BL", "BH", "CL", "CH", "DL", "DH"};
            string[] data = new string[8];
            int a, b;

            for (int i = 0; i < data.Length; i++)
            {
                Console.WriteLine("Podaj zawartosc rejestru " + name[i] +": ");
                data[i] = Console.ReadLine();
            }            

            Console.WriteLine("co chcesz zrobic?");
            Console.WriteLine("skopiowac to 1");
            Console.WriteLine("wymienić to 2");
            int opt = int.Parse(Console.ReadLine());

            Console.WriteLine("z jakimi rejestrami chcesz pracowac?");
            for (int i = 0; i < data.Length; i++)
            {
                Console.WriteLine("Rejestr " + " " + i + " " + name[i] + " miesci " + data[i]);
            }


            switch (opt)
            {
                case 1:
                    MOV(data[a], data[b]);
                    break;
                case 2:

                    break;
                default:
                    Console.WriteLine("nie ma takiej mozliwosci");
                    break;
            }










        }
    }
}