using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using static CRUD_DAL.Models.Persons;

namespace CRUD_DAL.Data
{
    public class ApplicationDbContext : DbContext
    {

       public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        //    public ApplicationDbContext(string DefaultConnection): base(DefaultConnection)
        //public ApplicationDbContext(DbContextOptions<ApplicationDbContext> DefaultConnection) : base(DefaultConnection)
        //public ApplicationDbContext() : base("DefaultConnection")

        { 
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
        public DbSet<Person> Persons { get; set; }
    }
}
