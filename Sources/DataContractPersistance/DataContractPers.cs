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
        public string FilePath { get; set; } = Path.Combine(Directory.GetCurrentDirectory(), "XML");
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