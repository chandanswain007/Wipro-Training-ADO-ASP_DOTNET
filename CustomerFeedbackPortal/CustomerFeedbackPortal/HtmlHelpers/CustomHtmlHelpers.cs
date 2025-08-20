// In HtmlHelpers/CustomHtmlHelpers.cs
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq.Expressions;
using System;

public static class CustomHtmlHelpers
{
    public static IHtmlContent StyledTextBoxFor<TModel, TValue>(
        this IHtmlHelper<TModel> htmlHelper,
        Expression<Func<TModel, TValue>> expression,
        string placeholderText)
    {
        var html = new System.Text.StringBuilder();
        var id = htmlHelper.IdFor(expression);
        var name = htmlHelper.NameFor(expression);

        html.AppendFormat("<input type='text' id='{0}' name='{1}' class='form-control custom-input' placeholder='{2}' />",
            id,
            name,
            placeholderText);

        return new HtmlString(html.ToString());
    }
}