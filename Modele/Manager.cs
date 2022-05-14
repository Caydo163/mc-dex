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

        public void AjouterItem(ref Item item)
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
