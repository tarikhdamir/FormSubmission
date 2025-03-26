using Microsoft.EntityFrameworkCore;

public class FormDbContext : DbContext
{
    public DbSet<FormSubmissionClass> Submissions { get; set; }

    public FormDbContext(DbContextOptions<FormDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<FormSubmissionClass>()
            .ToTable("Submissions") // ✅ Ensure the table name is explicitly mapped
            .Property(f => f.FormDataJson)
            .HasColumnName("FormData");

        modelBuilder.Entity<FormSubmissionClass>()
            .Ignore(f => f.FormData);
    }
}
