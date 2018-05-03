namespace Lamb_N_Lentil.Domain
{
    public interface IIngredient : IEntity
    {
        string Ndbno { get; set; }
        string Label { get; set; }
        decimal Eqv { get; set; }
        decimal Calories { get; set; }
        decimal TotalFat { get; set; }
        decimal CaloriesFromFat { get; set; }
        decimal Sodium { get; set; }
        decimal TotalCarbohydrate { get; set; }
    }
}
