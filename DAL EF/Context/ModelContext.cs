namespace DAL
{
    using DAL.Entitys;
    using DAL.Interfaces;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class DBContext : DbContext, IContext
    {
        public DBContext()
        {

        }
        public DBContext(string connectionString)
            : base(connectionString)
        {
        }

        public DbSet<Answer> Answers { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Test> Tests  { get; set; }
    }
}