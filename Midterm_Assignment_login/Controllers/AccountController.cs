// AccountController.cs
using Microsoft.AspNetCore.Mvc;
using Midterm_Assignment_login.Models;
using System.ComponentModel.DataAnnotations;

public class AccountController : Controller
{
    private readonly UserService _userService;

    public AccountController(UserService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    public ActionResult Register()
    {
        return View();
    }

    [HttpPost]
    public ActionResult Register(RegisterViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        var isRegistered = _userService.RegisterUser(model.Username, model.Password, model.Email);

        if (!isRegistered)
        {
            ModelState.AddModelError("", "Registration failed. Please try again with a different username.");
            return View(model);
        }

        return RedirectToAction("Login");
    }

    [HttpGet]
    public ActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public ActionResult Login(LoginViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        User user;
        var isLoggedIn = _userService.Login(model.Username, model.Password, out user);

        if (!isLoggedIn)
        {
            ModelState.AddModelError("", "Invalid username or password.");
          
        }

        return View(model);
    }

    // ViewModel


  
}

