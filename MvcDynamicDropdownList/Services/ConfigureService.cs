using AspNetCoreMvcDynamicViews.Views.Shared.Components.ConfigueSectionA;
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
    }
}
