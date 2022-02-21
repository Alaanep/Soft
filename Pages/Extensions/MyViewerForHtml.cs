using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq.Expressions;


namespace ABC.Pages.Extensions
{
    public static class MyViewerForHtml
    {
        public static IHtmlContent MyViewerFor<TModel, TResult>(this IHtmlHelper<TModel> html, Expression<Func<TModel, TResult>> expression)
        {
            var h = htmlStrings(html, expression);
            return new HtmlContentBuilder(h);
        }

        private static List<object> htmlStrings<TModel, TResult>(IHtmlHelper<TModel> html, Expression<Func<TModel, TResult>> expression)
        {
            
            var list = new List<object>();
            list.Add(new HtmlString("<dl class=\"row\">"));
            list.Add(new HtmlString("<dt class=\"col-sm-2\">"));
            list.Add(html.DisplayNameFor(expression));
            list.Add(new HtmlString("</dt>"));
            list.Add(new HtmlString("<dd class=\"col-sm-10\">"));
            list.Add(html.DisplayFor(expression));
            list.Add(new HtmlString("</dd>"));
            list.Add(new HtmlString("</dl>"));
            return list;
        }
    }
}
