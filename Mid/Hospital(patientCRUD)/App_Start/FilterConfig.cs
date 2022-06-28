using System.Web;
using System.Web.Mvc;

namespace Hospital_patientCRUD_
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
