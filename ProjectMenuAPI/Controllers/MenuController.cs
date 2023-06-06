using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectMenuAPI.Entities;
using ProjectMenuAPI.Models;
using ProjectMenuAPI.Reponsitory;

namespace ProjectMenuAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MenuController : ControllerBase
    {
        private readonly ILogger<MenuController> _logger;

        private readonly IMenuItemReponsitory _menuItem;
        public MenuController(ILogger<MenuController> logger, IMenuItemReponsitory menuItem)
        {
            _logger = logger;
            _menuItem = menuItem;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllMenu()
        {
            try
            {


                var listMenu = _menuItem.GetMenuItem();
                return Ok(listMenu);
            }
            catch (Exception ex)
            {
                return BadRequest("Please try later !");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] MenuItemCreateReq request)
        {
            try
            {


                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var task =  _menuItem.Create(new Entities.MenuItem()
                {
                    MenuMasterID = request.MenuMasterID,
                    Name = request.Name,
                    Url = request.Url,

                });
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest();
            }
        }
    }
}