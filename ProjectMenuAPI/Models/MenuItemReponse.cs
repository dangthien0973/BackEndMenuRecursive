using ProjectMenuAPI.Entities;

namespace ProjectMenuAPI.Models
{
    public class MenuItemReponse
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Url { get; set; }

        public int? MenuMasterID { get; set; }
        public List<MenuItemReponse> ListsubMenuReponses { get; set; }
        public MenuItemReponse SubMenuParent { get; set; }

    }
}
