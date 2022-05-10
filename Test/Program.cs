using System;
using System.Collections.Generic;
using Modele;

namespace Test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Item item = new Item("terre", "12", "image", "Voici une description");
            item.Id = "9:1";
            Console.WriteLine(item.Id);
            /* item.NomE = "Terre en anglais";*/
    /*        item.listeTexte.Add(new KeyValuePair<string, string>("Test", "test" ));
            item.listeTexte.Add(new KeyValuePair<string, string>("Test", "test" ));
            Console.WriteLine(item.listeTexte[0]);*/
            Console.WriteLine(item);

        }
    }
}
