using Forum.Service.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Service.Identity
{
    public interface IAdminService
    {
        Task<Result> CreateRoleAsync(string role);
    }
}
