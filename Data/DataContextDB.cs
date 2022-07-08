using Microsoft.EntityFrameworkCore;
using TalentGoWebAPI.Models;

namespace TalentGoWebAPI.Data
{
    public class DataContextDB : DbContext 
    {
        //pass in the options to base class which is (dbcontext)
        public DataContextDB(DbContextOptions<DataContextDB> options) : base(options)
        {

        }
        public DbSet<Talents> Talents { get; set; }
    }
}
