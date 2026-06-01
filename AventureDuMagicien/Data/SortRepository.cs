using AventureDuMagicien.Models;

namespace AventureDuMagicien.Data
{
    public static class SortRepository
    {
        public static List<Sort> TousLesSorts = new List<Sort>
        {
            new Sort("Étincelle", 20, 10),
            new Sort("Éclair", 35, 20),
            new Sort("Chaîne d’Éclairs", 45, 30),
            new Sort("Tempête Foudroyante", 70, 50),

            new Sort("Flamme", 25, 15),
            new Sort("Boule de Feu", 45, 30),
            new Sort("Explosion Ardente", 65, 45),
            new Sort("Inferno", 90, 70),

            new Sort("Gel", 25, 15),
            new Sort("Éclat de Glace", 35, 20),
            new Sort("Blizzard", 60, 40),
            new Sort("Zéro Absolu", 85, 65),

            new Sort("Vent Tranchant", 40, 20),
            new Sort("Lames de Vent", 55, 30),
            new Sort("Ouragan", 80, 55),

            new Sort("Jet de Pierre", 30, 15),
            new Sort("Poing de Roche", 50, 25),
            new Sort("Séisme", 85, 60),

            new Sort("Poison", 30, 25),
            new Sort("Nuage Toxique", 55, 40),
            new Sort("Morsure Venimeuse", 70, 55),

            new Sort("Ombre Rampante", 40, 25),
            new Sort("Drain de Vie", 45, 30),
            new Sort("Voile Funeste", 65, 45),
            new Sort("Apocalypse Noire", 100, 80),

            new Sort("Rayon Sacré", 35, 20),
            new Sort("Jugement Divin", 60, 40),
            new Sort("Colère Céleste", 85, 65),

            new Sort("Choc Mental", 30, 20),
            new Sort("Cri de l’Esprit", 50, 35),
            new Sort("Domination", 75, 60),

            new Sort("Lame de Sang", 55, 30),
            new Sort("Offrande Sanglante", 80, 50),
            new Sort("Rituel Écarlate", 110, 90),

            new Sort("Marque Maudite", 60, 35),
            new Sort("Pacte Interdit", 95, 70),
            new Sort("Dernière Incantation", 140, 120),

            new Sort("Distorsion", 70, 45),
            new Sort("Faille du Néant", 100, 75),
            new Sort("Entropie", 160, 130)
        };
    }
}
