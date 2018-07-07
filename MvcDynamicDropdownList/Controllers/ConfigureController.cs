using AspNetCoreMvcDynamicViews.Models;
using AspNetCoreMvcDynamicViews.Views.Shared.Components.ConfigueSectionA;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace AspNetCoreMvcDynamicViews.Controllers
{
    public class ConfigureController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            var model = new ConfigureSectionsModel
            {
                ConfigueSectionAGetModel = new ConfigueSectionAGetModel()
            };

            model.ConfigueSectionAGetModel.PartTypeItems = new List<SelectListItem>
            {
                new SelectListItem{ Value = "LL1", Text = "LL1" },
                new SelectListItem{ Value = "LL2", Text = "LL2" },
                new SelectListItem{ Value = "LL3", Text = "LL3" }
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult Update(ConfigueSectionAModel configueSectionAModel)
        {
            // save data to db...
            //return View("Index", configueSectionAModel);
            return Ok();
        }

        [HttpPost]
        public IActionResult UpdateViewData(ConfigueSectionAGetModel configueSectionAGetModel)
        {
            if (configueSectionAGetModel.LengthAB < 200)
            {
                configueSectionAGetModel.PartTypeItems = new List<SelectListItem>
                {
                    new SelectListItem{ Value = "LL1", Text = "LL1" },
                    new SelectListItem{ Value = "LL2", Text = "LL2" },
                    new SelectListItem{ Value = "LL3", Text = "LL3" }
                };
            }
            else
            {
                configueSectionAGetModel.PartTypeItems = new List<SelectListItem>
                {
                    new SelectListItem{ Value = "LL4", Text = "LL4" },
                    new SelectListItem{ Value = "LL5", Text = "LL5" }
                };
            }

            return PartialView("PartialConfigure", configueSectionAGetModel);
        }
    }
}