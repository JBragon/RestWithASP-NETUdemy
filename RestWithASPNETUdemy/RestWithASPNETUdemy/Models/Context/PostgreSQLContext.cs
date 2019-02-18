using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestWithASPNETUdemy.Models.Context
{
    public class PostgreSQLContext : DbContext
    {
        public PostgreSQLContext()
        {

        }

        public PostgreSQLContext(DbContextOptions<PostgreSQLContext> options) : base(options) {}

        public DbSet<Person> Persons { get; set; }
    }
}
