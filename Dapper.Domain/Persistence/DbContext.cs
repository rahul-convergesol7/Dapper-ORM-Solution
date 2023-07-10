using Dapper.ORM;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dapper.Domain.Persistence
{
    public class DbContext : DapperContext
    {
        public DbContext(IConfiguration config) : base(config.GetConnectionString("MyConnection")) { }
    }
}
