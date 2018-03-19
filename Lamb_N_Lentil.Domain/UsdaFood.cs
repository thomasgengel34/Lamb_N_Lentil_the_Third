using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lamb_N_Lentil.Domain
{
    public class UsdaFood
    {
        public Foods[] foods { get; set; }
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
}
