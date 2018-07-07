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

        public ConfigueSectionAModel GetConfigueSectionAModel(int id)
        {
            return DummayData[id];
        }

        public int AddConfigueSectionAModel(ConfigueSectionAModel configueSectionAModel)
        {
            int count = DummayData.Count + 1;
            DummayData.Add(count, configueSectionAModel);
            return count;
        }

        public void UpdateConfigueSectionAModel(int id, ConfigueSectionAModel configueSectionAModel)
        {
            var data = GetConfigueSectionAModel(id);

            data.LengthA = configueSectionAModel.LengthA;
            data.LengthB = configueSectionAModel.LengthB;
            data.LengthAB = configueSectionAModel.LengthAB;
            data.PartType = configueSectionAModel.PartType;

            DummayData[id] = data;
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
