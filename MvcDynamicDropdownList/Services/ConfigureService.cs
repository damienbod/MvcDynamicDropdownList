using AspNetCoreMvcDynamicViews.Models;
using AspNetCoreMvcDynamicViews.Views.Shared.Components.ConfigueSectionA;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcDynamicDropdownList.Services
{
    public class ConfigureService
    {
        private static Dictionary<int,ConfigueSectionAModel> DummayData = new Dictionary<int, ConfigueSectionAModel>();

        public ConfigureSectionsModel GetDefaultModel()
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

            return model;
        }

        public ConfigureSectionsUpdateModel GetConfigureSectionsUpdateModel(int id)
        {
            var data = DummayData[id];
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

            return model;
        }

        public int AddConfigueSectionAModel(ConfigueSectionAModel configueSectionAModel)
        {
            int count = DummayData.Count + 1;
            DummayData.Add(count, configueSectionAModel);
            return count;
        }

        public ConfigureSectionsUpdateModel UpdateConfigueSectionAModel(int id, ConfigueSectionAGetModel configueSectionAGetModel)
        {
            var model = new ConfigureSectionsUpdateModel
            {
                ConfigueSectionAGetModel = configueSectionAGetModel,
                Id = id
            };

            UpdateSelectType(model.ConfigueSectionAGetModel);

            var data = DummayData[id];
            data.LengthA = configueSectionAGetModel.LengthA;
            data.LengthB = configueSectionAGetModel.LengthB;
            data.LengthAB = configueSectionAGetModel.LengthAB;
            data.PartType = configueSectionAGetModel.PartType;

            return model;
        }


        public void UpdateLengthA_LengthB(ConfigueSectionAGetModel configueSectionAGetModel)
        {
            if (configueSectionAGetModel.LengthAB != configueSectionAGetModel.LengthA + configueSectionAGetModel.LengthB)
            {
                configueSectionAGetModel.LengthAB = configueSectionAGetModel.LengthA + configueSectionAGetModel.LengthB;
            }
        }

        public void UpdateSelectType(ConfigueSectionAGetModel configueSectionAGetModel)
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
