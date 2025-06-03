using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(
    c =>
    {
        c.SwaggerDoc("v1", new OpenApiInfo
        {
            Title = "Swagger - Sorteador de times",
            Description = "API utilizada para realizar sorteio e balanceamento de times com base na posição e no nível de habilidade de cada jogador",
            Contact = new OpenApiContact() { Name = "Augusto Lima Jardim", Email = "augustolimajardim@gmail.com" },
            License = new OpenApiLicense() { Name = "MIT License", Url = new Uri("https://opensource.org/licenses/MIT") }
        });
        c.IncludeXmlComments(Path.Combine(System.AppContext.BaseDirectory, "SorteadorDeTimesAnnotation.xml"));
    }
);

var app = builder.Build();

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
