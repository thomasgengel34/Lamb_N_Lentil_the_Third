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
        public string Description { get; set; }
        public decimal Sodium { get; set; }
        public decimal TotalCarbohydrate { get; set; }
        public decimal SaturatedFat { get; set; }
        public string UpdateDate { get; set; }

        string IIngredient.Label { get; set; }
        decimal IIngredient.Eqv { get; set; }
        decimal IIngredient.Calories { get; set; }
        string IIngredient.Ndbno { get; set; }
       
        decimal IIngredient.TotalFat
        {
            get { return _TotalFat; }
            set
            {
                _TotalFat = value;
                OnPropertyChanged("IIngredient.TotalFat");
            }
        }
        decimal IIngredient.CaloriesFromFat
        {
            get { return _CaloriesFromFat; }
            set { _CaloriesFromFat = value; }
        }

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
