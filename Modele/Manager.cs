using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Modele
{
    public class Manager
    {
        public List<Item> Items { get; set; }

        public Manager()
        {
            Items = new List<Item>();
        }

        public void AjouterItem(Item item)
        {
            if (! Items.Contains(item))
            {
                Items.Add(item);
            }
        }

        public void SupprimerItem(Item item)
        {
            if(Items.Contains(item))
            {
                Items.RemoveAt(Items.IndexOf(item));
            }
        }


        private string ModificationStringRecherche(string mot)
        {

            return Regex.Replace(mot, @"\s", "").ToLower();
        }



        public IEnumerable<Item> Rechercher(string mot)
        {
            List<Item> itemTrouve = new();
            mot = ModificationStringRecherche(mot);
            


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
