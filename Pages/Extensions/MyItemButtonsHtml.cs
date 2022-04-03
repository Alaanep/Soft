using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ABC.Pages.Extensions;

public static class MyItemButtonsHtml {
    public static IHtmlContent MyItemButtons<TModel>
        (this IHtmlHelper<TModel> html, string id) {
        var s = htmlStrings(html, id);
        return new HtmlContentBuilder(s);
    }
    private static List<object> htmlStrings<TModel>(IHtmlHelper<TModel> html,  string id) {
        var list = new List<object> {
            html.MyBtn("Edit", id),
            new HtmlString("&nbsp"),
            html.MyBtn("Details", id),
            new HtmlString("&nbsp"),
            html.MyBtn("Delete", id),
        };
        return list;
    }
    private static string? pageName(IPageModel m) => m?.GetType()?.Name?.Replace("Page", "");
}