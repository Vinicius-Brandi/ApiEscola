using ApiEscola.Interfaces.Repositorio;
using ApiEscola.Repositorio;
using ApiEscola.Interfaces.Servicos;
using ApiEscola.Servicos;

var builder = WebApplication.CreateBuilder(args);

// Controllers
builder.Services.AddControllers();

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Injeção de Dependência
builder.Services.AddSingleton(typeof(IRepositorioLocal<>), typeof(RepositorioLocal<>));
builder.Services.AddScoped<IServicoAluno, ServicoAluno>();

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
