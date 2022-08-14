using Microsoft.AspNetCore.Mvc;
using MinimalApi;

var builder = WebApplication.CreateBuilder(args);
var provider=builder.Services.BuildServiceProvider();
var configuration=provider.GetRequiredService<IConfiguration>();
// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/api/ListPrueba/{id}", (int id) =>
{
    List<Product> listProduct = new();
    Product product = new()
    {
        Name = "Oreo" + id.ToString(),
        TypeProduct = "Galleta",
        Price = 1
    };

    Product product1 = new()
    {
        Name = "Coca cola",
    TypeProduct = "Gaseosa",
    Price = 5
    };

    Product product2 = new()
    {
        Name = "Fanta",
        TypeProduct = "Gaseosa",
        Price = 6
    };

    listProduct.Add(product);
    listProduct.Add(product1);
    listProduct.Add(product2);
    return Results.Ok(listProduct);
});

app.MapPost("/Save", ([FromBody] Product product)  =>
{
   
    return Results.Ok(product);
});

app.MapPut("/Update", ([FromBody] Product? product) =>
{
    if(product==null)
    {
        return Results.NotFound();
    }
    return Results.Ok(product);
});

app.MapDelete("/Product/Delete/{id}", (int id) =>
{
    if (id == 0)
    {
        return Results.BadRequest();
    }
    return Results.Ok(id);
});
app.MapMethods("/products", new[] { "PATCH" }, (Product? product) =>
{
      if(product==null)
    {
        return Results.BadRequest();
    }
    return Results.Ok(product);
});
app.Run();