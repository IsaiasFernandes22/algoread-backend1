public class ContentController : Controller
{
    [HttpPost]
    public IActionResult CreateContent(ContentModel model)
    {
        if (ModelState.IsValid)
        {
            try
            {
                // Lógica para criar o conteúdo
                _contentService.Create(model);

                // Armazenar a mensagem de sucesso no TempData
                TempData["SuccessMessage"] = "Conteúdo criado com sucesso!";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "Falha ao criar o conteúdo: " + ex.Message;
                return View(model);
            }
        }

        TempData["ErrorMessage"] = "Dados inválidos. Verifique as informações.";
        return View(model);
    }

    [HttpPost]
    public IActionResult UpdateContent(ContentModel model)
    {
        if (ModelState.IsValid)
        {
            try
            {
                // Lógica para atualizar o conteúdo
                _contentService.Update(model);

                // Armazenar a mensagem de sucesso no TempData
                TempData["SuccessMessage"] = "Conteúdo atualizado com sucesso!";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "Falha ao atualizar o conteúdo: " + ex.Message;
                return View(model);
            }
        }

        TempData["ErrorMessage"] = "Dados inválidos. Verifique as informações.";
        return View(model);
    }
}
