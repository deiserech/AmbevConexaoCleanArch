using AmbevConexao.Application.UseCases;
using AmbevConexao.Domain.Aluno;
using AmbevConexao.Domain.Common;
using AmbevConexao.Domain.Curso;
using AmbevConexao.Domain.Matricula;
using AmbevConexao.Domain.Professor;
using AmbevConexao.Infraestructure.Aluno;
using AmbevConexao.Infraestructure.Common;
using AmbevConexao.Infraestructure.Curso;
using AmbevConexao.Infraestructure.Matricula;
using AmbevConexao.Infraestructure.Professor;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(ApplicationAssemblyReference).Assembly));

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
builder.Services.AddScoped<IAlunoRepository, AlunoRepository>();
builder.Services.AddScoped<IProfessorRepository, ProfessorRepository>();
builder.Services.AddScoped<ICursoRepository, CursoRepository>();
builder.Services.AddScoped<IMatriculaRepository, MatriculaRepository>();

builder.Services.AddDbContext<Contexto>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer")));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

app.Run();
