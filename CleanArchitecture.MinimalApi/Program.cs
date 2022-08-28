using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Domain.Models;
using CleanArchitecture.Infraestructure.Data.Context;
using CleanArchitecture.Infraestructure.IoC;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
string myAllowSpecificOrigins = "_ myAllowSpecificOrigins";
var provider=builder.Services.BuildServiceProvider();
var configuration=provider.GetRequiredService<IConfiguration>();
builder.Services.AddDbContext<BDEmpresaContext>(opt => opt.UseSqlServer(configuration.GetConnectionString("ConnectionSqlServer")));
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: myAllowSpecificOrigins, builder =>
    {
        builder.WithOrigins(configuration.GetValue<string>("APP_URL_ANGULAR")).AllowAnyHeader().AllowAnyMethod().AllowCredentials();
    });
});
// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
DependencyContainer.RegisterServices(builder.Services);
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors(myAllowSpecificOrigins);
app.UseHttpsRedirection();

app.MapGet("/Product/List", async (IUnitOfWork unitOfWork) =>
{
    try
    {
        List<Producto> result = await unitOfWork.productServices.GetProducts();
        if (result.Count == 0) return Results.NotFound();

        return Results.Ok(result);
    }
    catch (Exception ex)
    {
        return Results.BadRequest(ex.Message);
    }
});

app.MapGet("/Product/{id}", async (int id, IUnitOfWork unitOfWork) =>
{
    try
    {
        Producto result = await unitOfWork.productServices.GetProductById(id);
        if (result==null) return Results.NotFound();

        return Results.Ok(result);
    }
    catch (Exception ex)
    {
        return Results.BadRequest(ex.Message);
    }
});

app.MapPost("/Product/Save", async (Producto product, IUnitOfWork unitOfWork) =>
{
    string resp =string.Empty;
    try
    {
        int result = await unitOfWork.productServices.InsetProduct(product);
        if (result == 0) return Results.BadRequest();
        resp = result == 1 ? "0000" : "1111";
        return Results.Ok(new {resultado= resp,Descripcion="Transaccion Exitosa" });
    }
    catch (Exception ex)
    {
        return Results.BadRequest(new { resultado = resp, Descripcion = "Error  al procesar la transaccion:"+ex.Message });
    }
});

app.MapPut("/Product/Update", async (Producto product, IUnitOfWork unitOfWork) =>
{
    try
    {
        bool result = await unitOfWork.productServices.UpdateProduct(product);
        if (result == false) return Results.BadRequest();

        return Results.Ok(result);
    }
    catch (Exception ex)
    {
        return Results.BadRequest(ex.Message);
    }
});

app.MapDelete("/Product/Delete/{id}", async (int id, IUnitOfWork unitOfWork) =>
{
    try
    {
        bool result = await unitOfWork.productServices.DeleteProduct(id);
        if (result == false) return Results.BadRequest();

        return Results.Ok(result);
    }
    catch (Exception ex)
    {
        return Results.BadRequest(ex.Message);
    }
});
app.Run();

