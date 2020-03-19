using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace ibuyWeb.Model
{
    public class userinforContent:DbContext
    {

        public userinforContent(DbContextOptions<userinforContent> options)
            : base(options)
        {
        }

        public DbSet<userinfor> userinfor { get; set; }
    }
}
