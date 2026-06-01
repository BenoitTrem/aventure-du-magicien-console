namespace AventureDuMagicien.Models
{
    public class SelecteurListe
    {
        private static Random random = new Random();

        public static string GetRandom()
        {
            Array values = Enum.GetValues(typeof(NomEnnemiEnum));

            NomEnnemiEnum randomEnum =
                (NomEnnemiEnum)values.GetValue(random.Next(values.Length));

            return randomEnum.ToString().Replace("_", " ");
        }
    }
}
