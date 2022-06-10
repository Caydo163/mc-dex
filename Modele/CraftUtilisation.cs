using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Modele
{
    [DataContract]
    public class CraftUtilisation : Craft
    {
        [DataMember]
        public Item ObjetFinal
        {
            get { return objetFinal; }
            set { objetFinal = value; }
        }
        private Item objetFinal;

        [DataMember]
        public string NomBase
        {
            get { return nomBase; }
            set { nomBase = value; }
        }
        private string nomBase;


        /// <summary>
        /// Constructeur de la classe CraftUtilisation faisant appel à la classe mère et qui set les attributs ObjetFinal et NomBase
        /// </summary>
        /// <param name="nbF"></param>
        /// <param name="o1"></param>
        /// <param name="o2"></param>
        /// <param name="o3"></param>
        /// <param name="o4"></param>
        /// <param name="o5"></param>
        /// <param name="o6"></param>
        /// <param name="o7"></param>
        /// <param name="o8"></param>
        /// <param name="o9"></param>
        /// <param name="objetFinal"></param>
        /// <param name="nomBase"></param>        
        public CraftUtilisation(int nbF, Item o1, Item o2, Item o3, Item o4, Item o5, Item o6, Item o7, Item o8, Item o9, Item objetFinal, string nomBase)
            :base(nbF, o1, o2, o3, o4, o5, o6, o7, o8, o9)
        {
            ObjetFinal = objetFinal;
            NomBase = nomBase;
        }


        /// <summary>
        /// Calcul pour chaque items différents, son total d'apparition dans les attributs et met un indicateur devant l'item de meme nom que la classe Item qui l'a creer
        /// </summary>
        /// <returns>Liste du nombre d'apparition de chaque item dans la classe</returns>
        public override List<KeyValuePair<string, int>> CalculIngredient()
        {
            List<KeyValuePair<string, int>> L = new();
            List<Item> L2 = new() { Objet0_0, Objet0_1, Objet0_2, Objet1_0, Objet1_1, Objet1_2, Objet2_0, Objet2_1, Objet2_2};
            foreach (Item ite in L2)
            {

                if (ite != null)
                {
                    bool Condi = false;
                    int index = 0;
                    int index2 = 0;
                    KeyValuePair<string, int> tmp = new(ite.Nom, 0);
                    foreach (KeyValuePair<string, int> ite2 in L)
                    {
                        if (ite2.Key == ite.Nom)
                        {
                            tmp = new(ite2.Key, ite2.Value + 1);
                            Condi = true;
                            index2 = index;
                        }
                        index++;
                    }
                    if (!Condi)
                    {
                        L.Add(new KeyValuePair<string, int>(ite.Nom, 1));
                    }
                    else
                    {
                        L[index2] = tmp;
                    }
                }
            }
            int index3 = 0;
            foreach (KeyValuePair<string, int> color in L)
            {
                if (color.Key == NomBase)
                {
                    KeyValuePair<string, int>  tmp2 = new('§'+color.Key, color.Value);
                    L[index3] = tmp2;
                    break;
                }
                index3++;
            }
           

            return L;
        }
    }
}
