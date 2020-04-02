using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace ibuyWeb.Model
{
    public class userDetailContext:DbContext
    {

        public userDetailContext(DbContextOptions<userDetailContext> options)
            : base(options)
        {
        }

        public DbSet<userDetail> userDetail { get; set; }
    }
}
