using System.Web;
using System.Web.Mvc;

namespace JBOB.HtmlHelpers
{
    public static class HtmlHelpers
    {
        public static IHtmlString Link(this HtmlHelper html, string text, string url)
        {
            const string template = "<a href=\"{0}\">{1}</a>";

            return new HtmlString(string.Format(template, url, text));
        }
    }
}