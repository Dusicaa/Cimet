using System.Web.Mvc;

namespace Sajt.Areas.Admin
{
    public class AdminAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Admin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
        //    context.MapRoute(
        //        "Admin",
        //        "{controller}/{action}/{id}",
        //        new { action = "Index", id = UrlParameter.Optional }
        //    );


            context.MapRoute(
                name:"Admin_default",
               url: "{controller}/{action}/{id}",
               defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}