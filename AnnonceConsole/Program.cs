using AnnonceBDD;
using System;

namespace AnnonceConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World !");
            BDDSingleton BDD = BDDSingleton.Instance;
            Console.WriteLine("BDD are created YOUPI!!!");
            Console.ReadKey();
        }
    }
}
