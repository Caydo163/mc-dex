using System.Collections.Generic;

namespace Modele
{
    public class CraftObjet : Craft
    {
        public CraftObjet(int nbF, Item o1, Item o2, Item o3, Item o4, Item o5, Item o6, Item o7, Item o8, Item o9)
            : base(nbF, o1, o2, o3, o4, o5, o6, o7, o8, o9)
        { }
        public override List<KeyValuePair<string, int>> CalculIngredient()
        {
            List<KeyValuePair<string, int>> L = new();
            List<Item> L2 = new() { Objet0_0, Objet0_1, Objet0_2, Objet1_0, Objet1_1, Objet1_2, Objet2_0, Objet2_1, Objet2_2 };
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



            return L;
        }

        
    }
}
