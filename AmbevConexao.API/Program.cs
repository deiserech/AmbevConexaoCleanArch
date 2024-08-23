using AmbevConexao.API.Filters;
using AmbevConexao.API.Mid;
using AmbevConexao.Domain.Aluno;
using AmbevConexao.Domain.Common;
using AmbevConexao.Domain.Professor;
using AmbevConexao.Domain.TurmaAluno;
using AmbevConexao.Infraestructure.Aluno;
using AmbevConexao.Infraestructure.Common;
using AmbevConexao.Infraestructure.Professor;
using AmbevConexao.Infraestructure.TurmaAluno;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(options =>
{
    options.Filters.Add<CustomAuthorizationFilter>();
    options.Filters.Add<CustomExceptionsFilter>();
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
builder.Services.AddScoped<IAlunoRepository, AlunoRepository>();
builder.Services.AddScoped<IProfessorRepository, ProfessorRepository>();
builder.Services.AddScoped<ITurmaAlunoRepository, TurmaAlunoRepository>();

builder.Services.AddDbContext<Contexto>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.Use(async (context, next) =>
//{
//    Console.WriteLine(context.Request.Path + "Entrando mid1");

//    await next.Invoke();

//    Console.WriteLine(context.Request.Path + "Saindo mid1");
//});

//app.Use(async (context, next) =>
//{
//    Console.WriteLine(context.Request.Path + "Entrando mid2");

//    await next.Invoke();
    
//    Console.WriteLine(context.Request.Path + "Saindo mid2");
//});

app.UseMiddleware<HeadersMiddleware>();

app.UseAuthorization();

app.MapControllers();

//app.Run(async context =>
//{
//    Console.WriteLine(context.Request.Path + "Entrando mid3");

//    await context.Response.WriteAsync("Hello from mid 3");

//    Console.WriteLine(context.Request.Path + "Saindo mid3");
//});

//app.Run(async context =>
//{
//    Console.WriteLine(context.Request.Path + "Entrando mid4");

//    await context.Response.WriteAsync("Hello from mid4");

//    Console.WriteLine(context.Request.Path + "Saindo mid4");
//});

app.Run();
