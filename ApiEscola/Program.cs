using ApiEscola.Data.Context;
using ApiEscola.Interfaces.Repositorio;
using ApiEscola.Interfaces.Servicos;
using ApiEscola.Repositorio;
using ApiEscola.Repositorio.ApiEscola.Repositorio;
using ApiEscola.Servicos;
using Microsoft.EntityFrameworkCore;

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
    builder.Services.AddScoped<IRepositorioTurma, RepositorioTurmaBanco>();
}
else
{
    builder.Services.AddSingleton(typeof(IRepositorio<>), typeof(RepositorioLocal<>));
    builder.Services.AddSingleton<IRepositorioTurma, RepositorioTurmaLocal>();
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
