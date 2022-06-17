using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace userGRPC.GRPCDB
{
    public class GRPCDBContext:DbContext
    {
        public GRPCDBContext(DbContextOptions<GRPCDBContext> Options):base(Options)
        {

        }
        public DbSet<User> Users { get; set; }

    }
}
