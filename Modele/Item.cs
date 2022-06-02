using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;

namespace Modele
{
    [DataContract]
    /// <summary>
    /// Classe contenant toutes les informations d'un item
    /// </summary>
    public class Item : IEquatable<Item>
    {
        /// <summary>
        /// Constructeur de Item
        /// </summary>
        /// <param name="nom">Nom de l'item</param>
        /// <param name="id">Identifiant de l'item</param>
        /// <param name="image">Image de l'item</param>
        /// <param name="description">Description de l'item</param>
        public Item(string nom, string id, string image, string description)
        {
            Nom = nom;
            Id = id;
            Image = image;
            Desc = description;
        }

        /// <summary>
        /// Propriété contenant le nom de l'item
        /// </summary>
        [DataMember]
        public string Nom
        {
            get
            {
                return nom;
            }
            set
            {
                nom = value[0].ToString().ToUpper() + value[1..].ToLower();
            }
        }
        private string nom;

        /// <summary>
        /// Propriété contenant l'identifiant de l'item
        /// </summary>
        [DataMember(Order = 0)]
        public string Id
        {
            get
            {
                return identifiant;
            }
            set
            {
                if (Regex.IsMatch(value, @"^[0-9:]+$") && value[0] != '0')
                {
                    identifiant = value;
                }
            }
        }
        private string identifiant;

        /// <summary>
        /// Propriété contenant l'image de l'item
        /// </summary>
        [DataMember]
        public string Image
        {
            get
            {
                return image;
            }
            set
            {
                image = value;
            }
        }
        private string image;

        /// <summary>
        /// Propriété contenant la description de l'item
        /// </summary>
        [DataMember]
        public string Desc
        {
            get
            {
                return description;
            }
            set
            {
                description = value;
            }
        }
        private string description;

        /// <summary>
        /// Propriété contenant le nom anglais de l'item
        /// </summary>
        [DataMember (EmitDefaultValue = false)]
        public string NomE
        {
            get
            {
                return nomAnglais;
            }
            set
            {
                nomAnglais = value[0].ToString().ToUpper() + value[1..].ToLower();
            }
        }
        private string nomAnglais;



        /// <summary>
        /// Dictionnaire contenant les statistiques de litem
        /// </summary>
        [DataMember]
        public Dictionary<string, string> ListeStats = new();

        /// <summary>
        /// Méthode qui permet d'ajouter des statistiques à l'item
        /// </summary>
        /// <param name="nom">Nom de la statistique</param>
        /// <param name="valeur">Valeur de la statistique</param>
        public void AjouterStat(string nom, string valeur)
        {
            //if(ListeStats == null)
            //{
            //    ListeStats = new Dictionary<string, string>();
            //    Console.WriteLine("Création dictionnaire");
            //}
            if(! ListeStats.ContainsKey(nom))
            {
                ListeStats[nom] = valeur;
            }
            else
            {
                Console.WriteLine("La statistique existe déjà");
            }
        }



        /// <summary>
        /// Liste de paire contenant des textes
        /// </summary>
        [DataMember]
        public List<KeyValuePair<string, string>> ListeTexte = new();
        

        /// <summary>
        /// Méthode qui ajoute des textes à l'item
        /// </summary>
        /// <param name="titre">Titre du texte</param>
        /// <param name="partie">Texte</param>
        public void AjouterTexte(string titre, string partie)
        {
            //if(ListeTexte == null)
            //{
            //    ListeTexte = new List<KeyValuePair<string, string>>();
            //}
            ListeTexte.Add(new KeyValuePair<string, string>(titre, partie));
        }
        


        /// <summary>
        /// Liste contenant les carfts de l'item
        /// </summary>
        [DataMember]
        public List<Craft> ListeCraft = new();

        /// <summary>
        /// Méthode qui ajoute un craft à l'item
        /// </summary>
        /// <param name="o1">Item 1</param>
        /// <param name="o2">Item 2</param>
        /// <param name="o3">Item 3</param>
        /// <param name="o4">Item 4</param>
        /// <param name="o5">Item 5</param>
        /// <param name="o6">Item 6</param>
        /// <param name="o7">Item 7</param>
        /// <param name="o8">Item 8</param>
        /// <param name="o9">Item 9</param>
        /// <param name="nbFinal">Nombre d'item obtenu</param>
        /// <param name="o10">Item 10</param>
        public void AjouterCraft(Item o1, Item o2, Item o3, Item o4, Item o5, Item o6, Item o7, Item o8, Item o9, int nbFinal, Item o10 = null)
        {
            // Si il n'y a pas le 10e item, il s'agit d'un craftObjet
            if (o10 is null)
            {
                ListeCraft.Add(new CraftObjet(nbFinal, o1, o2, o3, o4, o5, o6, o7, o8, o9));
            }
            // Sinon c'est un craftUtilisation
            else
            {
                ListeCraft.Add(new CraftUtilisation(nbFinal, o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, this.Nom));
            }

        }




        //public override bool Equals(object obj)
        //{
        //    Item item = (Item)obj;
        //    return this.Id == item.Id;
        //}


        public override string ToString()
        {
            return $"{Nom} / {Image} / {Id} / {Desc} / {NomE}"; 
        }

        public override int GetHashCode()
            => (int)(Id.GetHashCode());

        public bool Equals(Item other)
        {
            return this.Id == other.Id;
        }
    }
}
