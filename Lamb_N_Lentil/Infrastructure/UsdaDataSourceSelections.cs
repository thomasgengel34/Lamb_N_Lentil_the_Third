using System.ComponentModel.DataAnnotations;

namespace Lamb_N_Lentil.UI.Infrastructure
{
    public enum UsdaDataSourceSelections
    { 
        [Display(Name = "Branded Food Products")]
        BrandedDatabase,

        [Display(Name = "Standard Reference")]
        StandardDatabase,

        [Display(Name = "All Data Sources")]
        Both,
    }
}