using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ibuyWeb.Model
{
    public class iteminforContent:DbContext
    {


        public iteminforContent(DbContextOptions<iteminforContent> options)
           : base(options)
        {
        }

        public DbSet<iteminfor> iteminfor { get; set; }
    }
}
