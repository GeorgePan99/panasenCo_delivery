using Microsoft.EntityFrameworkCore;
using infrastructure;
using UseCases;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddUsecasesServices();
builder.Services.AddServices(builder.Configuration);

var config = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<ApplicationContext>(options => options.UseNpgsql(config));

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<ApplicationContext>();
    db.Database.Migrate();
}



app.MapGet("/", () => "Hello World!");


app.MapControllers();
app.UseAuthentication();
app.Run();