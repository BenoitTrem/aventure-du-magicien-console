
using AventureDuMagicien.Models;

namespace AventureDuMagicienTests
{
    public class UnitTest1
    {
        [Fact]
        public void AttaquerEnnemie_ReduitLaVieDeLEnnemi()
        {

            var potion = new PotionDeVie(1, 20);
            var magicien = new Magicien("Gandalf", 100, 30, potion);
            var ennemi = new Ennemie("Orge", 80, 10);

            int degats = magicien.AttaquerEnnemie(ennemi);

            Assert.Equal(30, degats);
            Assert.Equal(50, ennemi.vie);
        }

        [Fact]
        public void AttaquerMagicien_NePassePasSousZero()
        {
            var potion = new PotionDeVie(1, 20);
            var magicien = new Magicien("Merlin", 20, 10, potion);
            var ennemi = new Ennemie("Dragon", 100, 50);

            ennemi.AttaquerMagicien(magicien);

            Assert.Equal(0, magicien.vie);
        }
        [Fact]
        public void Soigner_UtiliseUnePotion_EtSoigne()
        {
            var potion = new PotionDeVie(2, 25);
            var magicien = new Magicien("Bob", 50, 10, potion);

            var resultat = magicien.Soigner(out int soin);

            Assert.Equal(ResultatSoinEnum.Reussi, resultat);
            Assert.Equal(25, soin);
            Assert.Equal(75, magicien.vie);
            Assert.Equal(1, magicien.potions.quantite);
        }

        [Fact]
        public void Soigner_NeDepassePasVieMax()
        {
            var potion = new PotionDeVie(1, 50);
            var magicien = new Magicien("Bob 2", 90, 10, potion);

            var resultat = magicien.Soigner(out int soin);

            Assert.Equal(ResultatSoinEnum.Reussi, resultat);
            Assert.Equal(10, soin);
            Assert.Equal(100, magicien.vie);
            Assert.Equal(0, magicien.potions.quantite);
        }

        [Fact]
        public void Soigner_SansPotion_NeChangeRien()
        {
            var potion = new PotionDeVie(0, 25);
            var magicien = new Magicien("Test", 60, 10, potion);

            var resultat = magicien.Soigner(out int soin);

            Assert.Equal(ResultatSoinEnum.PlusDePotion, resultat);
            Assert.Equal(0, soin);
            Assert.Equal(60, magicien.vie);
            Assert.Equal(0, magicien.potions.quantite);
        }
    }
}
