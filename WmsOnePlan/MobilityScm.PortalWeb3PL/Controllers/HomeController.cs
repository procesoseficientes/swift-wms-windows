using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MobilityScm.PortalWeb3PL.Controllers;

namespace MobilityScm_PortalWeb3PL.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            Success("Exito", true);
            Information("Información", true);
            Warning("Alerta!", true);
            Danger("Error", true);
            return View();
        }


    }
}

public enum HeaderViewRenderMode { Full, Title }