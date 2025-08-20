// In TagHelpers/StarRatingTagHelper.cs
using Microsoft.AspNetCore.Razor.TagHelpers;

[HtmlTargetElement("star-rating")]
public class StarRatingTagHelper : TagHelper
{
    public int Rating { get; set; }

    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        output.TagName = "div";
        output.Attributes.SetAttribute("class", "star-rating");
        for (int i = 1; i <= 5; i++)
        {
            var starClass = (i <= Rating) ? "filled" : "empty";
            output.Content.AppendHtml($"<span class='star {starClass}'>&#9733;</span>");
        }
    }
}