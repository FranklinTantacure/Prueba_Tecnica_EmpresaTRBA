using BusinesLayer_CapaNegocio_;
using DataBaseLayer_CapaDatos_;
using DataBaseLayer_CapaDatos_.BD;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<PEU_BL>();
builder.Services.AddScoped<Database_DL>();

builder.Services.AddScoped<Cadena>();



var app = builder.Build();


// Middleware de registro de errores
app.Use(async (context, next) =>
{
    try
    {
        await next();
    }
    catch (Exception ex)
    {
        var zommdleDL = context.RequestServices.GetRequiredService<Database_DL>();
        await zommdleDL.RegistrarErrorAsync(ex.GetType().Name, ex.Message, ex.StackTrace);

        throw;
    }
});




// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
