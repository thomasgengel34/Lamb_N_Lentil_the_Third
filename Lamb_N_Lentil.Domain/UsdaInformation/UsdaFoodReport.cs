namespace Lamb_N_Lentil.Domain.UsdaInformation
{
    public class UsdaFoodReport
    {
        public foods[] foods { get; set; }
    }

    public class foods
    { 
        public food  food { get; set; } 
    }

    public class food
    { 
         public ing ing { get; set; }
    }

     public class ing
    {
     public string desc { get; set; } 
     } 
}
