using Forum.Data.Entities;
using Forum.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Forum.Data.Repository
{
    public class AdminRepository:IAdminRepository
    {
        private readonly ApplicationDbContext _context;

        public AdminRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void CreateTag(Tag tag)
        {
            _context.Add(tag);
        }
        
        public void EditTag(Tag tag)
        {
            _context.Update(tag);
        }
        public void DeleteTag(Tag tag)
        {
            _context.Remove(tag); 
        }

    }
}
