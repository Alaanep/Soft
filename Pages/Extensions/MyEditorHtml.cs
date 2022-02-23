using System.Linq.Expressions;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ABC.Pages.Extensions
{
    public static class MyEditorForHtml
    {
        public static IHtmlContent MyEditorFor<TModel, TResult>(this IHtmlHelper<TModel>html, Expression<Func<TModel, TResult>> expression)
        {
            var h = htmlStrings(html, expression);
            return new HtmlContentBuilder(h);
        } 
        private static List<object> htmlStrings<TModel, TResult>(IHtmlHelper<TModel> html, Expression<Func<TModel, TResult>> expression)
        {
            var list = new List<object>();
            list.Add(new HtmlString("<div class=\"row\">"));
                list.Add(new HtmlString("<dd class=\"col-sm-2\">"));
                    list.Add(html.LabelFor(expression, null, new {@class="control-label"}));
                list.Add(new HtmlString("</dd>"));
                list.Add(new HtmlString("<dd class\"col-sm-10\">"));
                    list.Add(html.EditorFor(expression, new {htmlAttributes=new {@class="from-control"}}));
                    list.Add(new HtmlString("&nbsp;"));
                    list.Add(new HtmlString("&nbsp;"));
                    list.Add(html.ValidationMessageFor(expression, null, new {@class="text-danger"}));
                list.Add(new HtmlString("</dd>"));
            list.Add(new HtmlString("</div>"));
            return list;
        }
    }

}
