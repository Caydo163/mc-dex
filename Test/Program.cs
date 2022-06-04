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
            manager.LoadItems();
            manager.Pers = new DataContractPersistance.DataContractPers();
            manager.SaveItems();




            //Console.WriteLine("Hello World!");

            ////Manager manager = new();
            //Item item = new("terre", "12", "image", "Voici une description");
            //Item item2 = new("pierre", "38:2", "image", "Voici une description");
            //item.Id = "9:1";

            //item.AjouterTexte("Titre 1", "Texte 1");
            //item.AjouterTexte("Titre 2", "Texte 2");
            //item.AjouterTexte("Titre 3", "Texte 3");
            //foreach (KeyValuePair<string, string> e in item.ListeTexte)
            //{
            //    Console.WriteLine(e.Key + " : " + e.Value);
            //}


            //item.AjouterStat("Stat 1", "5.6");
            //item.AjouterStat("Stat 2", "1");
            //item.AjouterStat("Stat 3", "5.6");
            //item.AjouterStat("Stat 1", "-8");
            //foreach (KeyValuePair<string, string> e in item.ListeStats)
            //{
            //    Console.WriteLine(e.Key + " : " + e.Value);
            //}

            //item.AjouterCraft(item2, null, item2, item2, null, null, null, item2, item2, 5);
            //item.AjouterCraft(item2, null, item, item2, null, null, null, item, item2, 5, item2);


            //foreach (Craft c in item.ListeCraft)
            //{
            //    Console.WriteLine(c);
            //}






            ////Console.WriteLine(item.Id);
            ///* item.NomE = "Terre en anglais";*/
            ///*        item.listeTexte.Add(new KeyValuePair<string, string>("Test", "test" ));
            //        item.listeTexte.Add(new KeyValuePair<string, string>("Test", "test" ));
            //        Console.WriteLine(item.listeTexte[0]);*/
            //Console.WriteLine(item);
            //Console.WriteLine("============================================================");

            //manager.AjouterItem(ref item);
            //manager.AjouterItem(ref item);
            //manager.AjouterItem(ref item2);
            //manager.SupprimerItem(item2);
            //foreach (Item i in manager.Items)
            //{
            //    Console.WriteLine(i);
            //}



            //Console.WriteLine("Element trouvé");
            //IEnumerable<Item> liste = manager.Rechercher("àè sddcsçsdc àsdc öiï");
            //foreach (Item i in liste)
            //{
            //    Console.WriteLine("item",i);
            //}

            //Console.WriteLine("Element trouvé");
            //IEnumerable<Item> liste = manager.Rechercher("àè sddcsçsdc àsdc öiï");
            //foreach (Item i in liste)
            //{
            //    Console.WriteLine("item", i);
            //}

            //CraftObjet c1 = new(1,null, item, null, null, item,null,null,item2,null);
            //Console.WriteLine(c1.Objet0_1);
            //Console.WriteLine(c1.Objet2_1);
            //Console.WriteLine(c1.Objet2_2);
            //List < KeyValuePair<string, int> > Ingred = c1.CalculIngredient();
            //foreach (KeyValuePair<string, int> e in Ingred)
            //{
            //    Console.WriteLine(e.Key+" : "+e.Value);
            //}




            //CraftUtilisation c2 = new(64, item2, item2, null, item, item, item2, item2, item2, item2,item,"Pierre");
            //List<KeyValuePair<string, int>> Ingred2 = c2.CalculIngredient();
            //foreach (KeyValuePair<string, int> e in Ingred2)
            //{
            //    Console.WriteLine(e.Key + " : " + e.Value);
            //}









            /*           string mot = "Terre";
                       string target = "T e";

                       bool isExist = mot.Contains(target);
                       if (isExist)
                       {
                           Console.WriteLine("Oui");
                       }
                       else
                       {
                           Console.WriteLine("Non");
                       }
           */
        }
    }
}
