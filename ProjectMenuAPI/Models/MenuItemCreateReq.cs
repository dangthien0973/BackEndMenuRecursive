namespace ProjectMenuAPI.Models
{
    public class MenuItemCreateReq
    {
        public string Name { get; set; }

        public string Url { get; set; }

        public int? MenuMasterID { get; set; }
    }
}
