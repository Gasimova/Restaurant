using System.Web.Mvc;

namespace FinalProject.Areas.AdminPanel
{
    public class AdminPanelAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "AdminPanel";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "AdminPanel_default",
                "AdminPanel/{controller}/{action}/{id}",
                new { controller = "Home", action = "Login", id = UrlParameter.Optional },
                new[] { "FinalProject.Areas.AdminPanel.Controllers" }
            );
        }
    }
}