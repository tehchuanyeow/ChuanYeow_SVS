using System.Web;
using System.Web.Mvc;

namespace ChuanYeow_SVS_FullWebApp
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
