namespace Lamb_N_Lentil.Domain
{
    public interface IEntity
    {
        int ID { get; set; } 
        string InstanceName { get; set; }
        string IngredientsInIngredient { get; set; } 
        string Description { get; set; } 
        string UpdateDate { get; set; }
        decimal SaturatedFat { get; set; }
        decimal MonounsaturatedFat { get; set; }
        decimal Calories { get; set; }
        decimal Calcium { get; set; }
        decimal TotalFat { get; set; }
        decimal CaloriesFromFat { get; set; }
        decimal Sodium { get; set; }
        decimal TotalCarbohydrate { get; set; } 
        decimal PolyunsaturatedFat { get; set; }
        decimal TransFat { get; set; }
        decimal Cholesterol { get; set; } 
        decimal Potassium { get; set; }
        decimal DietaryFiber { get; set; }
        decimal Sugars { get; set; }
        decimal Protein { get; set; }
        decimal VitaminA { get; set; }
        decimal VitaminC { get; set; }
    } 
}
