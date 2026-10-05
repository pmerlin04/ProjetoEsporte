using ProjetoEsporte.Configuration;
using ProjetoEsporte.Repositories;
using ProjetoEsporte.Repositories.Impl;
using ProjetoEsporte.Services;
using ProjetoEsporte.Services.Implementations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

//configuração do Swagger ou Scalar
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddOpenAPIConfig();
builder.Services.AddSwaggerConfig();


builder.Services.AddDatabaseConfiguration(builder.Configuration);

builder.Services.AddEvolveConfiguration(builder.Configuration, builder.Environment);//migrations


builder.Services.AddScoped<IQuadrasServices, QuadrasServicesImpl>();
builder.Services.AddScoped<IUsuariosServices, UsuariosServicesImpl>();
builder.Services.AddScoped<IAgendamentosServices, AgendamentosServiceImpl>();


builder.Services.AddScoped<IQuadrasRepository, QuadrasRepository>();
builder.Services.AddScoped<IUsuariosRepository, UsuariosRepository>();
builder.Services.AddScoped<IAgendamentosRepository, AgendamentosRepository>();

builder.Services.AddHostedService<LiberarAgendamento>();

builder.Services.AddCors();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseCors(options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

app.UseAuthorization();

app.MapControllers();

app.UseSwaggerSpecification();

app.Run();
