using Microsoft.EntityFrameworkCore;

{
    // Just run Add-Migration twice and the second migration will add an unnecessary DropForeignKey and AddForeignKey
    // Also it will try to recreate columns and Indexes that are already existing - that is endlessly
}

public class AppDbContext : DbContext
{
    public DbSet<FooBase> FooBases => Set<FooBase>();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.UseSqlServer();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<BarBase>().UseTphMappingStrategy()
            .HasDiscriminator<string>("type")
            .HasValue<BarA>("BarA")
            .HasValue<BarB>("BarB");

        var barA = modelBuilder.Entity<BarA>();
        barA.HasBaseType<BarBase>();
        
        var barB = modelBuilder.Entity<BarB>();
        barB.HasBaseType<BarBase>();

        // FooExtension config
        modelBuilder.Entity<FooBase>().UseTphMappingStrategy()
            .HasDiscriminator<string>("type")
            .HasValue<FooExtension<BarA>>("BarAFooExtension")
            .HasValue<FooExtension<BarB>>("BarBFooExtension");

        var fooA = modelBuilder.Entity<FooExtension<BarA>>();
        fooA.HasBaseType<FooBase>();
        fooA.HasOne(x => x.Bar).WithOne().HasForeignKey<BarA>();
        
        var fooB = modelBuilder.Entity<FooExtension<BarB>>();
        fooB.HasBaseType<FooBase>();
        fooB.HasOne(x => x.Bar).WithOne().HasForeignKey<BarB>();
    }
}

public abstract class BarBase
{
    public int Id { get; set; }
}

public class BarA : BarBase
{
    public string? A { get; set; }
}

public class BarB : BarBase
{
    public bool B { get; set; }
}

public abstract class FooBase
{
    public int Id { get; set; }
}

public class FooExtension<T> : FooBase where T : BarBase
{
    public T? Bar { get; set; }
}
