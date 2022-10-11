using System.Web;
using System.Web.Mvc;

namespace Crud.NorthW.App.SWApi.MVC
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
