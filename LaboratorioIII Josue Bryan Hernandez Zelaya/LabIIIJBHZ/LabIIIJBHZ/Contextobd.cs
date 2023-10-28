using Microsoft.EntityFrameworkCore;

public class AsigContext : DbContext
{
    public DbSet<Asignatura> asignaturas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=LAPTOP-1I3C54GG\\SQLEXPRESS;Database=lab3;Trusted_Connection=SSPI;MultipleActiveResultSets=true;TrustServerCertificate=true;");
    }
}