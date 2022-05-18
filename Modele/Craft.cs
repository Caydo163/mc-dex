using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modele
{
    public abstract class Craft
    {

        public Item Objet0_0
        {
            get { return objet0_0; }
            set { objet0_0 = value; }
        }
        private Item objet0_0;


        public Item Objet0_1
        {
            get { return objet0_1; }
            set { objet0_1 = value; }
        }
        private Item objet0_1;

        public Item Objet0_2
        {
            get { return objet0_2; }
            set { objet0_2 = value; }
        }
        private Item objet0_2;

        public Item Objet1_0
        {
            get { return objet1_0; }
            set { objet1_0 = value; }
        }
        private Item objet1_0;

        public Item Objet1_1
        {
            get { return objet1_1; }
            set { objet1_1 = value; }
        }
        private Item objet1_1;


        public Item Objet1_2
        {
            get { return objet1_2; }
            set { objet1_2 = value; }
        }
        private Item objet1_2;


        public Item Objet2_0
        {
            get { return objet2_0; }
            set { objet2_0 = value; }
        }
        private Item objet2_0;


        public Item Objet2_1
        {
            get { return objet2_1; }
            set { objet2_1 = value; }
        }
        private Item objet2_1;


        public Item Objet2_2
        {
            get { return objet2_2; }
            set { objet2_2 = value; }
        }
        private Item objet2_2;


        public int NbFinal
        {
            get { return nbFinal; }
            set { nbFinal = value; }
        }
        private int nbFinal;


        public Craft(int nbF,Item o1, Item o2, Item o3, Item o4, Item o5, Item o6, Item o7, Item o8, Item o9)
        {
            Objet0_0 = o1;
            Objet0_1 = o2;
            Objet0_2 = o3;
            Objet1_0 = o4;
            Objet1_1 = o5;
            Objet1_2 = o6;
            Objet2_0 = o7;
            Objet2_1 = o8;
            Objet2_2 = o9;
            NbFinal = nbF;
        }

        public abstract List<KeyValuePair<string, int>> CalculIngredient();
    }
}


