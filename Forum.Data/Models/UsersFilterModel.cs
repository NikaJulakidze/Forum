using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Forum.Data.Models
{
    public class UsersFilterModel
    {
        public string SearchString { get; set; }
        public string Role { get; set; }


        public static bool HaveFilter(UsersFilterModel filter)
        {
            var a= filter.GetType().GetProperty("SearchString").GetValue(filter, null);
            filter.Role = "1";
            var properties = filter.GetType().GetProperties();
            foreach(var i in properties)
            {
                
            }
            return false;
        }
        
    }
}
