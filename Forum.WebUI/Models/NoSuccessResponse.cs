using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Forum.WebUI.Models
{
    public class NoSuccessResponse
    {
        public List<string> Errors { get; set; }
    }
}
