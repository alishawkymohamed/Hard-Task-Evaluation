using System.Web;
using System.Web.Mvc;

namespace Hard_Task_Evaluation
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
