using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ToDo.Controllers
{
    public class ValidationController : Controller
    {
        public JsonResult IsTitleValid(string title)
        {
            return Json(title != "Hello");
        }

    }
}
