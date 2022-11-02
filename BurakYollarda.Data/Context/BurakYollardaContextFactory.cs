using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurakYollarda.Data.Context
{
    public class BurakYollardaContextFactory : IDesignTimeDbContextFactory<BurakYollardaContext>
    {
        public BurakYollardaContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<BurakYollardaContext>();
            optionsBuilder.UseSqlServer("server=DESKTOP-PKCEVA5; database=BurakYollarda; Trusted_Connection=true");

            return new BurakYollardaContext(optionsBuilder.Options);
        }
    }
    

    
}
