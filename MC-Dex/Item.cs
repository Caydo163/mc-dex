using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MC_Dex
{
    internal class Item
    {
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
        private string nomAnglais = default;


        private IDictionary<string, float> listeStats = new Dictionary<string, float>();
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
    }



}
