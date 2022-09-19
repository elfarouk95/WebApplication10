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
        //    optionsBuilder.UseSqlServer(@"Server = DESKTOP-60PFG0M\MSSQLSERVER01;
        //    Database = SchoolDb6;
        //    trusted_connection = true;");

              optionsBuilder.UseSqlServer(@"
                              Data Source=SQL8002.site4now.net;
                              Initial Catalog=db_a8d156_asd001;
                              User Id=db_a8d156_asd001_admin;
                              Password=A@12345678");


        }
    }
}
