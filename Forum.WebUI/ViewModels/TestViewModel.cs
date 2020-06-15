using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Forum.WebUI.ViewModels
{
    public class TestViewModel
    {
        [DataType(DataType.ImageUrl)]
        public string ImageUrl { get; set; }
    }
}
