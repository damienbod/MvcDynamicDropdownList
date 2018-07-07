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

        /// <summary>
        /// Get a new object, used for the create
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// create a new object
        /// </summary>
        /// <param name="configueSectionAGetModel"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Get an update object
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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

            _configureService.UpdateSelectType(model.ConfigueSectionAGetModel);

            return View(model);
        }

        /// <summary>
        /// Do an update
        /// </summary>
        /// <param name="configueSectionAGetModel"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Update(ConfigueSectionAGetModel configueSectionAGetModel, [FromRoute] int id)
        {
            var model = new ConfigureSectionsUpdateModel
            {
                ConfigueSectionAGetModel = configueSectionAGetModel,
                Id = id
            };

            _configureService.UpdateSelectType(model.ConfigueSectionAGetModel);
            _configureService.UpdateConfigueSectionAModel(id, model.ConfigueSectionAGetModel);

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
            _configureService.UpdateLengthA_LengthB(configueSectionAGetModel);
            _configureService.UpdateSelectType(configueSectionAGetModel);
            return PartialView("PartialConfigure", configueSectionAGetModel);
        }
  
    }
}