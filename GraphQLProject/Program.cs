using GraphiQl;
using GraphQL;
using GraphQL.Types;
using GraphQLProject.Query;
using GraphQLProject.Schema;
using GraphQLProject.Type;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddTransient<GraphQLProject.Interfaces.IMenuRepository, GraphQLProject.Services.MenuRepository>();

builder.Services.AddTransient<MenuType>();
builder.Services.AddTransient<MenuQuery>();
builder.Services.AddTransient<ISchema, MenuSchema>();

builder.Services.AddGraphQL(b => b.AddAutoSchema<ISchema>().AddSystemTextJson());

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseGraphiQl("/graphiql");

app.UseGraphQL<ISchema>();

app.UseAuthorization();

app.MapControllers();

app.Run();
