using AspNetCoreMvcDynamicViews.Models;
using AspNetCoreMvcDynamicViews.Views.Shared.Components.ConfigueSectionA;
using Microsoft.AspNetCore.Mvc;
using MvcDynamicDropdownList.Services;

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
            return View(_configureService.GetDefaultModel());
        }

        /// <summary>
        /// create a new object
        /// </summary>
        /// <param name="configueSectionAGetModel"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ConfigueSectionAGetModel configueSectionAGetModel)
        {
            var model = new ConfigureSectionsModel
            {
                ConfigueSectionAGetModel = configueSectionAGetModel
            };

            if (ModelState.IsValid)
            {
                var id = _configureService.AddConfigueSectionAModel(configueSectionAGetModel);
                return Redirect($"Update/{id}");
            }

            return View("Index", model);
        }

        /// <summary>
        /// Get an update object
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Update([FromRoute] int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var model = _configureService.GetConfigureSectionsUpdateModel(id);
            return View(model);
        }

        /// <summary>
        /// Do an update
        /// </summary>
        /// <param name="configueSectionAGetModel"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(ConfigueSectionAGetModel configueSectionAGetModel, [FromRoute] int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var model = _configureService.UpdateConfigueSectionAModel(id, configueSectionAGetModel);
            return View(model);
        }

        /// <summary>
        /// async partial update, set your properties here
        /// </summary>
        /// <param name="configueSectionAGetModel"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateViewData(ConfigueSectionAGetModel configueSectionAGetModel)
        {
            _configureService.UpdateLengthA_LengthB(configueSectionAGetModel);
            _configureService.UpdateSelectType(configueSectionAGetModel);
            return PartialView("PartialConfigure", configueSectionAGetModel);
        }
  
    }
}