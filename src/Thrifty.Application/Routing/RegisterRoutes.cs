using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;

namespace Thrifty.Application
{
    public static class RegisterRoutes
    {
        public static void ConfigureRoutes(IRouteBuilder routes)
        {
            routes.MapRoute(
                name: "areas", 
                template: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

            routes.MapRoute(
                name: "default", 
                template: "{controller=Home}/{action=Index}");
        }
    }
}
