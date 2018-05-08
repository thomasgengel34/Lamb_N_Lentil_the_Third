using System.ComponentModel;

namespace Lamb_N_Lentil.Domain
{
    public class Entity : IIngredient, INotifyPropertyChanged
    {
        private decimal _CaloriesFromFat;
        private decimal _TotalFat;
        public event PropertyChangedEventHandler PropertyChanged;

        public int ID { get; set; }
        public string InstanceName { get; set; }
        public string IngredientsInIngredient { get; set; }
        public string Ndbno { get; set; }
        public decimal Calcium { get; set; }
        public string Description { get; set; }
        public decimal Iron { get; set; }
        public decimal Sodium { get; set; }
        public decimal TotalCarbohydrate { get; set; }
        public decimal SaturatedFat { get; set; }
        public decimal TransFat { get; set; }
        public string UpdateDate { get; set; }
        public decimal Calories { get; set; }
        public decimal Cholesterol { get; set; }
        public decimal Potassium { get; set; }
        public decimal DietaryFiber { get; set; }
        public decimal Sugars { get; set; }
        public decimal Protein { get; set; }
        public decimal VitaminA { get; set; }
        public decimal VitaminB6 { get; set; }
        public decimal VitaminB12 { get; set; }
        public decimal VitaminC { get; set; }
        public decimal VitaminD { get; set; }
        public decimal Thiamine { get; set; }
        public decimal Riboflavin { get; set; }
        public decimal Niacin { get; set; }

        string IIngredient.Label { get; set; }
        decimal IIngredient.Eqv { get; set; }

        string IIngredient.Ndbno { get; set; }

        public decimal TotalFat
        {
            get { return _TotalFat; }
            set
            {
                _TotalFat = value;
                OnPropertyChanged("IIngredient.TotalFat");
            }
        }
        public decimal CaloriesFromFat
        {
            get { return _CaloriesFromFat; }
            set { _CaloriesFromFat = value; }
        }

        public decimal MonounsaturatedFat { get; set; }
        public decimal PolyunsaturatedFat { get; set; }

        public Entity()
        {
            _CaloriesFromFat = 9 * _TotalFat;
        }

        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
            _CaloriesFromFat = 9 * _TotalFat;
        }
    }
}
