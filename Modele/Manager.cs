using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Collections.ObjectModel;

namespace Modele
{
    public class Manager
    {
        public ReadOnlyCollection<Item> Items { get; private set; }
        private List<Item> items = new();
        public Item SelectedItem { get; set; }

        public IPersistanceManager Pers { get; private set; }

        public Manager(IPersistanceManager pers)
        {
            Items = new ReadOnlyCollection<Item>(items);
            Pers = pers;

        }

        public void LoadItems()
        {
            items.Clear();
            items.Add(new Item("Bloc actuel", "999", "img\\bloc_actuel.png",""));
            items.AddRange(Pers.LoadItems());
            //SelectedItem = items[1];
        }


        public bool AjouterItem(string nom, string nomE, string id, string image, string desc, List<KeyValuePair<string, string>> listeTexte, Dictionary<string, string> listeStats)
        {
            foreach (Item elt in Items)
            {
                if(elt.Id == id)
                {
                    return false;
                }
            }
            //Item item = new("Terre", "10:89", "img/terre.png", "Description");
            Item item = new(nom, id, image, desc);
            foreach(KeyValuePair<string, string> elt in listeTexte)
            {
                item.ListeTexte.Add(elt);
            }

            foreach(KeyValuePair<string, string> elt in listeStats)
            {
                item.ListeStats[elt.Key] = elt.Value;
            }
                //if (!items.Contains(item))
                //{
                //    items.Add(item);
                //}
                items.Add(item);
            //SelectedItem = items.Last();
            return true;
        }

        public void SupprimerItem(Item item)
        {
            if(Items.Contains(item))
            {
                items.RemoveAt(items.IndexOf(item));
                SelectedItem = items.Last();
            }
        }


        private string ModificationStringRecherche(string mot)
        {
            string newMot = "";
            foreach (char lettre in Regex.Replace(mot, @"\s", "").ToLower())
            {
                newMot += lettre switch
                {
                    'à' or 'á' or 'â' or 'ä' => 'a',
                    'é' or 'è' or 'ê' or 'ë' => 'e',
                    'ô' or 'ö' or 'ò' or 'ó' => 'o',
                    'ï' or 'î' or 'ì' or 'í' => 'i',
                    'ù' or 'ú' or 'û' or 'ü' => 'u',
                    'ÿ' => 'y',
                    'ç' => 'c',
                    'ñ' => 'n',
                     _  => lettre,
                };
            }
            return newMot;
        }





        public IEnumerable<Item> Rechercher(string mot)
        {
            List<Item> itemTrouve = new();
            mot = ModificationStringRecherche(mot);
            
            Console.WriteLine(mot);

            foreach (Item item in Items)
            {
                string nomItem = ModificationStringRecherche(item.Nom);

                if (nomItem.Contains(mot))
                {
                    Console.WriteLine("Yes ! On l'a trouvé.");
                    itemTrouve.Add(item);
                }
            }
            return itemTrouve;
        }
    }
}
