using MaklerSamxal.WebUI.Models.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MaklerSamxal.WebUI.Models.DataContexts
{
    public class MaklerSamxalDbContext : DbContext
    {
        public MaklerSamxalDbContext(DbContextOptions options)
            :base(options)
        {
            
        }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Testimionals> Testimionalss { get; set; }
        public DbSet<Agent> Agents { get; set; }

        public DbSet<Product> Products { get; set; }
    }

    
}
