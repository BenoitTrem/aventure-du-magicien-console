using AventureDuMagicien.Interface;
using AventureDuMagicien_Ben_John.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AventureDuMagicien.Models
{
    public class Magicien : EtreVivant , IActions
    {

        public int vieMax { get; set; } = 100;
        public int Mana { get; set; } = 100;


        public PotionDeVie potions {get; set;}
        public List<Sort> Sorts { get; set; } = new List<Sort>();


        public Magicien(string nom, int vie, int force , PotionDeVie potions) : base(nom, vie, force) 
        {
            this.potions = potions;
            Sorts.Add(new Sort("Boule de feu", 20, 10));
        }
    

        public int AttaquerEnnemie(Ennemie ennemie)
        {
            ennemie.vie -= force;
            if (ennemie.vie < 0)
                ennemie.vie = 0;

            return force;
        }

        public ResultatSoinEnum Soigner(out int soinEffectue)
        {
            soinEffectue = 0;

            if (potions.quantite <= 0)
                return ResultatSoinEnum.PlusDePotion;

            if (vie >= vieMax)
                return ResultatSoinEnum.VieMax;

            int soin = potions.vieAjoute;

            if (vie + soin > vieMax)
                soin = vieMax - vie;

            vie += soin;
            potions.quantite--;
            soinEffectue = soin;

            return ResultatSoinEnum.Reussi;
        }

        public override string ToString()
        {
            return
                $"Nom: {nom}\n" +
                $"Vie: {vie} / {vieMax}\n" +
                $"Mana: {Mana} / 100\n" +
                $"Force: {force}\n" +
                potions.ToString();
        }


        public int AttaquerMagicien(Magicien magicien)
        {
            throw new NotImplementedException();
        }

        public int UtiliserSortSurEnnemie(Sort sort, Ennemie ennemie)
        {
            if (Mana < sort.CoutMana)
                return 0;

            Mana -= sort.CoutMana;
            ennemie.vie -= sort.Degats;

            if (ennemie.vie < 0)
                ennemie.vie = 0;

            return sort.Degats;
        }

    }
}
