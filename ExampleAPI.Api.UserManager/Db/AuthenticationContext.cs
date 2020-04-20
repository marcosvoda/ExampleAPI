using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExampleAPI.Api.UserManager.Db
{
    public class AuthenticationContext : DbContext
    {
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

        public AuthenticationContext(DbContextOptions options) : base(options)
        {

        }
    }
}
