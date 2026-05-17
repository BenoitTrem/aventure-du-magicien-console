using AventureDuMagicien.Models;
using AventureDuMagicien_Ben_John.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AventureDuMagicien.Interface
{
    internal interface IActions
    {
        int AttaquerEnnemie(Ennemie ennemie);
        int UtiliserSortSurEnnemie(Sort sort, Ennemie ennemie);
        int AttaquerMagicien(Magicien magicien);
        ResultatSoinEnum Soigner(out int soinEffectue);
    }
}
