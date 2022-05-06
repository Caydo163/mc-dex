using System;
using Modele;

namespace Test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Item item = new Item("Terre", "12", "image", "Voici une description");
           /* item.NomE = "Terre en anglais";*/
            item.listeTexte =
            Console.WriteLine(item);

        }
    }
}
