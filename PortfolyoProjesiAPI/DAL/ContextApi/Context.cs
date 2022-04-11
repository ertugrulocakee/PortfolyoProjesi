using Microsoft.EntityFrameworkCore;
using PortfolioProjectAPI.DAL.Entity;

namespace PortfolioProjectAPI.DAL.ContextApi
{
    public class Context : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer("server=DESKTOP-I1ODVGB;database=Portfolio2;integrated security=true");

        }


        public DbSet<Category> Categories { get; set; } 


    }
}
