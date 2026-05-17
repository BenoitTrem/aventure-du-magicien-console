using System;
using System.Collections.Generic;
using System.Text;

namespace AventureDuMagicien_Ben_John.Models
{
    public class Sort
    {
        public string Nom { get; }
        public int Degats { get; }
        public int CoutMana { get; }

        public Sort(string nom, int degats, int coutMana)
        {
            Nom = nom;
            Degats = degats;
            CoutMana = coutMana;
        }

        public override string ToString()
        {
            return $"{Nom} (Dégâts: {Degats}, Mana nécessaire: {CoutMana})";
        }
    }


}
