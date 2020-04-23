namespace DataModel
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Diagnostics;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;

    public partial class SchoolDBContext : DbContext
    {
        // public static string connectionString = "Server=HASSAN-PC; Database=SchoolDB;Trusted_Connection=True;"; //"data source=HASSAN-PC;initial catalog=SchoolDB;integrated security=True;";

        private const string connectionString = "Server=HASAN-PC;Database=SchoolDB;Trusted_Connection=True;";
        public SchoolDBContext()
           // : base(connectionString)
        {
            //Database.Connection.ConnectionString = connectionString;

         // var x =  Database.GetDbConnection();
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //              => optionsBuilder
        //        .UseLazyLoadingProxies()
        //        .UseSqlServer("Server=HASSAN-PC;Database=SchoolDB;Trusted_Connection=True;");

        public SchoolDBContext(DbContextOptions<SchoolDBContext> options)
            : base(options)
        {
          //  ((IObjectContextAdapter)this).ObjectContext.ObjectMaterialized +=
          //(sender, e) => Subscribe(e.Entity as Node);
        }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
         => optionsBuilder
            .UseSqlServer(connectionString)
            .UseLazyLoadingProxies();
           // .ConfigureWarnings(warn => warn.Ignore(CoreEventId.DetachedLazyLoadingWarning));

            
        


        public virtual DbSet<Course> Course { get; set; }
        public virtual DbSet<School> School { get; set; }
        public virtual DbSet<Student> Student { get; set; }
        public virtual DbSet<Teacher> Teacher { get; set; }
        public virtual DbSet<Department> Department { get; set; }
        public virtual DbSet<Vehicule> Vehicule { get; set; }
        public virtual DbSet<MenuIDHistory> MenuIDHistory { get; set; }
        public virtual DbSet<Student_Course> Student_Course { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<MenuIDHistory>()
               .Property(e => e.ID)
               .HasColumnType("decimal(15, 10)");

            modelBuilder.Entity<Course>()
                .Property(e => e.CourseID)
                .HasColumnType("decimal(15, 10)");

            modelBuilder.Entity<Course>()
                .Property(e => e.CourseName)
                .IsUnicode(false);

            modelBuilder.Entity<Course>()
                .Property(e => e.TeacherID)
                .HasColumnType("decimal(15, 10)");

            //modelBuilder.Entity<Course>()
            //    .HasMany(e => e.Students)
            //    .WithMany(e => e.Courses)
            //    .Map(m => m.ToTable("Student_Course").MapLeftKey("CourseID").MapRightKey("StudentID"));

            modelBuilder.Entity<School>()
                .Property(e => e.SchoolID)
                .HasColumnType("decimal(15, 10)");

            modelBuilder.Entity<School>()
                .Property(e => e.SchoolName)
                .IsUnicode(false);

            modelBuilder.Entity<School>()
                .Property(e => e.Director)
                .IsUnicode(false);

            //modelBuilder.Entity<School>()
            //    .HasKey(x => x.SchoolID);

            //modelBuilder.Entity<School>()
            //    .HasMany(x => x.Teachers)
            //.WithOne(x => x.School)
            //.IsRequired(true)
            //.OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Student>()
                .Property(e => e.StudentID)
                .HasColumnType("decimal(15, 10)");

            modelBuilder.Entity<Student>()
                .Property(e => e.StudentName)
                .IsUnicode(false);

            modelBuilder.Entity<Student>()
               .Property(e => e.SchoolID)
               .HasColumnType("decimal(15, 10)");

            modelBuilder.Entity<Teacher>()
                .Property(e => e.TeacherID)
                .HasColumnType("decimal(15, 10)");

            modelBuilder.Entity<Teacher>()
                .Property(e => e.TeacherName)
                .IsUnicode(false);

            modelBuilder.Entity<Teacher>()
                .Property(e => e.SchoolID)
                .HasColumnType("decimal(15, 10)");


            modelBuilder.Entity<Department>()
                .Property(e => e.DepartmentID)
                .HasColumnType("decimal(15, 10)");

            modelBuilder.Entity<Department>()
               .Property(e => e.SchoolID)
               .HasColumnType("decimal(15, 10)");

            modelBuilder.Entity<Vehicule>()
               .Property(e => e.VehiculeID)
               .HasColumnType("decimal(15, 10)");


            modelBuilder.Entity<Vehicule>()
               .Property(e => e.SchoolID)
               .HasColumnType("decimal(15, 10)");


            modelBuilder.Entity<Student_Course>()
                .HasKey(a => new { a.StudentID, a.CourseID });
        }
    }

    //public interface ISchoolType
    //{

    //}

    public class EntityBase: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
