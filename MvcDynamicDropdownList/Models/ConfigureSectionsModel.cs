using AspNetCoreMvcDynamicViews.Views.Shared.Components.ConfigueSectionA;
namespace AspNetCoreMvcDynamicViews.Models
{
    public class ConfigureSectionsModel
    {
        public ConfigueSectionAGetModel ConfigueSectionAGetModel { get; set; }
    }

    public class ConfigureSectionsUpdateModel
    {
        public int Id { get; set; }

        public ConfigueSectionAGetModel ConfigueSectionAGetModel { get; set; }
    }
}

