using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace AspNetCoreMvcDynamicViews.Views.Shared.Components.ConfigueSectionA
{
    public class ConfigueSectionAGetModel : ConfigueSectionAModel
    {
        public List<SelectListItem> PartTypeItems { get; set; }
    }
}
