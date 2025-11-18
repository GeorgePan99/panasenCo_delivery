using infrastructure;


var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddServices();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");


app.MapControllers();
app.UseAuthentication();
app.Run();