public IActionResult CreateUser(UserModel model)
{
    if (!ModelState.IsValid)
    {
        return View(model);
    }

    try
    {
        _userService.Create(model);
        TempData["SuccessMessage"] = "Usuário criado com sucesso!";
        return RedirectToAction("Index");
    }
    catch (Exception ex)
    {
        TempData["ErrorMessage"] = "Erro ao criar o usuário: " + ex.Message;
        return View(model);
    }
}
