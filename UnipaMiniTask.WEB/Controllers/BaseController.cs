using System.Collections.Generic;
using UnipaMiniTask.BLL;
using System.Linq;
using System.Web.Mvc;
using UnipaMiniTask.CORE;
using PagedList;

namespace UnipaMiniTask.WEB.Controllers
{
    public class BaseController : Controller
    {
        protected readonly BLLContext _bll;
        // GET: Base
        public BaseController(BLLContext bll)
        {
            if (_bll == null)
            {
                _bll = bll;
            }
        }
    }
}