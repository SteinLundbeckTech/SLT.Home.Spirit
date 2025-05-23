/*
    @Date                 : 15.12.2024
    @Author               : Stein Lundbeck
    @Description          : null
    @Version              : 1.0.0.3
    @Latest               : 23.05.2025
*/

using Microsoft.AspNetCore.Mvc;
using SLT.Assets.Site;

namespace SLT.Home.Spirit.Controllers
{
    public class SLTController(IHttpContextAccessor httpContext, ICacheAccessor cache) : CustomControllerBase(httpContext)
    {
        public IActionResult Index() => View();
        public IActionResult Products()
        {
            ViewData["Title"] = cache.GetLocalValue("WordProducts").Value;

            return View();
        }

        public IActionResult Technology()
        {
            ViewData["Title"] = cache.GetLocalValue("WordTechnology").Value;

            return View();
        }
    }
}
