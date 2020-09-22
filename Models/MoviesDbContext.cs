using System;
using Microsoft.EntityFrameworkCore;
public class MoviesDbContext: DbContext  {
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){
        optionsBuilder.UseSqlServer(@"Data source=JUAN-GAMER; Initial Catalog=Movies;Integrated Security=true");
    }

    public DbSet<Movie> Movies { get; set; }
    public DbSet<Category> Categories { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Movie>()
            .HasOne(p => p.Category)
            .WithMany(b => b.Movies)
            .IsRequired()
            .OnDelete(DeleteBehavior.Restrict)
            .HasForeignKey(p => p.IdCategory);


    
    }
}