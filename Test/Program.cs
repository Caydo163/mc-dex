using System;
using System.Collections.Generic;
using Modele;

namespace Test
{
    internal class Program
    {
        static void Main()
        {





            Manager manager = new(new StubLib.Stub());
            //manager.LoadItems();
            //manager.Pers = new DataContractPersistance.DataContractPers();
            //manager.SaveItems();




            Item item = new("terre", "12", "image", "Voici une description");
            Item item2 = new("pierre", "38:2", "image", "Voici une description");
            item.Id = "9:1";
            item2.NomE = "Cobblestone";



            item.AjouterTexte("Titre 1", "Texte 1");
            item.AjouterTexte("Titre 2", "Texte 2");
            item.AjouterTexte("Titre 3", "Texte 3");

            Console.WriteLine("\n\nElement Attendu :");
            Console.WriteLine("Titre 1 : Texte 1");
            Console.WriteLine("Titre 2 : Texte 2");
            Console.WriteLine("Titre 3 : Texte 3");

            Console.WriteLine("Element trouvé :");
            foreach (KeyValuePair<string, string> e in item.ListeTexte)
            {
                Console.WriteLine(e.Key + " : " + e.Value);
            }


            item.AjouterStat("Stat 1", "5.6");
            item.AjouterStat("Stat 2", "1");
            item.AjouterStat("Stat 3", "infini");
            item.AjouterStat("Stat 1", "-8");

            Console.WriteLine("\n\nElement Attendu :");
            Console.WriteLine("Stat 1 : 5.6");
            Console.WriteLine("Stat 2 : 1");
            Console.WriteLine("Stat 3 : infini");

            Console.WriteLine("Element trouvé :");
            foreach (KeyValuePair<string, string> e in item.ListeStats)
            {
                Console.WriteLine(e.Key + " : " + e.Value);
            }

            item.AjouterCraft(item2, null, item2, null, null, null, null, null, item2, 5);
            item.AjouterCraft(item2, null, item, null, null, null, null, item, item2, 5, item2);

            Console.WriteLine("\n\nElement Attendu :");
            Console.WriteLine("Pierre / image / 38:2 / Voici une description / Cobblestone//Pierre / image / 38:2 / Voici une description / Cobblestone/Pierre / image / 38:2 / Voici une description / Cobblestone/////Pierre / image / 38:2 / Voici une description / Cobblestone/5");
            Console.WriteLine("Pierre / image / 38:2 / Voici une description / Cobblestone//Terre / image / 9:1 / Voici une description / /////Terre / image / 9:1 / Voici une description / /Pierre / image / 38:2 / Voici une description / Cobblestone/5");

            Console.WriteLine("Element trouvé :");
            foreach (Craft c in item.ListeCraft)
            {
                Console.WriteLine(c);
            }






            Console.WriteLine("\n============================================================\n");

            manager.AjouterItem(item.Nom, "", item.Id, item.Image, item.Desc, item.ListeTexte, item.ListeStats);
            manager.AjouterItem(item.Nom, "", item.Id, item.Image, item.Desc, item.ListeTexte, item.ListeStats);
            manager.AjouterItem(item2.Nom, item2.NomE, item2.Id, item2.Image, item2.Desc, item2.ListeTexte, item2.ListeStats);
            manager.SupprimerItem(item2);

            Console.WriteLine("Element Attendu :");
            Console.WriteLine("Terre / image / 9:1 / Voici une description /");
            Console.WriteLine("Element Trouvé :");
            foreach (Item i in manager.Items)
            {
                Console.WriteLine(i);
            }



            Console.WriteLine("\n\n Element Attendu :");
            Console.WriteLine("Terre");
            IEnumerable<Item> liste = manager.Rechercher("Tèr");
            Console.WriteLine("Element trouvé :");
            foreach (Item i in liste)
            {
                Console.WriteLine(i.Nom);
            }





            Console.WriteLine("\n============================================================\n");

            CraftObjet c1 = new(1, null, item, null, null, item, null, null, item2, null);
            Console.WriteLine("Element attendu :");
            Console.WriteLine("Terre : 2\nPierre : 1");
            List<KeyValuePair<string, int>> Ingred = c1.CalculIngredient();
            Console.WriteLine("Element trouvé :");
            foreach (KeyValuePair<string, int> e in Ingred)
            {
                Console.WriteLine(e.Key + " : " + e.Value);
            }




            CraftUtilisation c2 = new(64, item2, item2, null, item, item, item2, item2, item2, item2, item, "Pierre");
            Console.WriteLine("\n\nElement attendu :");
            Console.WriteLine("§Pierre : 6\nTerre : 2");
            List<KeyValuePair<string, int>> Ingred2 = c2.CalculIngredient();
            Console.WriteLine("Element trouvé :");
            foreach (KeyValuePair<string, int> e in Ingred2)
            {
                Console.WriteLine(e.Key + " : " + e.Value);
            }









        }
    }
}
