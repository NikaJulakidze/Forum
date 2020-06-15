using Forum.Data.Repository;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text;

namespace Forum.Data.Uow
{
    public class AdminUow:BaseUow,IAdminUow
    {
        public IAdminRepository AdminRepository { get; }

        public AdminUow(ApplicationDbContext context,IAdminRepository adminRepository):base(context)
        {
            AdminRepository= adminRepository;
        }

    }
}
