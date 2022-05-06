using System;
using System.Collections.Generic;

namespace Modele
{
    public class Item
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
                nom = value;
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
                identifiant = value;
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
                nomAnglais = value;
            }
        }
        private string nomAnglais;


        private Dictionary<string, float> listeStats = new Dictionary<string, float>();
        public float this[string key]
        {
            get
            {
                return listeStats[key];
            }
            set
            {
                listeStats[key] = value;
            }
        }

        
        private List<KeyValuePair<string, string> > listeTexte = new List<KeyValuePair<string, string>>();
        public KeyValuePair<string, string> this[int index]
        {
            get { return listeTexte[index]; }
            set { listeTexte[index] = value; }
        }



        public override string ToString()
        {
            return $"{Nom} / {Image} / {Id} / {Desc} / {NomE}"; 
        }
    }
}
