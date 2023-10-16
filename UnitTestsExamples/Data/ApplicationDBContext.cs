using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestsExamples.Data
{
    public class ApplicationDBContext : DbContext
    {
        private const string connectionString = "Server=SUMAYA;Database=UnitTestsExample;User Id=sa;Password=sa;Trusted_Connection=True;Trusted_Connection=SSPI;Encrypt=false;";
        private bool inMemoryDB = false;
        public ApplicationDBContext() { 
        
        }
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options,bool inMemoryDB) : base(options)
        {
            this.inMemoryDB = inMemoryDB;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(!inMemoryDB)
            {
                optionsBuilder.UseSqlServer(connectionString); // this line so we can write on sql server DB in program.cs
                // but it prevents InMemory DB (for unit tests) from working !! so we are going to make a workaround :)
            }
        }
        public DbSet<MyObjectDataModel> myObjects { get; set; } //tabel name in DB
    }
}
