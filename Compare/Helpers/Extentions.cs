using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Site.Helpers
{
    public static class Extentions
    {
        public static MvcHtmlString Button(this HtmlHelper helper, string text,
                                     IDictionary<string, object> htmlAttributes, string name = "button")
        {
            var builder = new TagBuilder(name);
            builder.InnerHtml = text;
            builder.MergeAttributes(htmlAttributes);
            return MvcHtmlString.Create(builder.ToString());
        }
    }
}