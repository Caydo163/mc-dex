using System;
using Xunit;
using Modele;

namespace Test_UT
{
    public class TestItem
    {
        [Theory]
        [InlineData("terre", "Terre", "0:9", null, "chemin/terre.png", "Description")]
        [InlineData("TERRE", "Terre", "10:89", "10:89", "chemin/image.png", "Description")]
        [InlineData("tErRE", "Terre", "1a:89", null, "chemin/image.png", "Description")]
        public void TestConstructor(string nom, string nomAttendu, string id, string idAttendu, string image, string description)
        {
            Item item = new(nom, id, image, description);
            Assert.NotNull(item);
            Assert.Equal(nomAttendu, item.Nom);
            Assert.Equal(idAttendu, item.Id);
            Assert.Equal(image, item.Image);
            Assert.Equal(description, item.Desc);
        }

        [Fact]
        public void TestAjouterStat()
        {
            Item item = new("Terre", "10:89", "img/terre.png", "Description");
            item.AjouterStat("Solidité", "4.2");
            item.AjouterStat("Solidité 2", "5");
            item.AjouterStat("Solidité 2", "8");
            item.AjouterStat("Solidité 3", "5");
            Assert.NotEmpty(item.ListeStats);
            Assert.Equal("4.2", item.ListeStats["Solidité"]);
            Assert.Equal("5", item.ListeStats["Solidité 2"]);
            Assert.Equal("5", item.ListeStats["Solidité 3"]);
            Assert.Equal(3, item.ListeStats.Count);
        }


        [Fact]
        public void TestAjouterTexte()
        {
            Item item = new("Terre", "10:89", "img/terre.png", "Description");
            item.AjouterTexte("Titre 1", "Texte 1");
            item.AjouterTexte("Titre 2", "Texte 2");
            item.AjouterTexte("Titre 1", "Texte 3");
            Assert.NotEmpty(item.ListeTexte);
            Assert.Equal("Titre 1", item.ListeTexte[0].Key);
            Assert.Equal("Texte 1",item.ListeTexte[0].Value);
            Assert.Equal(3, item.ListeTexte.Count);
        }


        // Ajouter craft


        [Fact]
        public void TestEqual()
        {
            Item item = new("Terre", "10:89", "img/terre.png", "Description");
            Item item2 = new("Terre", "12:1", "img/terre.png", "Description");

            Assert.True(item.Equals(item));
            Assert.False(item.Equals(item2));
        }
    }
}
