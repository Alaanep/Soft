using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace ABC.Pages.Extensions;

public static class MyTabBtnHtml
{
    public static IHtmlContent MyBtn<TModel>
        (this IHtmlHelper<TModel> html, string handler, string id) {
        var s = htmlStrings(handler, id, html.ViewData.Model as IPageModel);
        return new HtmlContentBuilder(s);
    }

    private static List<object> htmlStrings(string handler, string id, IPageModel? m) {
        var list = new List<object> {
            new HtmlString($"<a href=\"/{pageName(m)}/{handler}?"),
            new HtmlString($"handler={handler}&amp;"),
            new HtmlString($"id={id}&amp;"),
            new HtmlString($"order={m?.CurrentOrder}&amp;"),
            new HtmlString($"idx={m?.PageIndex ?? 0}&amp;"),
            new HtmlString($"filter={m?.CurrentFilter}\">"),
            new HtmlString($"{handler}</a>")
        };
        return list;
    }
    private static string? pageName(IPageModel m) => m?.GetType()?.Name?.Replace("Page", "");
}

