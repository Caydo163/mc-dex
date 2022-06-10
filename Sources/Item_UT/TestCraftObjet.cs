using System;
using Xunit;
using Modele;
using System.Collections.Generic;

namespace Test_UT
{
    public class TestCraftObjet
    {
        [Theory]
        [InlineData("Terre", "10:89", "chemin/image.png", "Description")]
        [InlineData("Pierre", "10", "chemin/image.png", "Description")]

        public void TestConstructor(string nom, string id, string image, string description)
        {
            Item item = new(nom, id, image, description);
            Item item2 = new(nom+'1', id, image, description);
            CraftObjet craft = new(2,item,item,item,item2,item2,null,null,null,null);
            Assert.NotNull(craft);
            Assert.Equal(nom,craft.Objet0_0.Nom);
            Assert.Equal(nom, craft.Objet0_1.Nom);
            Assert.Equal(nom, craft.Objet0_2.Nom);
            Assert.Equal(nom+'1', craft.Objet1_0.Nom);
            Assert.Equal(nom+'1', craft.Objet1_1.Nom);
            Assert.Equal(2, craft.NbFinal);
            Assert.Null(craft.Objet1_2);
        }

        [Fact]

        public void TestCalculIngredient()
        {
            Item item = new("Terre", "10:89", "chemin/image.png", "Description");
            Item item2 = new("Terre1", "10:89", "chemin/image.png", "Description");
            CraftObjet craft = new(2, item, item, item, item2, item2, null, null, null, null);
            List<KeyValuePair<string, int>> Ingred = craft.CalculIngredient();
            Assert.NotNull(craft);
            Assert.Equal(2, Ingred.Count);
            Assert.Equal("Terre", Ingred[0].Key);
            Assert.Equal(3, Ingred[0].Value);
            Assert.Equal("Terre1", Ingred[1].Key);
            Assert.Equal(2, Ingred[1].Value);
        }
    }
}
