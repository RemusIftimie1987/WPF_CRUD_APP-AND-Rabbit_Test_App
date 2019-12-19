using System.Web;
using System.Web.Mvc;

namespace Lab33_MVC_Framework_Entity
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
