using almacen.Models;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Text.Encodings.Web;

namespace almacen.Helpers
{
    public static class HtmlHelperExtensions
    {

        public static IHtmlContent PageLinks(this IHtmlHelper html, PageInfo pageInfo, Func<int, string> pageUrl)
        {
            var result = new StringWriter();
            for (int i = 1; i <= pageInfo.totalPaginas; i++)
            {
                var tag = new TagBuilder("a");
                tag.Attributes["href"] = pageUrl(i);
                tag.Attributes["style"] = "margin-right: 5px; padding: 5px;";

                tag.InnerHtml.AppendHtml(i.ToString());
                if (i == pageInfo.paginaActual)
                {
                    tag.AddCssClass("selected");
                }
                tag.WriteTo(result, HtmlEncoder.Default);
            }
            return new HtmlString(result.ToString());
        }

    }
}
