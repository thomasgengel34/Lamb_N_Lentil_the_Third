using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lamb_N_Lentil.Domain
{
    public class UsdaItem
    {
        public ListOMatic list { get; set; }



        public class ListOMatic
        {
            public ItemOMatic[] item { get; set; }
            public int total { get; set; }

            public class ItemOMatic
            {
                public string name { get; set; }
                public int ndbno { get; set; }
            }
        }
    }
}
