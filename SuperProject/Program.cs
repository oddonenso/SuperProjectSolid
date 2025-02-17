using Data;
using Domain;
using Domain.Commands;
using Domain.Dto;
using Service;
using System.Windows.Input;
using Microsoft.EntityFrameworkCore;
using Domain.Query;
using Domain.Querry;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRazorPages();
string? path = builder.Configuration.GetConnectionString("sql");
ArgumentNullException.ThrowIfNull(path);

builder.Services.AddDbContext<Connection>(row => row.UseSqlServer(path));
builder.Services.AddScoped<IQueryService<All,List<UserDTO>>, AllUserService>();
builder.Services.AddScoped<IQueryService<SearchById, UserDTO>, GetUserByIdQuery>();
builder.Services.AddScoped<ICommand<UserDTO>, RegistrationCommand>();
builder.Services.AddScoped<IRepository, RepositoryDB>();

var app = builder.Build();

app.UseRouting();
app.UseStaticFiles();
app.MapRazorPages();
app.Run();
