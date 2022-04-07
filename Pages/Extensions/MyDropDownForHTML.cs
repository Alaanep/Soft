using System.Linq.Expressions;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ABC.Pages.Extensions;

public static class MyDropDownForHTML {
    public static IHtmlContent MyDropDownFor<TModel, TResult>(
        this IHtmlHelper<TModel> html, Expression<Func<TModel, TResult>> expression, IEnumerable<SelectListItem> list) {
        var h = htmlStrings(html, expression, list);
        return new HtmlContentBuilder(h);
    }

    private static List<object> htmlStrings<TModel, TResult>(IHtmlHelper<TModel> html,
        Expression<Func<TModel, TResult>> expression, IEnumerable<SelectListItem> list) {
        var l = new List<object> {
            new HtmlString("<dl class=\"row\">"),
            new HtmlString("<dd class=\"col-sm-2\">"),
            html.LabelFor(expression, null, new {@class = "control-label"}),
            new HtmlString("</dd>"),
            new HtmlString("<dd class=\"col-sm-10\">"),
            html.DropDownListFor(expression,list,  new {@class = "form-control"}),
            html.ValidationMessageFor(expression, null, new {@class = "text-danger"}),
            new HtmlString("</dd>"),
            new HtmlString("</dl>")
        };
        return l;
    }
}