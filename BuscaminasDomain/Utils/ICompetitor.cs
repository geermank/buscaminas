namespace BuscaminasDomain.Utils
{
    internal interface ICompetitor<T>
    {
        T Oust(T rival);
    }
}
