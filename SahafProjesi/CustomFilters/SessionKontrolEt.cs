using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace SahafProjesi.CustomFilters
{
    public class SessionKontrolEt : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);
            if (context.HttpContext.Session.GetInt32("kullaniciId") == null)
                context.Result = new RedirectToActionResult("Index", "Login", null);
        }
    }
}
