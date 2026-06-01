namespace AventureDuMagicien.Models
{
    public class PotionDeVie
    {
        public int quantite { get; set; }
        public int vieAjoute { get; set; }

        public PotionDeVie(int quantite, int vieAjoute)
        {
            this.quantite = quantite;
            this.vieAjoute = vieAjoute;
        }

        public override string ToString()
        {
            return "Nombre de potions: " + quantite;
        }
    }
}
