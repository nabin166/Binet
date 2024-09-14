using Microsoft.AspNetCore.Mvc;

namespace BinetWebsite.Controllers
{
    public class Ongoingproject : Controller
    {
        public IActionResult binetGold()
        {
            return PartialView();
        }
        [HttpGet]
        public IActionResult nepalMart()
        {
            return PartialView("nepalMart");
        }
      
        
        public IActionResult fenegosida()
        {
            return PartialView("fenegosida");
        }
        public IActionResult stockManagement()
        {
            return PartialView("stockManagement");
        }
        public IActionResult accountingSoftware()
        {
            return PartialView("accountingSoftware");
        }
        public IActionResult numerologyApp()
        {
            return PartialView("numerologyApp");
        }
        public IActionResult socialNetwork()
        {
            return PartialView("socialNetwork");
        }
    }
}
