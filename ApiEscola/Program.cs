using ApiEscola.Interfaces.Repositorio;
using ApiEscola.Repositorio;
using ApiEscola.Interfaces.Servicos;
using ApiEscola.Servicos;
using Microsoft.EntityFrameworkCore;
using ApiEscola.Data.Context;

var builder = WebApplication.CreateBuilder(args);

// Controllers
builder.Services.AddControllers();

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Injeção de Dependência
builder.Services.AddTransient<IServicoAluno, ServicoAluno>();
builder.Services.AddTransient<IServicoTurma, ServicoTurma>();
builder.Services.AddTransient<ServicoTurma>();

bool usarBanco = builder.Configuration.GetValue<bool>("RepositorioBanco");

string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<EscolaContext>(options =>
    options.UseSqlServer(connectionString));

if (usarBanco)
{
    builder.Services.AddScoped(typeof(IRepositorio<>), typeof(RepositorioBanco<>));
}
else
{
    builder.Services.AddSingleton(typeof(IRepositorio<>), typeof(RepositorioLocal<>));
}

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
