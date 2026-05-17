using AventureDuMagicien.Interface;
using AventureDuMagicien_Ben_John.Models;
using System;
using System.Collections.Generic;
using System.Text;


namespace AventureDuMagicien.Models
{
    public class Ennemie : EtreVivant , IActions
    {
      

       public Ennemie(string nom ,int vie , int force):base(nom , vie , force) {
            this.nom = nom;
            this.vie = vie;
            this.force = force;
        }

        public int AttaquerMagicien(Magicien magicien)
        {
            magicien.vie -= force;
            if (magicien.vie < 0)
                magicien.vie = 0;

            return force;
        }

        public override string ToString()
        {
            return "Nom: " + nom + "\nVie: " + vie + "\nForce: " + force;
        }

        public int AttaquerEnnemie(Ennemie ennemie)
        {
           
            throw new NotImplementedException();
        }

        ResultatSoinEnum IActions.Soigner(out int soinEffectue)
        {
            throw new NotImplementedException();
        }

        public int UtiliserSortSurEnnemie(Sort sort, Ennemie ennemie)
        {
            throw new NotImplementedException();
        }
    }
}
