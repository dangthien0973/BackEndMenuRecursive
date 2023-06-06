using ProjectMenuAPI.Entities;
using ProjectMenuAPI.Models;

namespace ProjectMenuAPI.Reponsitory
{
    public interface  IMenuItemReponsitory
    {
        
        public List<MenuItemReponse> GetMenuItem();
        public bool Create(MenuItem menuItems);
    }
}
