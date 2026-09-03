using Microsoft.AspNetCore.Mvc;

namespace SistemaGestaoConsultasUVV.Controllers;

public class HomeController : Controller
{
    public IActionResult Index() => View();
}
