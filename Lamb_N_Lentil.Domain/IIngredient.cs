namespace Lamb_N_Lentil.Domain
{
    public interface IIngredient : IEntity
    {
        string Ndbno { get; set; }
        string Label { get; set; }
        decimal Eqv { get; set; }
        decimal Calories { get; set; }
    }
}
