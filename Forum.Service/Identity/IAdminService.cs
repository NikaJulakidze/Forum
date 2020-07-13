﻿using Forum.Models;
using Forum.Models.Tag;
using System.Threading.Tasks;

namespace Forum.Service.Identity
{
    public interface IAdminService
    {
        Task<Result> CreateRoleAsync(string name);
        Task<Result<AddTagModel>> CreateTagAsync(AddTagModel tagModel);
    }
}
