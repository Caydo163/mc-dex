using System;
using System.Collections.Generic;
using Modele;

namespace StubLib
{
    public class Stub : IPersistanceManager
    {
        List<Item> items = new()
        {
            new Item("terre", "12", "img\\Terre.png", "Voici une description"),
            new Item("poulet", "68:12", "img\\Poulet.png", "Voici une description"),
            new Item("lit", "6:12", "img\\Lit.png", "Voici une description"),
            new Item("diamant", "62", "img\\Diamant.png", "Voici une description"),
            new Item("fer", "6:1299", "img\\Fer.png", "Voici une description"),
            new Item("coffre", "67:12", "img\\Coffre.png", "Voici une description"),
            new Item("planche", "1:12", "img\\Planche.png", "Voici une description"),
            new Item("stone", "6:78", "img\\Stone.png", "Voici une description"),
            new Item("planche", "112", "img\\Terre.png", "Voici une description"),
            new Item("planche", "6:6312", "img\\Terre.png", "Voici une description"),
        };
        public IEnumerable<Item> LoadItems()
        {
            items[0].NomE = "Dirt";
            items[0].ListeTexte.Add(new KeyValuePair<string, string>("Titre 1", "Texte 1"));
            items[0].ListeTexte.Add(new KeyValuePair<string, string>("Titre 2", "Texte 2"));
            items[0].ListeStats.Add("Stat 1", "5.4");
            items[0].ListeStats.Add("Stat 2", "10");
            items[0].AjouterCraft(items[5], null, items[1], items[7], null, null, null, items[5], items[5], 5);
            items[0].AjouterCraft(items[5], null, items[1], items[7], null, null, null, items[5], items[5], 5);

            items[0].AjouterCraft(items[0], null, items[6], items[0], null, null, null, items[1], items[2], 1, items[4]);

            return items;
        }
    }
}
