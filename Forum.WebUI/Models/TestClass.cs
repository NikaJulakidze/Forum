using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Forum.WebUI.Models
{
    public class TestClass
    {
        [BindProperty]
        public string ReturnUrl { get; set; }
    }
}
