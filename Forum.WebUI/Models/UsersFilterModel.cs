using Microsoft.AspNetCore.Mvc;

namespace Forum.WebUI.Models
{
    public class UsersFilterModel
    {
        [BindProperty]
        public string SearchValue { get; set; }
        [BindProperty]
        public string Role { get; set; }
    }
}
