using System.Web;
using System.Web.Mvc;

namespace WebAppLab29_09_22
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
