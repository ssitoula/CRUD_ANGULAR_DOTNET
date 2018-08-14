using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace CRUD_Angular_Asp.Table
{
    public class DataContext :DbContext
    {
        public DataContext() : base("name=DefaultConnection")
        {

        }

        public DbSet<Student> Students { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}