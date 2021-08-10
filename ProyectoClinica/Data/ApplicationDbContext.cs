using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProyectoClinica.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoClinica.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Login> Logins { get; set; }
        public DbSet<UserType> UserTypes { get; set; }
    }
}
