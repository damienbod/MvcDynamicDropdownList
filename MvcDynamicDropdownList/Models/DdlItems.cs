using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace MvcDynamicDropdownList.Models
{
    public class DdlItems
    {
        public List<SelectListItem> Items { get; set; }
    }
}