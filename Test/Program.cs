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

            item.ajouterTexte("Titre 1", "Texte 1");
            item.ajouterTexte("Titre 2", "Texte 2");
            item.ajouterTexte("Titre 3", "Texte 3");
            foreach (KeyValuePair<string, string> e in item.ListeTexte)
            {
                Console.WriteLine(e.Key + " : " + e.Value);
            }


            item.ajouterStat("Stat 1", 5.6);
            item.ajouterStat("Stat 2", 1);
            item.ajouterStat("Stat 3", 5.6);
            item.ajouterStat("Stat 1", -8);
            foreach (KeyValuePair<string, double> e in item.ListeStats)
            {
                Console.WriteLine(e.Key + " : " + e.Value);
            }



            Console.WriteLine(item.Id);
            /* item.NomE = "Terre en anglais";*/
    /*        item.listeTexte.Add(new KeyValuePair<string, string>("Test", "test" ));
            item.listeTexte.Add(new KeyValuePair<string, string>("Test", "test" ));
            Console.WriteLine(item.listeTexte[0]);*/
            Console.WriteLine(item);

        }
    }
}
