using System.Linq.Expressions;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ABC.Pages.Extensions
{
    public static class MyEditorForHtml
    {
        public static IHtmlContent MyEditorFor<TModel, TResult>(
            this IHtmlHelper<TModel> html, Expression<Func<TModel, TResult>> expression)
        {
            var h = htmlStrings(html, expression);
            return new HtmlContentBuilder(h);
        }

        private static List<object> htmlStrings<TModel, TResult>(IHtmlHelper<TModel> html,
            Expression<Func<TModel, TResult>> expression) {
            var list = new List<object> {
                new HtmlString("<dl class=\"row\">"),
                new HtmlString("<dd class=\"col-sm-2\">"),
                html.LabelFor(expression, null, new {@class = "control-label"}),
                new HtmlString("</dd>"),
                new HtmlString("<dd class=\"col-sm-10\">"),
                html.EditorFor(expression, new {htmlAttributes = new {@class = "form-control"}}),
                html.ValidationMessageFor(expression, null, new {@class = "text-danger"}),
                new HtmlString("</dd>"),
                new HtmlString("</dl>")
            };
            return list;
        }
    }
}














