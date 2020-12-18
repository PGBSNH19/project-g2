using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KNet.API.Context
{
    public class DbInitializer
    {
        public void Initialize(AppDbContext context)
        {
            context.Database.EnsureCreated();

            if (true)
            {

            }
        }
    }
}
