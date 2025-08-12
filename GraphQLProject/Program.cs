using GraphiQl;
using GraphQL;
using GraphQL.Types;
using GraphQLProject.Data;
using GraphQLProject.Mutations;
using GraphQLProject.Query;
using GraphQLProject.Schema;
using GraphQLProject.Type;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Use Scoped for repository when using DbContext
builder.Services.AddScoped<GraphQLProject.Interfaces.IMenuRepository, GraphQLProject.Services.MenuRepository>();

builder.Services.AddTransient<MenuType>();
builder.Services.AddTransient<MenuQuery>();
builder.Services.AddTransient<MenuMutation>();
builder.Services.AddTransient<MenuInputType>();

builder.Services.AddTransient<ISchema, MenuSchema>();

builder.Services.AddGraphQL(b => b.AddAutoSchema<ISchema>().AddSystemTextJson());

// Use SQL Server instead of MySQL
var connectionString = builder.Configuration.GetConnectionString("GraphQLDb");

builder.Services.AddDbContext<GraphQLDbContext>(options =>
    options.UseSqlServer(connectionString)
);

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseGraphiQl("/graphiql");

app.UseGraphQL<ISchema>();

app.UseAuthorization();

app.MapControllers();

app.Run();
