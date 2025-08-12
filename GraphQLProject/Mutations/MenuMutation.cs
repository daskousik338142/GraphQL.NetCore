using GraphQL;
using GraphQL.Types;
using GraphQLProject.Interfaces;
using GraphQLProject.Models;
using GraphQLProject.Type;

namespace GraphQLProject.Mutations
{
    public class MenuMutation : ObjectGraphType
    {
        public MenuMutation(IMenuRepository menuRepository) {
            Field<MenuType>("CreateMenu").Arguments(new QueryArguments(new QueryArgument<MenuInputType> { Name = "menu" })).Resolve(context =>
            {
                Console.WriteLine("CreateMenu called");
                Console.WriteLine(context.GetArgument<Menu>("menu"));
                return menuRepository.AddMenu(context.GetArgument<Menu>("menu"));
            });

            Field<MenuType>("UpdateMenu").Arguments(new QueryArguments(new QueryArgument<IntGraphType> { Name = "menuId" }, new QueryArgument<MenuInputType> { Name = "menu" })).Resolve(context =>
            {
                return menuRepository.UpdateMenu(context.GetArgument<int>("menuId"), context.GetArgument<Menu>("menu"));
            });

            Field<MenuType>("DeleteMenu").Arguments(new QueryArguments(new QueryArgument<IntGraphType> { Name = "menuId" })).Resolve(context =>
            {
                menuRepository.DeleteMenu(context.GetArgument<int>("menuId"));
                return "Manu is deleted successfully";
            });
        }
    }
}
