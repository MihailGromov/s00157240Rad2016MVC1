using System.Web;
using System.Web.Mvc;

namespace s00157240Rad2016MVC1
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
