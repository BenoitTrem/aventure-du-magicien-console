using AventureDuMagicien.Models;

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
