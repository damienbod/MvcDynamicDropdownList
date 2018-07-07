using AspNetCoreMvcDynamicViews.Models;
using AspNetCoreMvcDynamicViews.Views.Shared.Components.ConfigueSectionA;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MvcDynamicDropdownList.Services;
using System.Collections.Generic;

namespace AspNetCoreMvcDynamicViews.Controllers
{
    public class ConfigureController : Controller
    {
        private readonly ConfigureService _configureService;

        public ConfigureController(ConfigureService configureService)
        {
            _configureService = configureService;
        }
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
        public IActionResult Create(ConfigueSectionAGetModel configueSectionAGetModel)
        {
            var model = new ConfigureSectionsModel
            {
                ConfigueSectionAGetModel = configueSectionAGetModel
            };

            var id = _configureService.AddConfigueSectionAModel(configueSectionAGetModel);

            return Redirect($"Update/{id}");
        }

        [HttpGet]
        public IActionResult Update([FromRoute] int id)
        {
            // GET data from database
            var data = _configureService.GetConfigueSectionAModel(id);
            var model = new ConfigureSectionsUpdateModel
            {
                ConfigueSectionAGetModel = new ConfigueSectionAGetModel
                {
                    LengthA = data.LengthA,
                    LengthB = data.LengthB,
                    LengthAB = data.LengthAB,
                    PartType = data.PartType
                },
                Id = id
            };

            UpdateSelectType(model.ConfigueSectionAGetModel);

            return View(model);
        }

        [HttpPost]
        public IActionResult Update(ConfigueSectionAGetModel configueSectionAGetModel, [FromRoute] int id)
        {
            // GET data from database
            var model = new ConfigureSectionsUpdateModel
            {
                ConfigueSectionAGetModel = configueSectionAGetModel,
                Id = id
            };

            UpdateSelectType(model.ConfigueSectionAGetModel);

            // do Update logic

            return View(model);
        }

        /// <summary>
        /// async partial update, set your properties here
        /// </summary>
        /// <param name="configueSectionAGetModel"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult UpdateViewData(ConfigueSectionAGetModel configueSectionAGetModel)
        {
            UpdateLengthA_LengthB(configueSectionAGetModel);
            UpdateSelectType(configueSectionAGetModel);

            // save to Db if required

            return PartialView("PartialConfigure", configueSectionAGetModel);
        }

        private void UpdateLengthA_LengthB(ConfigueSectionAGetModel configueSectionAGetModel)
        {
            if (configueSectionAGetModel.LengthAB != configueSectionAGetModel.LengthA + configueSectionAGetModel.LengthB)
            {
                configueSectionAGetModel.LengthAB = configueSectionAGetModel.LengthA + configueSectionAGetModel.LengthB;
            }
        }

        private void UpdateSelectType(ConfigueSectionAGetModel configueSectionAGetModel)
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
        }

    }
}