using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Collections.ObjectModel;
using System.IO;

namespace Modele
{
    /// <summary>
    /// Classe permettant de gérer le fonctionnement back-end de l'application
    /// </summary>
    public class Manager
    {
        /// <summary>
        /// Booléen permettant de savoir si l'utilisateur est en mode recherche
        /// </summary>
        public bool modeRecherche = false;

        /// <summary>
        /// Liste privé des items 
        /// </summary>
        private List<Item> items = new();

        /// <summary>
        /// Liste publique des items  
        /// </summary>
        public ReadOnlyCollection<Item> Items { get; private set; }

        /// <summary>
        /// Liste publique des items respectant les conditions de recherche de l'utilisateur
        /// </summary>
        public ReadOnlyCollection<Item> ItemsRecherche { get; private set; }

        /// <summary>
        /// Item sélectionné par l'utilisateur
        /// </summary>
        public Item SelectedItem { get; set; }

        public IPersistanceManager Pers { get; set; }

        /// <summary>
        /// Constructeur du la classe
        /// </summary>
        /// <param name="pers">XXXXXXXXXXX</param>
        public Manager(IPersistanceManager pers)
        {
            Items = new ReadOnlyCollection<Item>(items);
            Pers = pers;

        }

        /// <summary>
        /// Méthode permettant de charger la liste d'item
        /// </summary>
        public void LoadItems()
        {
            items.Clear();
            items.AddRange(Pers.LoadItems());
        }

        /// <summary>
        /// Méthode permettant de sauvegarder la liste d'item
        /// </summary>
        public void SaveItems()
        {
            Pers.SaveItems(items);
        }

        /// <summary>
        /// Méthode permettant d'ajouter un item à la liste
        /// </summary>
        /// <param name="nom">Nom de l'item</param>
        /// <param name="nomE">Nom anglais de l'item</param>
        /// <param name="id">Identifiant de l'item</param>
        /// <param name="image">Image de l'item</param>
        /// <param name="desc">Description de l'item</param>
        /// <param name="listeTexte">Liste des textes de l'item</param>
        /// <param name="listeStats">Liste des statistiques de l'item</param>
        /// <returns>L'item créé et ajouté à la liste</returns>
        public Item AjouterItem(string nom, string nomE, string id, string image, string desc, List<KeyValuePair<string, string>> listeTexte, Dictionary<string, string> listeStats)
        {
            // On vérifie si l'identifiant n'existe pas
            foreach (Item elt in Items)
            {
                if(elt.Id == id)
                {
                    return null;
                }
            }


            Item item = new(nom, id, image, desc)
            {
                NomE = nomE
            };

            foreach (KeyValuePair<string, string> elt in listeTexte)
            {
                item.ListeTexte.Add(elt);
            }

            foreach(KeyValuePair<string, string> elt in listeStats)
            {
                item.ListeStats[elt.Key] = elt.Value;
            }

            items.Add(item);
            return item;
        }

        public HashSet<string> images_a_supprimer = new();

        /// <summary>
        /// Méthode permettant de supprimer un item de la liste
        /// </summary>
        /// <param name="item">L'item à supprimer</param>
        public void SupprimerItem(Item item)
        {
            if(Items.Contains(item))
            {
                // On ajoute l'image dans "images_a_supprimer" pour que l'image soit supprimé à la fermeture de l'application
                if(File.Exists(Path.Combine(Path.Combine(Directory.GetCurrentDirectory(), "..\\img"), item.Image)))
                {
                    images_a_supprimer.Add(Path.Combine(Path.Combine(Directory.GetCurrentDirectory(), "..\\img"), item.Image));
                }

                // On supprime tous les crafts qui font référence à cet item
                foreach(Item elt in items)
                {
                    foreach(Craft craft in elt.ListeCraft)
                    {
                        if(craft.Objet0_0 != null && craft.Objet0_0.Id == item.Id)
                        {
                            elt.ListeCraft.Remove(craft);
                            break;
                        }
                        if (craft.Objet0_1 != null && craft.Objet0_1.Id == item.Id)
                        {
                            elt.ListeCraft.Remove(craft);
                            break;
                        }
                        if (craft.Objet0_2 != null && craft.Objet0_2.Id == item.Id)
                        {
                            elt.ListeCraft.Remove(craft);
                            break;
                        }
                        if (craft.Objet1_0 != null && craft.Objet1_0.Id == item.Id)
                        {
                            elt.ListeCraft.Remove(craft);
                            break;
                        }
                        if (craft.Objet1_1 != null && craft.Objet1_1.Id == item.Id)
                        {
                            elt.ListeCraft.Remove(craft);
                            break;
                        }
                        if (craft.Objet1_2 != null && craft.Objet1_2.Id == item.Id)
                        {
                            elt.ListeCraft.Remove(craft);
                            break;
                        }
                        if (craft.Objet2_0 != null && craft.Objet2_0.Id == item.Id)
                        {
                            elt.ListeCraft.Remove(craft);
                            break;
                        }
                        if (craft.Objet2_1 != null && craft.Objet2_1.Id == item.Id)
                        {
                            elt.ListeCraft.Remove(craft);
                            break;
                        }
                        if (craft.Objet2_2 != null && craft.Objet2_2.Id == item.Id)
                        {
                            elt.ListeCraft.Remove(craft);
                            break;
                        }
                        if (craft.GetType() == typeof(CraftUtilisation))
                        {
                            CraftUtilisation craftU = (CraftUtilisation)craft;
                            if(craftU.ObjetFinal.Id == item.Id)
                            {
                                elt.ListeCraft.Remove(craft);
                                break;
                            }
                        }
                    }
                }

                // On supprime l'item de la liste
                items.RemoveAt(items.IndexOf(item));
            }
        }

        /// <summary>
        /// Méthode permettant de modifier une chaîne de caractère pour la recherche
        /// </summary>
        /// <param name="mot">String à modifier</param>
        /// <returns></returns>
        private string ModificationStringRecherche(string mot)
        {
            string newMot = "";
            if (mot != null)
            {
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
                        _ => lettre,
                    };
                }
            }
            return newMot;
        }




        /// <summary>
        /// Méthode permettant de rechercher les items (noom, nom anglais et identifiant) correspondant aux critères
        /// </summary>
        /// <param name="mot">Critère de selection</param>
        /// <returns></returns>
        public IEnumerable<Item> Rechercher(string mot)
        {
            mot = ModificationStringRecherche(mot);
            IEnumerable<Item> itemTrouve = Items.Where(item => ModificationStringRecherche(item.Nom).Contains(mot) || ModificationStringRecherche(item.NomE).Contains(mot) || item.Id.Contains(mot));
            ItemsRecherche = new ReadOnlyCollection<Item>(itemTrouve.ToList());
            return itemTrouve;
        }


        /// <summary>
        /// Méthode permettant d'ajouter 2 items qui servent pour ajouter un craft 
        /// </summary>
        /// <param name="check"></param>
        public void ModeAjouter(bool check)
        {
            // Si on active le mode ajouter, on ajoute les 2 items
            if(check)
            {
                // L'item "Vide" permet d'enlever un bloc d'un craft
                items.Insert(0,new Item("Vide", "999:1", "..\\img\\Vide.png", ""));
                // L'item "Bloc Actuel" permet d'ajouter l'item que l'on est entrain de créer dans un craft
                items.Insert(1,new Item("Bloc Actuel", "999:2", "..\\img\\MissingTextureBlock.png", ""));
            }
            // Si on désactive le mode ajouter et que les items existe on les supprimes
            else
            {
                if(items.Count > 1)
                {
                    if (items[0].Id == "999:1" && items[1].Id == "999:2")
                    {
                        items.RemoveRange(0, 2);
                    }
                }
            }
        }


    }
}
