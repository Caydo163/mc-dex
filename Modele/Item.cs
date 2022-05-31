using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Modele
{
    public class Item : IEquatable<Item>
    {
        public Item(string nom, string id, string image, string description)
        {
            Nom = nom;
            Id = id;
            Image = image;
            Desc = description;
        }

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

        public string Id
        {
            get
            {
                return identifiant;
            }
            set
            {
                //if(Regex.IsMatch(value, @"^[0-9:]+$") && value[0] != '0')
                //{
                    identifiant = value;
                //}
            }
        }
        private string identifiant;

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




        //public Dictionary<string, double> ListeStats { get; private set; }
        public Dictionary<string, string> ListeStats = new Dictionary<string, string>();


        public void AjouterStat(string nom, string valeur)
        {
            if(ListeStats == null)
            {
                ListeStats = new Dictionary<string, string>();
                Console.WriteLine("Création dictionnaire");
            }
            if(! ListeStats.ContainsKey(nom))
            {
                ListeStats[nom] = valeur;
            }
            else
            {
                Console.WriteLine("La statistique existe déjà");
            }
        }




        public List<KeyValuePair<string, string>> ListeTexte = new List<KeyValuePair<string, string>>();
        

        public void AjouterTexte(string titre, string partie)
        {
            if(ListeTexte == null)
            {
                ListeTexte = new List<KeyValuePair<string, string>>();
            }
            ListeTexte.Add(new KeyValuePair<string, string>(titre, partie));
        }



        public List<Craft> ListeCraft = new();


        public void AjouterCraft(Item o1, Item o2, Item o3, Item o4, Item o5, Item o6, Item o7, Item o8, Item o9, int nbFinal, Item o10 = null)
        {
            if (o10 is null)
            {
                ListeCraft.Add(new CraftObjet(nbFinal, o1, o2, o3, o4, o5, o6, o7, o8, o9));
            }
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
