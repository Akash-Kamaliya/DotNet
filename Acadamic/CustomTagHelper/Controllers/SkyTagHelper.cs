using Microsoft.AspNetCore.Razor.TagHelpers;

namespace TagHelperLab.TagHelpers
{
    [HtmlTargetElement("sky")]
    public class SkyTagHelper : TagHelper
    {
        public string Color { get; set; } = "blue";
        public int Height { get; set; } = 100;

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div";
            output.Attributes.SetAttribute("style", $"background-color:{Color}; height:{Height}px; width:100%; text-align:center; color:white; padding-top:10px;");
            output.Content.SetContent($"This is a Sky Tag Helper with color {Color}!");
        }
    }
}