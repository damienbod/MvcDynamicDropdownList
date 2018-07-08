namespace AspNetCoreMvcDynamicViews.Views.Shared.Components.ConfigueSectionA
{
    public class ConfigueSectionAModel
    {
        public int LengthA { get; set; } = 20;

        public int LengthB { get; set; } = 20;

        // Some dummy requirements to demo the uI.
        // Length is the A + B value AB must big bigger than A. If B is set, B is adjusted.
        public int LengthAB { get; set; } = 40;

        public string PartType { get; set; } = "LL1";
    }
}
