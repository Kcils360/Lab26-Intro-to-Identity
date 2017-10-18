using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Lab28LoginAuth.Models
{
    public class Lab28LoginAuthContext : DbContext
    {
        public Lab28LoginAuthContext (DbContextOptions<Lab28LoginAuthContext> options)
            : base(options)
        {
        }

        public DbSet<Lab28LoginAuth.Models.RecipeModel> RecipeModel { get; set; }
    }
}
