using System;
using Xunit;
using Modele;

namespace Item_UT
{
    public class UnitTest1
    {
        [Theory]
        [InlineData("terre", "Terre", "0:9", null, "chemin/image.png", "Description")]
        [InlineData("PIERRE", "Pierre", "10:89", "10:89", "chemin/image.png", "Description")]

        public void TestConstructor(string nom, string nomAttendu, string id, string idAttendu, string image, string description)
        {
            Item item = new Item(nom, id, image, description);
            Assert.NotNull(item);
            Assert.Equal(nomAttendu, item.Nom);
            Assert.Equal(idAttendu, item.Id);
            Assert.Equal(image, item.Image);
            Assert.Equal(description, item.Desc);
        }
    }
}
