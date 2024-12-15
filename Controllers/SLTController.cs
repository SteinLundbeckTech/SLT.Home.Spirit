/*
    @Date                 : 15.12.2024
    @Author               : Stein Lundbeck
    @Description          : null
    @Version              : 1.0.0.1
    @Latest               : 15.12.2024
*/

using Microsoft.AspNetCore.Mvc;
using SLT.Assets.Component;
using SLT.Assets.Site;

namespace SLT.Home.Spirit.Controllers
{
    public class SLTController(IUtilityFactory utilityFactory) : ControllerCustomBase(utilityFactory)
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
