public class HomeController : Controller
{
    public IActionResult Error(int statusCode)
    {
        if (statusCode == 404)
        {
            ViewBag.ErrorMessage = "Conteúdo não encontrado.";
        }
        else if (statusCode == 403)
        {
            ViewBag.ErrorMessage = "Você não tem permissão para acessar este conteúdo.";
        }
        else
        {
            ViewBag.ErrorMessage = "Ocorreu um erro inesperado.";
        }

        return View(); // Retorna para uma View chamada Error.cshtml
    }
}
