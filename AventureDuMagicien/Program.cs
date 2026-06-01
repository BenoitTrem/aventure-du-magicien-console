using AventureDuMagicien.Models;

Console.Clear();
Console.WriteLine("=============================================");
Console.WriteLine("   BIENVENUE DANS L'AVENTURE DU MAGICIEN");
Console.WriteLine("=============================================");
Console.WriteLine();

string choixMenu;
Jeu jeu = new Jeu();

do
{
    Console.WriteLine();
    Console.ForegroundColor = ConsoleColor.DarkYellow;
    Console.WriteLine("-----------------------------");
    Console.WriteLine("       MENU ");
    Console.WriteLine("       ----");
    Console.ResetColor();
    Console.WriteLine("1. Commencer la partie");
    Console.WriteLine("2. Voir les règles du jeu");
    Console.WriteLine("3. Quitter");
    Console.ForegroundColor = ConsoleColor.DarkYellow;
    Console.WriteLine("-----------------------------");
    Console.ResetColor();
    choixMenu = Console.ReadLine() ?? "";

    if (choixMenu == "1")
    {
        Console.Clear();
        jeu.Lancer();
        Console.Clear();
    }
    else if (choixMenu == "2")
    {
        Console.Clear();
        jeu.AfficherRegles();
        Console.Clear();
    }
    else if (choixMenu == "3")
    {
        Console.Clear();
        Console.WriteLine("=============================");
        Console.WriteLine("           Bye");
        Console.WriteLine("=============================");
    }
    else
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Choix invalide.");
        Console.WriteLine("");
        Console.ResetColor();
    }

} while (choixMenu != "3");


