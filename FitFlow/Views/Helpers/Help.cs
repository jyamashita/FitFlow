using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.WebPages;

namespace FitFlow.Views.Helpers
{
    public class Help
    {
        public static HtmlHelper Html
        {
            get { return ((System.Web.Mvc.WebViewPage)WebPageContext.Current.Page).Html; }
        }

        public static UrlHelper Url
        {
            get { return ((System.Web.Mvc.WebViewPage)WebPageContext.Current.Page).Url; }
        }

        public static AjaxHelper Ajax
        {
            get { return ((System.Web.Mvc.WebViewPage)WebPageContext.Current.Page).Ajax; }
        }
    }
}