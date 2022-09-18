var builder = WebApplication.CreateBuilder(args);
string myAllowOrigins = "_ myAllowOrigins";
// Add services to the container.
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: myAllowOrigins, builder =>
    {
        builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
});
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Host.ConfigureLogging(o => o.AddAzureWebAppDiagnostics());
var app = builder.Build();

// Configure the HTTP request pipeline.

    app.UseSwagger();
    app.UseSwaggerUI();


app.UseHttpsRedirection();
app.UseCors(myAllowOrigins);
app.UseAuthorization();

app.MapControllers();

app.Run();
