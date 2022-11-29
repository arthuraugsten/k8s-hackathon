using KubernetesHackathon.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KubernetesHackathon.Vote.Controllers;

public sealed class HomeController : Controller
{
    [HttpGet]
    public async Task<IActionResult> Index([FromServices] DatabaseContext context)
    {
        return View(await context.Votes.CountAsync());
    }
}
