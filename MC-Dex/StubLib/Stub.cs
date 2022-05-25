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
            new Item("planche", "6:12", "img\\Terre.png", "Voici une description"),
            new Item("planche", "6:12", "img\\Terre.png", "Voici une description"),
            new Item("planche", "6:12", "img\\Terre.png", "Voici une description"),
            new Item("planche", "6:12", "img\\Terre.png", "Voici une description"),
            new Item("planche", "6:12", "img\\Terre.png", "Voici une description"),
            new Item("planche", "6:12", "img\\Terre.png", "Voici une description"),
            new Item("planche", "6:12", "img\\Terre.png", "Voici une description"),
            new Item("planche", "6:12", "img\\Terre.png", "Voici une description"),
            new Item("planche", "6:12", "img\\Terre.png", "Voici une description"),
        };
        public IEnumerable<Item> LoadItems()
        {
            items[0].NomE = "Dirt";
            items[0].ListeTexte.Add(new KeyValuePair<string, string>("Titre 1", "Texte 1"));
            items[0].ListeTexte.Add(new KeyValuePair<string, string>("Titre 2", "Texte 2"));
            items[0].ListeStats.Add("Stat 1", 5.4);
            items[0].ListeStats.Add("Stat 2", 10);

            return items;
        }
    }
}
