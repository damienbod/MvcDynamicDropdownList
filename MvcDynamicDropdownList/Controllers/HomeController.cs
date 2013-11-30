using System.Collections.Generic;
using System.Web.Mvc;
using MvcDynamicDropdownList.Models;

namespace MvcDynamicDropdownList.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            
            return View();
        }

        public ActionResult DynamicDropDownList()
        {
            var model = new DdlItems();
            model.Items = new List<SelectListItem>
            {
                new SelectListItem {Selected = true, Text = "H1", Value = "H1Value"}
            };
            return View(model);
        }
    }
}
