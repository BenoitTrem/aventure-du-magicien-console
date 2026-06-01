using AventureDuMagicien.Models;
using AventureDuMagicien.Data;

namespace AventureDuMagicien.Models
{
    public class Jeu
    {
        Random random = new Random();

        Magicien joueur;
        Ennemie ennemi;

        int ennemisTues = 0;
        int nbFuite = 0;
        int maxFuite = 5;

        int nbPotionUtilise = 0;
        int nbPotionUtiliseTour = 0;

        bool nouvelEnnemi = false;

        const int startY = 2;

        public void Lancer()
        {
            InitialiserJoueur();
            ennemi = CreerEnnemie();
            nouvelEnnemi = true;

            while (joueur.vie > 0)
            {
                AfficherStats();

                while (ennemi.vie > 0 && joueur.vie > 0)
                {
                    AfficherMenuCombat();
                    string choix = Console.ReadLine() ?? "";

                    if (choix == "1") Attaquer();
                    else if (choix == "2") LancerSort();
                    else if (choix == "3") Soigner();
                    else if (choix == "4")
                    {
                        if (Fuir()) break;
                    }
                    else if (choix == "5")
                    {
                        FinAventure();
                        return;
                    }
                
                }

                if (ennemi.vie <= 0)
                {
                    Victoire();
                    ennemi = CreerEnnemie();
                    nouvelEnnemi = true;
                }
            }

            GameOver();
        }

        void InitialiserJoueur()
        {
            Console.Clear();
            string nom;
            do
            {
                Console.WriteLine("");
                Console.Write("Nom du magicien : ");
                nom = Console.ReadLine()?.Trim();

                if (string.IsNullOrEmpty(nom))
                {
                    Console.Clear() ;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Le nom ne peut pas être vide.");
                    Console.ResetColor();
                }
            } while (string.IsNullOrEmpty(nom));

            joueur = new Magicien(nom, 100, 25, new PotionDeVie(5, 25));

            Console.Clear();
            Console.WriteLine("");
            Console.WriteLine("Voici votre magicien:");
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(joueur.ToString());
            Console.ResetColor();

            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("Appuyez sur Entrée pour commencer l'aventure");
            Console.ReadLine();
        }

        void AfficherStats()
        {
 
            Console.Clear();

            if (nouvelEnnemi)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.SetCursorPosition(0, 0);
                Console.WriteLine("Un ennemi surgit devant vous !");
                Console.ResetColor();

                nouvelEnnemi = false; 
            }

            int leftX_ = 0;
            int rightX_ = 40;
            int startY_ = 3;

            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(leftX_, startY_);
            Console.WriteLine("Ennemi");
            Console.SetCursorPosition(leftX_, startY_ + 1);
            Console.WriteLine("-----------------------");

            string[] ennemiLignes_ = ennemi.ToString().Split('\n');
            for (int i = 0; i < ennemiLignes_.Length; i++)
            {
                Console.SetCursorPosition(leftX_, startY_ + 2 + i);
                Console.WriteLine(ennemiLignes_[i]);
            }
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.SetCursorPosition(rightX_, startY_);
            Console.WriteLine("Votre état:");
            Console.SetCursorPosition(rightX_, startY_ + 1);
            Console.WriteLine("-----------------------");

            string[] joueurLignes_ = joueur.ToString().Split('\n');
            for (int i = 0; i < joueurLignes_.Length; i++)
            {
                Console.SetCursorPosition(rightX_, startY_ + 2 + i);
                Console.WriteLine(joueurLignes_[i]);
            }
            Console.ResetColor();
        }
        void AfficherStatsApresPotion()
        {

            if (nouvelEnnemi)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.SetCursorPosition(0, 0);
                Console.WriteLine("Un ennemi surgit devant vous !");
                Console.ResetColor();

                nouvelEnnemi = false;
            }

            int leftX_ = 0;
            int rightX_ = 40;
            int startY_ = 3;

            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(leftX_, startY_);
            Console.WriteLine("Ennemi");
            Console.SetCursorPosition(leftX_, startY_ + 1);
            Console.WriteLine("-----------------------");

            string[] ennemiLignes_ = ennemi.ToString().Split('\n');
            for (int i = 0; i < ennemiLignes_.Length; i++)
            {
                Console.SetCursorPosition(leftX_, startY_ + 2 + i);
                Console.WriteLine(ennemiLignes_[i]);
            }
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.SetCursorPosition(rightX_, startY_);
            Console.WriteLine("Votre état:");
            Console.SetCursorPosition(rightX_, startY_ + 1);
            Console.WriteLine("-----------------------");

            string[] joueurLignes_ = joueur.ToString().Split('\n');
            for (int i = 0; i < joueurLignes_.Length; i++)
            {
                Console.SetCursorPosition(rightX_, startY_ + 2 + i);
                Console.WriteLine(joueurLignes_[i]);
            }
            Console.ResetColor();
        }

        void AfficherMenuCombat()
        {
            Console.SetCursorPosition(0, startY + 11);
            Console.WriteLine("Choissisez votre action");
            Console.WriteLine("1. Attaquer");
            Console.WriteLine("2. Utiliser un sort");
            Console.WriteLine("3. Soigner");
            Console.WriteLine("4. Fuir");
            Console.WriteLine("5. Arreter Aventure");

        }

        void Attaquer()
        {
            Console.Clear();
            int degatsJoueur = joueur.AttaquerEnnemie(ennemi);
            Console.WriteLine($"{joueur.nom} attaque {ennemi.nom} !");
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Dégâts infligés : {degatsJoueur}");
            Console.ResetColor();
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("État de l'ennemi:");
            Console.WriteLine("----------------");
            Console.WriteLine(ennemi.ToString());
            Console.ResetColor();

            Console.WriteLine("");
            Console.WriteLine("Appuyez sur Entrée pour continuer...");
            Console.ReadLine();

            if (ennemi.vie > 0)
            {
                Console.Clear();

                int degatsEnnemi = ennemi.AttaquerMagicien(joueur);
                Console.WriteLine($"{ennemi.nom} attaque !");
                Console.WriteLine("");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Dégâts reçus : {degatsEnnemi}");
                Console.ResetColor();
                Console.WriteLine("");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Votre état:");
                Console.WriteLine("----------------");
                Console.WriteLine(joueur.ToString());
                Console.ResetColor();
                Console.WriteLine("");
                Console.WriteLine("Appuyez sur Entrée pour continuer...");
                Console.ReadLine();
                AfficherStats();
                nbPotionUtiliseTour = 0;

            }
        }

        void LancerSort()
        {
            Console.Clear();
            Console.WriteLine("");
            Console.WriteLine("---------------------------");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"Votre mana: {joueur.Mana} / 100");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Vie ennemie: {ennemi.vie}");
            Console.ResetColor();
            Console.WriteLine("---------------------------");
            Console.WriteLine("");
            Console.WriteLine("Choisissez un sort :");
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.Blue;
            for (int i = 0; i < joueur.Sorts.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {joueur.Sorts[i]}");
            }
            Console.ResetColor();
            Console.WriteLine("0. Annuler");

            if (!int.TryParse(Console.ReadLine(), out int choix))
                return;

            if (choix <= 0 || choix > joueur.Sorts.Count)
            {
                AfficherStats();
                return;
            }
             

            Sort sortChoisi = joueur.Sorts[choix - 1];
            int degats = joueur.UtiliserSortSurEnnemie(sortChoisi, ennemi);

            if (degats == 0)
            {
                Console.Clear();
                Console.WriteLine("");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Pas assez de mana !");
                Console.ResetColor();
                Console.WriteLine("");
                Console.WriteLine("Appuyez sur Entrée pour continuer...");
                Console.ReadLine();
            }
            else
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("");
                Console.WriteLine($"Vous lancez {sortChoisi.Nom}  (-{sortChoisi.CoutMana} manas)");
                Console.WriteLine($"Mana restant : {joueur.Mana} / 100");
                Console.WriteLine("");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Dégâts infligés : {degats}");
                Console.ResetColor();
                Console.WriteLine("");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("État de l'ennemi:");
                Console.WriteLine("----------------");
                Console.WriteLine(ennemi.ToString());
                Console.ResetColor();
                Console.WriteLine("");
                Console.WriteLine("Appuyez sur Entrée pour continuer...");
                Console.ReadLine();

                if (ennemi.vie > 0)
                {
                    Console.Clear();

                    int degatsEnnemi = ennemi.AttaquerMagicien(joueur);
                    Console.WriteLine($"{ennemi.nom} attaque !");
                    Console.WriteLine("");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Dégâts reçus : {degatsEnnemi}");
                    Console.ResetColor();
                    Console.WriteLine("");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("Votre état:");
                    Console.WriteLine("----------------");
                    Console.WriteLine(joueur.ToString());
                    Console.ResetColor();
                    Console.WriteLine("");
                    Console.WriteLine("Appuyez sur Entrée pour continuer...");
                    Console.ReadLine();
                    AfficherStats();
                    nbPotionUtiliseTour = 0;

                }

            }
            AfficherStats();
        }

        void Soigner()
        {
            Console.Clear();

            if (nbPotionUtiliseTour >= 1)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Vous avez déjà utilisé une potion ce tour !");
                Console.ResetColor();
            }
            else
            {
                var resultat = joueur.Soigner(out int soin);

                switch (resultat)
                {
                    case ResultatSoinEnum.Reussi:
                        nbPotionUtilise++;
                        nbPotionUtiliseTour++;

                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"Vous récupérez {soin} points de vie.");
                        Console.WriteLine($"Potions restantes : {joueur.potions.quantite}");
                        Console.ResetColor();
                        break;

                    case ResultatSoinEnum.VieMax:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Votre vie est déjà au maximum.");
                        Console.ResetColor();
                        break;

                    case ResultatSoinEnum.PlusDePotion:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Vous n'avez plus de potions.");
                        Console.ResetColor();
                        break;
                }
            }

            AfficherStatsApresPotion();

            Console.WriteLine();
            Console.WriteLine("Appuyez sur Entrée pour continuer...");
            Console.ReadLine();
        }

        bool Fuir()
        {
            if (nbFuite >= maxFuite)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Vous êtes trop fatigué pour fuir davantage !");
                Console.WriteLine("Vous devez affronter l'ennemi.");
                Console.ResetColor();
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("Appuyez sur Entrée pour continuer...");
                Console.ReadLine();
                AfficherStats();
                return false;
            }

            Console.Clear();
            Console.WriteLine("Vous tentez de fuir...");
            Console.WriteLine("");

            bool reussite = random.Next(0, 2) == 0;

            nbFuite++;

            if (!reussite)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("L'ennemi vous rattrape !");
                Console.ResetColor();
                Console.WriteLine("");

                int consequence = random.Next(1, 5);

                if (consequence == 1)
                {
                    int perteVie = 10;
                    joueur.vie -= perteVie;
                    if (joueur.vie < 0) joueur.vie = 0;

                    Console.WriteLine($"Vous perdez {perteVie} points de vie !");
                }
                else if (consequence == 2 && joueur.potions.quantite > 0)
                {
                    joueur.potions.quantite--;
                    Console.WriteLine("Vous perdez une potion !");
                }
                else if (consequence == 3){
                    int perteForce = 5;
                    joueur.force -= perteForce;
                    if (joueur.force < 1) joueur.force = 1;

                    Console.WriteLine($"Vous perdez {perteForce} de force !");
                }
                else
                {
                    int perteMana = 10;
                    joueur.Mana-= perteMana;
                    if (joueur.Mana < 0) joueur.Mana = 0;

                    Console.WriteLine($"Vous perdez {perteMana} de mana !");
                }

                Console.WriteLine("");
                Console.WriteLine("Appuyez sur Entrée pour continuer...");
                Console.ReadLine();

                AfficherStats();

                return false; 
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Vous réussissez à fuir !");
            Console.ResetColor();

            Console.WriteLine("");
            Console.WriteLine("Appuyez sur Entrée pour continuer...");
            Console.ReadLine();

            ennemi = CreerEnnemie();
            nouvelEnnemi = true;

            return true;
        }


        void Victoire()
        {
            Console.Clear();
            ennemisTues++;

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("VICTOIRE !");
            Console.WriteLine($"Vous avez vaincu {ennemi.nom}.");
            Console.ResetColor();
            Console.WriteLine("");

            DonnerRecompense(joueur);

            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("Appuyez sur Entrée pour continuer...");
            Console.ReadLine();
            nbPotionUtiliseTour = 0;
        }

        void GameOver()
        {
            string gameOver = "GAME OVER";
            string mort = "Vous êtes mort";
            string ennemiTues_ = $"Ennemis vaincus : {ennemisTues}";
            string nbPotionUtilise_ = $"Potions utilisées : {nbPotionUtilise}";
            string nbFuite_ = $"Nombre de fuite : {nbFuite}";

            int centerX = Console.WindowWidth / 2;
            int centerY = Console.WindowHeight / 2;

            Console.ForegroundColor = ConsoleColor.DarkRed;

            Console.SetCursorPosition(centerX - gameOver.Length / 2, centerY - 3);
            Console.WriteLine(gameOver);


            Console.SetCursorPosition(centerX - mort.Length / 2, centerY);
            Console.WriteLine(mort);

            Console.SetCursorPosition(centerX - ennemiTues_.Length / 2, centerY + 2);
            Console.WriteLine(ennemiTues_);
            Console.SetCursorPosition(centerX - nbPotionUtilise_.Length / 2, centerY + 3);
            Console.WriteLine(nbPotionUtilise_);
            Console.SetCursorPosition(centerX - nbFuite_.Length / 2, centerY + 4);
            Console.WriteLine(nbFuite_);

            Console.ResetColor();

            Console.SetCursorPosition(centerX - 23, centerY + 5);
            Console.WriteLine("");

            Console.SetCursorPosition(centerX - 18, centerY + 6);
            Console.WriteLine("Appuyez sur Entrée pour continuer...");
            Console.ReadLine();

            ReinitialiserStats();
        }

        Ennemie CreerEnnemie()
        {

            int bonus = ennemisTues * 2;

            int minVie = 10;
            int maxVie = 51;
            int minForce = 10;
            int maxForce = 51;
            if (ennemisTues > 10)
            {
                minVie = 35;
                maxVie = 65;
                minForce = 25;
                maxForce = 65;
            }
            return new Ennemie(
                SelecteurListe.GetRandom(),
                random.Next(minVie + bonus, maxVie + bonus),
                random.Next(minForce + bonus, maxForce + bonus)
            );
        }
        void DonnerManaBonus(Magicien magicien)
        {
            int manaBonus = random.Next(25, 76);

            magicien.Mana += manaBonus;
            if (magicien.Mana > 100)
            {
                magicien.Mana = 100;
            }

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine($"Bonus ! Vous gagnez +{manaBonus} manas");
            Console.ResetColor();
        }
        void TenterBonusMana(Magicien magicien)
        {
            bool gagneBonus = random.Next(0, 2) == 1; 

            if (gagneBonus)
            {
                DonnerManaBonus(magicien);
            }
        }


        void DonnerRecompense(Magicien magicien)
        {
            int choix = random.Next(1, 5); 
            int minForce = 1;
            int maxForce = 6;
            int hpBoost = random.Next(5, 16);
            int manaBonus = random.Next(10, 26); 


            if (choix == 1)
            {
                magicien.potions.quantite++;
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("Vous gagnez une potion de vie.");
                Console.ResetColor();
            }
            else if (choix == 2)
            {
                int forceRandom = random.Next(minForce, maxForce);
                magicien.force += forceRandom;
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("Vous gagnez +" + forceRandom + " de force.");
                Console.ResetColor();
            }
            else if (choix == 3)
            {
                magicien.vieMax += hpBoost;
                magicien.vie += hpBoost; 

                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine($"Votre vie maximale augmente de +{hpBoost} !");
                Console.ResetColor();
            }
            else if (choix == 4) 
            {
                var sortsDisponibles = SortRepository.TousLesSorts
                    .Where(s => !magicien.Sorts.Any(ms => ms.Nom == s.Nom))
                    .ToList();

                if (sortsDisponibles.Count == 0)
                {
                    Console.WriteLine("Vous connaissez déjà tous les sorts !");
                    return;
                }

                Sort nouveauSort = sortsDisponibles[random.Next(sortsDisponibles.Count)];
                magicien.Sorts.Add(nouveauSort);

                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine($"Vous apprenez un nouveau sort : {nouveauSort.Nom} !");
                Console.ResetColor();
                return;
            }
            TenterBonusMana(magicien);
        }

        void ReinitialiserStats()
        {
            ennemisTues = 0;
            nbPotionUtilise = 0;
            nbFuite = 0;
            nbPotionUtiliseTour = 0;
        }
        public void FinAventure()
        {
            Console.Clear();
            Console.WriteLine("");
            Console.WriteLine("=============================================");
            Console.WriteLine("           FIN DE L'AVENTURE");
            Console.WriteLine("=============================================");
            Console.WriteLine("");

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Ennemis vaincus: {ennemisTues}");
            Console.WriteLine("");
            Console.WriteLine($"Potions utilisées : {nbPotionUtilise}");
            Console.WriteLine("");
            Console.WriteLine($"Nombre de fuite : {nbFuite}");
            
            Console.ResetColor();
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("Appuyez sur Entrée pour retourner au MENU...");
            Console.ReadLine();

            ReinitialiserStats();
        }
        public void AfficherRegles()
        {
            Console.Clear();
            Console.WriteLine("=============================================");
            Console.WriteLine("              RÈGLES DU JEU");
            Console.WriteLine("=============================================");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("1. Objectif du jeu");
            Console.ResetColor();
            Console.WriteLine("   Incarnez un magicien et affrontez des ennemis");
            Console.WriteLine("   pour devenir plus fort et survivre le plus longtemps possible.");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("2. Votre magicien");
            Console.ResetColor();
            Console.WriteLine("   - Vie : si elle tombe à 0, le jeu est terminé.");
            Console.WriteLine("   - Vie maximale : peut augmenter grâce à certaines récompenses.");
            Console.WriteLine("   - Force : détermine les dégâts infligés aux ennemis.");
            Console.WriteLine("   - Potions de vie : permettent de se soigner,");
            Console.WriteLine("     mais une seule potion peut être utilisée par tour.");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("3. Déroulement d’un tour");
            Console.ResetColor();
            Console.WriteLine("   À chaque rencontre avec un ennemi, vous pouvez choisir :");
            Console.WriteLine("   1. Attaquer : inflige des dégâts à l’ennemi.");
            Console.WriteLine("   2. Soigner : utiliser UNE potion pour regagner de la vie.");
            Console.WriteLine("   3. Fuir : tentez de fuir (maximum 5 fois, 50% de chance de réussir).");
            Console.WriteLine("      En cas d’échec, vous subissez une conséquence : perte de vie, de potion ou de force.");
            Console.WriteLine("   4. Arrêter l’aventure : mettre fin au combat.");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("4. Ennemis");
            Console.ResetColor();
            Console.WriteLine("   - Les ennemis apparaissent aléatoirement et deviennent plus puissants");
            Console.WriteLine("     au fur et à mesure que vous en affrontez.");
            Console.WriteLine("   - Chaque ennemi possède sa propre vie et sa force.");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("5. Récompenses");
            Console.ResetColor();
            Console.WriteLine("   Après avoir vaincu un ennemi, vous recevez UNE récompense :");
            Console.WriteLine("   - Une potion de vie");
            Console.WriteLine("   - OU un bonus de force");
            Console.WriteLine("   - OU une augmentation de la vie maximale");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("6. Fin de l’aventure");
            Console.ResetColor();
            Console.WriteLine("   - La vie du magicien tombe à 0 : Game Over");
            Console.WriteLine("   - Vous décidez d’arrêter l’aventure");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Appuyez sur Entrée pour revenir au menu...");
            Console.ReadLine();
            Console.Clear();
        }
    }
}
