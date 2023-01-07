using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace CarControl
{
    class AppContext : DbContext
    {
        public DbSet<Car> Cars { get; set; }
        public AppContext() : base("DefaultConnection") { }
    }
}
