using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Domain.Models;
using CleanArchitecture.Infraestructure.Data.Context;
using CleanArchitecture.Infraestructure.IoC;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var provider=builder.Services.BuildServiceProvider();
var configuration=provider.GetRequiredService<IConfiguration>();
builder.Services.AddDbContext<BDEmpresaContext>(opt => opt.UseSqlServer(configuration.GetConnectionString("ConnectionSqlServer")));
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

app.UseHttpsRedirection();

app.MapGet("/Product/List", async (IProductServices _productService) =>
{
    try
    {
        List<Producto> result = await _productService.GetProducts();
        if (result.Count == 0) return Results.NotFound();

        return Results.Ok(result);
    }
    catch (Exception ex)
    {
        return Results.BadRequest(ex.Message);
    }
});

app.MapGet("/Product/{id}", async (int id,IProductServices _productService) =>
{
    try
    {
        Producto result = await _productService.GetProductById(id);
        if (result==null) return Results.NotFound();

        return Results.Ok(result);
    }
    catch (Exception ex)
    {
        return Results.BadRequest(ex.Message);
    }
});

app.MapPost("/Product/Save", async (Producto product, IProductServices _productService) =>
{
    string resp =string.Empty;
    try
    {
        int result = await _productService.InsetProduct(product);
        if (result == 0) return Results.BadRequest();
        resp = result == 1 ? "0000" : "1111";
        return Results.Ok(new {resultado= resp,Descripcion="Transaccion Exitosa" });
    }
    catch (Exception ex)
    {
        return Results.BadRequest(new { resultado = resp, Descripcion = "Error  al procesar la transaccion:"+ex.Message });
    }
});

app.MapPut("/Product/Update", async (Producto product, IProductServices _productService) =>
{
    try
    {
        bool result = await _productService.UpdateProduct(product);
        if (result == false) return Results.BadRequest();

        return Results.Ok(result);
    }
    catch (Exception ex)
    {
        return Results.BadRequest(ex.Message);
    }
});

app.MapDelete("/Product/Delete/{id}", async (int id, IProductServices _productService) =>
{
    try
    {
        bool result = await _productService.DeleteProduct(id);
        if (result == false) return Results.BadRequest();

        return Results.Ok(result);
    }
    catch (Exception ex)
    {
        return Results.BadRequest(ex.Message);
    }
});
app.Run();

