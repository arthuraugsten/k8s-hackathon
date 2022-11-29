using KubernetesHackathon.Core;
using Microsoft.AspNetCore.Mvc;

namespace KubernetesHackathon.Vote.Controllers;

public sealed class HomeController : Controller
{
    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Vote([FromServices] DatabaseContext context)
    {
        await context.AddAsync(new Core.Vote());
        await context.SaveChangesAsync();

        return View();
    }
}
