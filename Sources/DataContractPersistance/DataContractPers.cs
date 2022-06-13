using Modele;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.Serialization;
using System.Xml;

namespace DataContractPersistance
{
    public class DataContractPers : IPersistanceManager
    {
        //public string FilePath { get; set; } = Path.Combine(Directory.GetCurrentDirectory(), "\\..\\..\\..\\XML");
        public string FilePath { get; set; } = "..\\..\\..\\XML";
        public string FileName { get; set; } = "items.xml";

        private DataContractSerializer Serializer { get; set; } = new DataContractSerializer(typeof(IEnumerable<Item>),
                                                new DataContractSerializerSettings()
                                                {
                                                    PreserveObjectReferences = true
                                                });
        
        string PersFile => Path.Combine(FilePath, FileName);

        /// <summary>
        /// Permet de charger les items du fichier items.xml dans le IEnumerable items
        /// </summary>
        /// <returns>Le IEnumerable d'items</returns>
        /// <exception cref="FileNotFoundException"></exception>
        public IEnumerable<Item> LoadItems()
        {
            if (!File.Exists(PersFile))
            {
                throw new FileNotFoundException();
            }

            IEnumerable<Item> items;
            //List<Item> items = new()
            //{
            //    new Item("terre", "12", "img\\Terre.png", "Voici une description"),
            //    new Item("poulet", "68:12", "img\\Poulet.png", "Voici une description"),
            //    new Item("lit", "6:12", "img\\Lit.png", "Voici une description"),
            //    new Item("diamant", "62", "img\\Diamant.png", "Voici une description"),
            //    new Item("fer", "6:1299", "img\\Fer.png", "Voici une description"),
            //    new Item("coffre", "67:12", "img\\Coffre.png", "Voici une description"),
            //    new Item("planche", "1:12", "img\\Planche.png", "Voici une description"),
            //    new Item("stone", "6:78", "img\\Stone.png", "Voici une description"),
            //    new Item("planche", "112", "img\\Terre.png", "Voici une description"),
            //    new Item("planche", "6:6312", "img\\Terre.png", "Voici une description"),
            //};
            //items[0].NomE = "Dirt";
            //items[0].ListeTexte.Add(new KeyValuePair<string, string>("Titre 1", "Texte 1"));
            //items[0].ListeTexte.Add(new KeyValuePair<string, string>("Titre 2", "Texte 2"));
            //items[0].ListeStats.Add("Stat 1", "5.4");
            //items[0].ListeStats.Add("Stat 2", "10");
            //items[0].AjouterCraft(items[5], null, items[1], items[7], null, null, null, items[5], items[5], 5);
            //items[0].AjouterCraft(items[5], null, items[1], items[7], null, null, null, items[5], items[5], 5);

            //items[0].AjouterCraft(items[0], null, items[6], items[0], null, null, null, items[1], items[2], 1, items[4]);


            using (Stream s = File.OpenRead(PersFile))
            {
                items = Serializer.ReadObject(s) as IEnumerable<Item>;
            }

            /*!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!*/
            //foreach (Item item in items)
            //{
            //    item.ListeCraft = new List<Craft>();
            //}
            /*!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!*/

            return items;
        }


        /// <summary>
        /// Permet de sauvegarde la liste des items dans le fichier items.xml
        /// </summary>
        /// <param name="item"></param>
        public void SaveItems(IEnumerable<Item> item)
        {

            if (!Directory.Exists(FilePath))
            {
                Directory.CreateDirectory(FilePath);
            }

            var settings = new XmlWriterSettings() { Indent = true };
            using (TextWriter tw = File.CreateText(PersFile))
            {
                using (XmlWriter writer = XmlWriter.Create(tw, settings))
                {
                    Serializer.WriteObject(writer, item);
                }
            }
        }
    }
}