using CleanArchitecture.Application.Constants;
using CleanArchitecture.Application.Enum;
using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Domain.Models;
using CleanArchitecture.Infraestructure.Data.Context;
using CleanArchitecture.Infraestructure.IoC;
using CleanArchitecture.MinimalApi;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Text.Json;

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
builder.Services.AddAuthorization();
builder.Services.AddTokenAuthentication(configuration);
// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "MyProject", Version = "v1.0.0" });

    var securitySchema = new OpenApiSecurityScheme
    {
        Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        Reference = new OpenApiReference
        {
            Type = ReferenceType.SecurityScheme,
            Id = "Bearer"
        }
    };

    c.AddSecurityDefinition("Bearer", securitySchema);

    var securityRequirement = new OpenApiSecurityRequirement
                {
                    { securitySchema, new[] { "Bearer" } }
                };

    c.AddSecurityRequirement(securityRequirement);
});
DependencyContainer.RegisterServices(builder.Services);
builder.Host.ConfigureLogging(o => o.AddAzureWebAppDiagnostics());

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();
    app.UseSwaggerUI();
//}
app.UseCors(myAllowSpecificOrigins);
app.UseAuthentication();
app.UseAuthorization();
app.UseHttpsRedirection();

app.MapPost("Security/ValidateUser", [AllowAnonymous] async (Usuario usuario,IUnitOfWork unitOfWork) =>
{
    try
    {
        ITokenService tokenService = new TokenService(configuration);
        if (usuario == null) Results.BadRequest();
        var credencial = await unitOfWork.usuarioServices.ValidateUser(usuario);
      //  logger.LogInformation("Este es el usuario validado"+credencial.Nombre);
        if (credencial != null)
        {
            var Token = tokenService.BuildToken(usuario);
            usuario.Token = Token;
            return Results.Ok(usuario);
        }
        else
        {
            return Results.NotFound();
        }
    }
    catch (Exception ex)
    { 
        return Results.BadRequest(ex.Message);
    }
   
});

app.MapGet("/Product/List", [Authorize]  async (IUnitOfWork unitOfWork) =>
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

app.MapGet("/Product/{id}", [Authorize] async (int id, IUnitOfWork unitOfWork) =>
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

app.MapPost("/Product/Save", [Authorize]  async (Producto product, IUnitOfWork unitOfWork) =>
{
    string resp = string.Empty;
    RespuestaTransaccionDto respuestaTransaccionDto = new();
    try
    {
         unitOfWork.productServices.InsertProduct(product);
        int result = await unitOfWork.CommitAsync();
        if (result == 0) return Results.BadRequest();
        respuestaTransaccionDto.Resultado = CodeResponse.GetCode(result);
        respuestaTransaccionDto.Descripcion = Mensajes.TRANSACCION_EXITOSA;
        return Results.Ok(respuestaTransaccionDto);
    }
    catch (Exception ex)
    {
        respuestaTransaccionDto.Resultado = Mensajes.CODIGO_ERROR;
        respuestaTransaccionDto.Descripcion = Mensajes.ERROR_TRANSACCION + ex.Message;
        return Results.BadRequest(respuestaTransaccionDto);
    }
});

app.MapPut("/Product/Update", [Authorize]  async (Producto product, IUnitOfWork unitOfWork) =>
{
    RespuestaTransaccionDto respuestaTransaccionDto = new();
    try
    {
         unitOfWork.productServices.UpdateProduct(product);
        int result = await unitOfWork.CommitAsync();
        if (result == 0) return Results.BadRequest();
        respuestaTransaccionDto.Resultado = CodeResponse.GetCode(result);
        respuestaTransaccionDto.Descripcion = Mensajes.TRANSACCION_EXITOSA;
        return Results.Ok(respuestaTransaccionDto);
    }
    catch (Exception ex)
    {
        respuestaTransaccionDto.Resultado = Mensajes.CODIGO_ERROR;
        respuestaTransaccionDto.Descripcion = Mensajes.ERROR_TRANSACCION + ex.Message;
        return Results.BadRequest(respuestaTransaccionDto);
    }
});

app.MapDelete("/Product/Delete/{id}", [Authorize] async (int id, IUnitOfWork unitOfWork) =>
{
    RespuestaTransaccionDto respuestaTransaccionDto = new();
    try
    {
         unitOfWork.productServices.DeleteProduct(id);
        int result = await unitOfWork.CommitAsync();
        if (result == 0) return Results.BadRequest();
        respuestaTransaccionDto.Resultado = CodeResponse.GetCode(result);
        respuestaTransaccionDto.Descripcion = Mensajes.TRANSACCION_EXITOSA;
        return Results.Ok(respuestaTransaccionDto);
    }
    catch (Exception ex)
    {
        respuestaTransaccionDto.Resultado = Mensajes.CODIGO_ERROR;
        respuestaTransaccionDto.Descripcion = Mensajes.ERROR_TRANSACCION + ex.Message;
        return Results.BadRequest(respuestaTransaccionDto);
    }
});

app.MapPost("/Compra/Save", [Authorize] async (Compra compra,IUnitOfWork unitOfWork) =>
{
    string resp = string.Empty;
    RespuestaTransaccionDto respuestaTransaccionDto = new();
    try
    {
        unitOfWork.compraServices.Insert(compra);
        int result = await unitOfWork.CommitAsync();
        if (result==0) return Results.BadRequest();
        respuestaTransaccionDto.Resultado = CodeResponse.GetCode(result);
        respuestaTransaccionDto.Descripcion = Mensajes.TRANSACCION_EXITOSA;
        return Results.Ok(respuestaTransaccionDto);
    }
    catch (Exception ex)
    {
        respuestaTransaccionDto.Resultado = Mensajes.CODIGO_ERROR;
        respuestaTransaccionDto.Descripcion = Mensajes.ERROR_TRANSACCION + ex.Message;
        return Results.BadRequest(respuestaTransaccionDto);
    }
});

app.MapPut("/Compra/Update", [Authorize] async (CompraDto compraDto, IUnitOfWork unitOfWork) =>
{
    string resp = string.Empty;
    RespuestaTransaccionDto respuestaTransaccionDto = new();
    using var scope = unitOfWork.BeginTransaction();
    try
    {
        Compra compra = JsonSerializer.Deserialize <Compra>(JsonSerializer.Serialize(compraDto));
        unitOfWork.compraServices.Update(compra);

        foreach(var element in compra.DetalleCompras)
        {
            DetalleCompra compraDetalle = await unitOfWork.detalleCompraServices.GetById(element.Id);
            unitOfWork.detalleCompraServices.Update(compraDetalle);
        }
        int result = await unitOfWork.CommitAsync();
        scope.Commit();
        if (result == 0) return Results.BadRequest();
        respuestaTransaccionDto.Resultado = CodeResponse.GetCode(result);
        respuestaTransaccionDto.Descripcion = Mensajes.TRANSACCION_EXITOSA;
        return Results.Ok(respuestaTransaccionDto);
    }
    catch (Exception ex)
    {
        respuestaTransaccionDto.Resultado = Mensajes.CODIGO_ERROR;
        respuestaTransaccionDto.Descripcion = Mensajes.ERROR_TRANSACCION + ex.Message;
        scope.Rollback();
        return Results.BadRequest(respuestaTransaccionDto);
    }
});
app.Run();

