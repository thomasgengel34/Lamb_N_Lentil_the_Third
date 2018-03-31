namespace Lamb_N_Lentil.Domain
{
    public class UsdaFoodReport
    {
        public report report { get; set; }
    }

    public class report
    {
        public string sr { get; set; }
        public string type { get; set; }
        public food food { get; set; }
    }

    public class food
    {
        public int ndbno { get; set; }
        public string name { get; set; }
        public string fg { get; set; }
        public string manu { get; set; }
        public string ds { get; set; }
    }
}
