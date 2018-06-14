using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MvcDynamicDropdownList.Models;
using System.Collections.Generic;

namespace MvcDynamicDropdownList.Controllers
{
    public class BackController : Controller
    {
        public IActionResult IndexPost()
        {
            return View();
        }

        public IActionResult IndexGet()
        {
            return View();
        }

        // SomeDataFromAPost
        [HttpPost]
        public IActionResult SomeDataFromAPost(string dummyData)
        {
            var model = new DdlItems
            {
                Items = new List<SelectListItem>
                {
                    new SelectListItem { Text = "H1", Value = "H1Value"},
                    new SelectListItem { Text = "This is cool", Value = "cool"}
                }
            };
            return View("IndexPost", model);
        }

        // SomeDataFromAPostGet
        [HttpGet]
        public IActionResult SomeDataFromAGet(string dummyData)
        {
            var model = new DdlItems
            {
                Items = new List<SelectListItem>
                {
                    new SelectListItem { Text = "H1", Value = "H1Value"},
                    new SelectListItem { Text = "This is cool", Value = "cool"}
                }
            };
            return View("IndexGet", model);
        }
    }
}