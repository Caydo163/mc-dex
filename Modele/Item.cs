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
                if(Regex.IsMatch(value, @"^[0-9:]+$") && value[0] != '0')
                {
                    identifiant = value;
                }
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
        public Dictionary<string, double> ListeStats = new Dictionary<string, double>();


        public void AjouterStat(string nom, double valeur)
        {
            if(ListeStats == null)
            {
                ListeStats = new Dictionary<string, double>();
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
