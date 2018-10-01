using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcMusicStore.Controllers
{
    public class StoreController : Controller
    {
        // GET: /Store/
        public string Index()
        {
            return "Hello from Store.Index()";
        }

        // Get: /Store/Browse/
        public string Browse()
        {
            return "Hello from Store.Browse()";
        }

        // Get" /Store/Details/
        public string Details()
        {
            return "Hello from Store.Details()";
        }
    }
}