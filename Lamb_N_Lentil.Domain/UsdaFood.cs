namespace Lamb_N_Lentil.Domain
{
    public class UsdaFood
    {
        public Foods[] foods { get; set; }
        public list list { get; set; }
    }

    public class Foods
    {
        public Food food { get; set; }

        public class Food
        {
            public Desc desc { get; set; }
            public Ing ing { get; set; }
            public Footnote[] footnotes { get; set; }

            public class Desc
            {
                public string Name { get; set; }
                public int Ndbno { get; set; }
            }

            public class Ing
            {
                public string desc { get; set; }
            }

            public class Footnote
            {
                public string desc { get; set; }
            }
        }
    }

    public class list
    {
        public  string q  { get; set; }
        public int sr { get; set; }
        public string ds { get; set; }
        public int start { get; set; }
        public int end { get; set; }
        public int total { get; set; }
        string group { get; set; }
        string sort { get; set; }


        public Food[] item { get; set; }


        public class Food
        {
            public int offset { get; set; }
            public string group { get; set; }
            public string name { get; set; }
            public int ndbno { get; set; }
            public string ds { get; set; }


            public Desc desc { get; set; }
            public Ing ing { get; set; }
            public Footnote[] footnotes { get; set; }

            public class Desc
            {
                public string Name { get; set; }
                public int Ndbno { get; set; }
            }

            public class Ing
            {
                public string desc { get; set; }
            }

            public class Footnote
            {
                public string desc { get; set; }
            }
        }
    }
}
