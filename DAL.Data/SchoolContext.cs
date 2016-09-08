namespace DAL.Data
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class SchoolContext : DbContext
    {
        public SchoolContext()
            : base("name=SchoolContext")
        {
        }

        public virtual DbSet<Course> Course { get; set; }
        public virtual DbSet<Department> Department { get; set; }
        public virtual DbSet<Enrollment> Enrollment { get; set; }
        public virtual DbSet<OfficeAssignment> OfficeAssignment { get; set; }
        public virtual DbSet<Person> Person { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>()
                .HasMany(e => e.Person)
                .WithMany(e => e.Course)
                .Map(m => m.ToTable("CourseInstructor").MapLeftKey("CourseID").MapRightKey("PersonID"));

            modelBuilder.Entity<Department>()
                .Property(e => e.Budget)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Department>()
                .Property(e => e.RowVersion)
                .IsFixedLength();

            modelBuilder.Entity<Person>()
                .HasOptional(e => e.OfficeAssignment)
                .WithRequired(e => e.Person);
        }

        public void SaveChanges()
        {
            base.SaveChanges();
        }

        public void Dispose()
        {
            base.Dispose();
        }
    }
}
