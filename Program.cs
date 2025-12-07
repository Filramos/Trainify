using Trainify.Interfaces;       // <--- IMPORTANTE: Adicionar isto
using Trainify.Implementations;  // <--- IMPORTANTE: Adicionar isto

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// =================================================================
// ADICIONE ESTA LINHA AQUI:
// =================================================================
builder.Services.AddSingleton<IParameterFactory, ConfigurableParameterFactory>();
// =================================================================

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();