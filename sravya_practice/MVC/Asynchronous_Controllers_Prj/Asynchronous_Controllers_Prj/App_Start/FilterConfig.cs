﻿using System.Web;
using System.Web.Mvc;

namespace Asynchronous_Controllers_Prj
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
