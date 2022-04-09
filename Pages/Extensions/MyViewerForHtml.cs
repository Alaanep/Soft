using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq.Expressions;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ABC.Pages.Extensions {
    public static class MyViewerForHtml {
        public static IHtmlContent MyViewerFor<TModel, TResult> (
            this IHtmlHelper<TModel> html, Expression<Func<TModel, TResult>> expression)  {
            var h = htmlStrings(html, expression);
            return new HtmlContentBuilder(h);
        }

        public static IHtmlContent MyViewerFor<TModel, TResult>(
            this IHtmlHelper<TModel> html, Expression<Func<TModel, TResult>> expression, dynamic value) {
            var h = htmlStrings(html, expression, value);
            return new HtmlContentBuilder(h);
        }
        private static List<object> htmlStrings<TModel, TResult>(IHtmlHelper<TModel> html, Expression<Func<TModel, TResult>> expression) {
            var list = new List<object> {
                new HtmlString("<dl class=\"row\">"),
                new HtmlString("<dt class=\"col-sm-2\">"),
                html.DisplayNameFor(expression),
                new HtmlString("</dt>"),
                new HtmlString("<dd class=\"col-sm-10\">"),
                html.DisplayFor(expression),
                new HtmlString("</dd>"),
                new HtmlString("</dl>")
            };
            return list;
        }

        private static List<object> htmlStrings<TModel, TResult>(IHtmlHelper<TModel> html, Expression<Func<TModel, TResult>> expression, dynamic value) {
            var list = new List<object> {
                new HtmlString("<dl class=\"row\">"),
                new HtmlString("<dt class=\"col-sm-2\">"),
                html.DisplayNameFor(expression),
                new HtmlString("</dt>"),
                new HtmlString("<dd class=\"col-sm-10\">"),
                html.Raw(value),
                new HtmlString("</dd>"),
                new HtmlString("</dl>")
            };
            return list;
        }
    }
}
