/*
    @Date                 : 15.12.2024
    @Author               : Stein Lundbeck
    @Description          : null
    @Version              : 1.0.0.1
    @Latest               : 18.12.2024
*/

using Microsoft.AspNetCore.Mvc;
using SLT.Assets.Site;

namespace SLT.Home.Spirit.Controllers
{
    public class SLTController(IHttpContextAccessor httpContext) : CustomControllerBase(httpContext)
    {
        public async Task<IActionResult> Index()
        {
            return View();
        }
    }
}
