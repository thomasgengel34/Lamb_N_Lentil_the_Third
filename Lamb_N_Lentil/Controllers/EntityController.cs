using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Lamb_N_Lentil.Domain;

namespace Lamb_N_Lentil.UI.Controllers
{
    public class EntityController : Controller
    {
         Controller controller;

        public EntityController()
        {

        }

        public EntityController( Controller _controller = null)
        {
            if (_controller != null) 
            {
                controller = _controller;
            }
        }


    }
}
