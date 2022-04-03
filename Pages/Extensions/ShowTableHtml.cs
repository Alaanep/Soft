using ABC.Facade;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ABC.Pages.Extensions;

public static class ShowTableHtml {
    public static IHtmlContent ShowTable<TModel, TView>
        (this IHtmlHelper<TModel> html, IList<TView>? items) where TModel: IIndexModel<TView> where TView: UniqueView {
        var s = htmlStrings(html, items);
        return new HtmlContentBuilder(s);
    }
    private static List<object> htmlStrings<TModel, TView>(IHtmlHelper<TModel> html, IList<TView>? items   )
        where TModel : IIndexModel<TView> where TView : UniqueView
    {
        var m = html.ViewData.Model;
        var list = new List<object>();
        list.Add(new HtmlString("<table class=\"table\">"));
        list.Add(new HtmlString("<thead>"));
        list.Add(new HtmlString("<tr>"));
        foreach (var name in m.IndexColumns) {
            list.Add(new HtmlString("<th>"));
            list.Add(html.MyTabHdr(name));
            list.Add(new HtmlString("</th>"));
        }
        list.Add(new HtmlString("<th>"));
        list.Add(new HtmlString("</th>"));
        list.Add(new HtmlString("</tr>"));
        list.Add(new HtmlString("</thead>"));
        list.Add(new HtmlString("<tbody>"));
        foreach (var item in items ?? new List<TView>()) {
            list.Add(new HtmlString("<tr>"));
            foreach (var name in m.IndexColumns) {
                list.Add(new HtmlString("<td>"));
                list.Add(html.Raw(m.GetValue(name, item)));
                list.Add(new HtmlString("</td>"));
            }
            list.Add(new HtmlString("<th>"));
            list.Add(html.MyItemButtons(item.Id));
            list.Add(new HtmlString("</th>"));
            list.Add(new HtmlString("</tr>"));
        }
        list.Add(new HtmlString("</tbody>"));
        list.Add(new HtmlString("</table>"));
        return list;
    }
}