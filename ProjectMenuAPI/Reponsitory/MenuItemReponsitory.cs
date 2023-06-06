using ProjectMenuAPI.Data;
using ProjectMenuAPI.Entities;
using ProjectMenuAPI.Models;

namespace ProjectMenuAPI.Reponsitory
{
    public class MenuItemReponsitory : IMenuItemReponsitory
    {

        private readonly MSDbContext _context; // private only không thể thay đổi trong quá trình chạy ứng dụng 
        public MenuItemReponsitory(MSDbContext context)
        {
            _context = context;
        }
        private List<MenuItemReponse> GetMenuChild(MenuItemReponse menuItem)
        {
            List<MenuItemReponse> listMenuSubResult = new List<MenuItemReponse>();
            var childItems = _context.MenuItems.Where(mi => mi.MenuMasterID == menuItem.Id).ToList();
            listMenuSubResult = childItems.Select(x => new MenuItemReponse()
            {
                Id = x.Id,
                MenuMasterID = x.MenuMasterID,
                Url = x.Url,
                Name = x.Name,

            }).ToList();

            foreach (var childItem in listMenuSubResult)
            {
                childItem.ListsubMenuReponses = GetMenuChild(childItem);
            }

            return listMenuSubResult;
        }
        public List<MenuItemReponse> GetMenuItem()
        {
            List<MenuItemReponse> listMenuSubResult = new List<MenuItemReponse>();
            List<MenuItemReponse> items = new List<MenuItemReponse>();

            var menuItems = _context.MenuItems.Where(mi => mi.MenuMasterID == null).ToList();
            listMenuSubResult = menuItems.Select(x => new MenuItemReponse()
            {
                Id = x.Id,
                MenuMasterID = x.MenuMasterID,
                Url = x.Url,
                Name = x.Name,

            }).ToList();

            foreach (var menuItem in listMenuSubResult)
            {
                var childItems = GetMenuChild(menuItem);
                menuItem.ListsubMenuReponses = childItems;

                items.Add(menuItem);
            }

            return items;
        }
        public bool Create(MenuItem menuItems)
        {
            try
            {

                _context.MenuItems.Add(menuItems);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
