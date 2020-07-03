using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Forum.WebUI.Helpers;
using Forum.WebUI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Forum.WebUI.Controllers
{
    public class BaseController : Controller
    {
        protected IActionResult CustomResult(ApiCallResult result,string action,string controller)
        {
            if (result.Succeeded)
                return RedirectToAction(action, controller);
            else
            {
                ModelState.FillModelStateErrors(result.NoSuccessResponse.Errors);
                return View();
            }
        }

        protected IActionResult CustomResult(ApiCallResult result, string action, string controller, object routeValue=null)
        {
            if (result.Succeeded)
                return RedirectToAction(action, controller, routeValue);

            else if (result.ResultCode == ApiCallResultCode.UnAuthorized)
                return RedirectToAction("Account", "Authenticate");
            
            else
            {
                ModelState.FillModelStateErrors(result.NoSuccessResponse.Errors);
                return View();
            }
        }
        protected IActionResult StringUrlResult(ApiCallResult result,string returnUrl)
        {
            if (result.Succeeded)
            {
                if (returnUrl != null)
                    return Redirect(returnUrl);
                return RedirectToAction(nameof(AccountController), nameof(AccountController.Index));
            }
            else
            {
                ModelState.FillModelStateErrors(result.NoSuccessResponse.Errors);
                return View();
            }
        }
    }
}
