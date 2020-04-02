using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ibuyWeb.Model
{
    public class itemDetailContext:DbContext
    {


        public itemDetailContext(DbContextOptions<itemDetailContext> options)
           : base(options)
        {
        }

        public DbSet<itemDetail> itemDetail { get; set; }
    }
}
