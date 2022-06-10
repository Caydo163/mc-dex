using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Modele;
using DataContractPersistance;

namespace Test_UT
{
    public class TestManager
    {
        //[Theory]
        //[InlineData(data: new DataContractPers())]
        [Fact]
        public void TestConstructor()
        {
            IPersistanceManager elt = new DataContractPers();
            Manager manager = new Manager(elt);
            Assert.Equal(manager.Pers, elt);
            Assert.Empty(manager.Items);
        }

        [Fact]
        public void TestAjouterItem()
        {
            Manager manager = new(new DataContractPers());
            List<KeyValuePair<string, string>> listeTexte = new() { new KeyValuePair<string, string>("Titre", "texte"), new KeyValuePair<string, string>("Titre 2", "texte texte") };
            Dictionary<string, string> listeStats = new() { { "Stat 1", "3.5" }, { "Stat 2", "4" } };
            manager.AjouterItem("Terre", "Dirt", "10:89", "img/terre.png", "Description", listeTexte, listeStats);

            Assert.Single(manager.Items);
            Assert.Equal("Terre", manager.Items[0].Nom);
            Assert.Equal("Dirt", manager.Items[0].NomE);
            Assert.Equal("10:89", manager.Items[0].Id);
            Assert.Equal("Description", manager.Items[0].Desc);
            int cpt = 0;
            foreach(KeyValuePair<string, string> item in manager.Items[0].ListeTexte)
            {
                Assert.Equal(listeTexte[cpt].Key, item.Key);
                Assert.Equal(listeTexte[cpt].Value, item.Value);
                cpt++;
            }
            Assert.Equal(listeStats["Stat 1"], manager.Items[0].ListeStats["Stat 1"]);
            Assert.Equal(listeStats["Stat 2"], manager.Items[0].ListeStats["Stat 2"]);
        }


        [Fact]
        public void TestSupprimerItem()
        {
            Manager manager = new(new DataContractPers());
            List<KeyValuePair<string, string>> listeTexte = new() { new KeyValuePair<string, string>("Titre", "texte"), new KeyValuePair<string, string>("Titre 2", "texte texte") };
            Dictionary<string, string> listeStats = new() { { "Stat 1", "3.5" }, { "Stat 2", "4" } };
            Item item = manager.AjouterItem("Terre", "Dirt", "10:89", "img/terre.png", "Description", listeTexte, listeStats);

            Assert.Single(manager.Items);
            manager.SupprimerItem(item,false);
            Assert.Empty(manager.Items);
        }

        [Fact]
        public void TestRechercher()
        {
            Manager manager = new(new DataContractPers());
            List<KeyValuePair<string, string>> listeTexte = new();
            Dictionary<string, string> listeStats = new();
            manager.AjouterItem("Terre", "Dirt", "10:89", "img/terre.png", "Description", listeTexte, listeStats);
            manager.AjouterItem("Planche", "Dirt", "11:3", "img/terre.png", "Description", listeTexte, listeStats);
            manager.AjouterItem("Stone", "Pierre", "10", "img/terre.png", "Description", listeTexte, listeStats);
            manager.AjouterItem("Pelle", "Dirt", "22", "img/terre.png", "Description", listeTexte, listeStats);
            manager.AjouterItem("Herbe", "Dirt", "53", "img/terre.png", "Description", listeTexte, listeStats);

            foreach(Item item in manager.Rechercher("er"))
            {
                Assert.Contains("er", item.Nom+item.NomE+item.Id);
            }
        }


        [Fact]
        public void TestModeAjouter()
        {
            Manager manager = new(new DataContractPers());
            List<KeyValuePair<string, string>> listeTexte = new();
            Dictionary<string, string> listeStats = new();
            manager.AjouterItem("Terre", "Dirt", "10:89", "img/terre.png", "Description", listeTexte, listeStats);

            Assert.Single(manager.Items);
            Assert.Equal("10:89", manager.Items[0].Id);

            manager.ModeAjouter(true);
            Assert.Equal(3,manager.Items.Count);
            Assert.Equal("999:1", manager.Items[0].Id);
            Assert.Equal("999:2", manager.Items[1].Id);
            Assert.Equal("10:89", manager.Items[2].Id);

            manager.ModeAjouter(false);
            Assert.Single(manager.Items);
            Assert.Equal("10:89", manager.Items[0].Id);
        }
    }
}
