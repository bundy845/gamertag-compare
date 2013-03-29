using System;
using System.Web.Mvc;

namespace Site.App_Start
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            if (filters == null)
                throw new ArgumentNullException("filters");

            filters.Add(new HandleErrorAttribute());
        }
    }
}