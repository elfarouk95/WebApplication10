using Microsoft.EntityFrameworkCore;

namespace WebApplication10.Model
{
    public class SchoolContext : DbContext
    {
        public DbSet<Student> Students { get;set; }

        public DbSet<Subject> Subjects { get; set; }

        public  DbSet<RegForm> RegForms { get; set; }

        public DbSet <RegFormItem> RegFormItems { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server = DESKTOP-60PFG0M\MSSQLSERVER01;
Database = SchoolDb6;
trusted_connection = true;");
        }
    }
}
