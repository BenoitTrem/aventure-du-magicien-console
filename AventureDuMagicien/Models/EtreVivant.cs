namespace AventureDuMagicien.Models
{
    public class EtreVivant
    {
        public string nom { get; set; }
        public int vie { get; set; }
        public int force { get; set; }

        public EtreVivant(string nom , int vie , int force) {
            this.nom = nom;
            this.vie = vie;
            this.force = force;
        
        }
    }
}
