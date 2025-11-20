using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace infrastructure;

public class SampleContextfactory: IDesignTimeDbContextFactory<ApplicationContext>
{
    public ApplicationContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();
        ConfigurationBuilder builder = new ConfigurationBuilder();
        builder.SetBasePath(Directory.GetCurrentDirectory());
        builder.AddJsonFile("appsettings.json");
        IConfigurationRoot config = builder.Build();
        
        optionsBuilder.UseNpgsql(config.GetConnectionString("DefaultConnection"));
        return new ApplicationContext(optionsBuilder.Options);
    }
}