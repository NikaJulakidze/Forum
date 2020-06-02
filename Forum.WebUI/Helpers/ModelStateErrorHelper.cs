using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Forum.WebUI.Helpers
{
    public static class ModelStateErrorHelper
    {
        public static void FillModelStateErrors (this ModelStateDictionary modelstate,List<string> errors)
        {
            foreach (var i in errors)
            {
                modelstate.AddModelError("", i);
            }
        }
    }
}
