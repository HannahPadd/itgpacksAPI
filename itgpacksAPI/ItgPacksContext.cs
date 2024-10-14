using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using itgpacksAPI.Models;

namespace itgpacksAPI
{
    public class ItgPacksContext : DbContext
    {

        public ItgPacksContext()
        {
        }

        public ItgPacksContext(DbContextOptions<ItgPacksContext> options) : base(options) 
        { 
        }

        public DbSet<itgpacksAPI.Models.ItgPackModel> ItgPackModel { get; set; }
    }
}
