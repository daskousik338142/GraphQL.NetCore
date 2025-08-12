using GraphQLProject.Data;
using GraphQLProject.Interfaces;
using GraphQLProject.Models;

namespace GraphQLProject.Services
{
    public class MenuRepository : IMenuRepository
    {

        private GraphQLDbContext _dbContext;

        public MenuRepository(GraphQLDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Menu AddMenu(Menu menu)
        {
            _dbContext.Menus.Add(menu);
            _dbContext.SaveChanges();
            return menu;
        }

        public void DeleteMenu(int id)
        {
            var searchedMenu = _dbContext.Menus.Find(id);
            if (searchedMenu == null)
                throw new InvalidOperationException($"Menu with id {id} not found.");
            _dbContext.Menus.Remove(searchedMenu);
            _dbContext.SaveChanges();
        }

        public List<Menu> GetAllMenu()
        {
            return _dbContext.Menus.ToList();
        }

        public Menu GetMenuById(int id)
        {
            var menu = _dbContext.Menus.Find(id);
            if (menu == null)
                throw new InvalidOperationException($"Menu with id {id} not found.");
            return menu;
        }

        public Menu UpdateMenu(int id, Menu menu)
        {
            var searchedMenu = _dbContext.Menus.Find(id);
            if (searchedMenu == null)
                throw new InvalidOperationException($"Menu with id {id} not found.");
            searchedMenu.Name = menu.Name;
            searchedMenu.Description = menu.Description;
            searchedMenu.Price = menu.Price;
            _dbContext.Menus.Update(searchedMenu);
            _dbContext.SaveChanges();
            return menu;
        }

    }
}
