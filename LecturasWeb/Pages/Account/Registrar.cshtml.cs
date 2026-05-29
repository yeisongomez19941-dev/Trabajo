using Libreria_Lecturas.Entidades;
using Libreria_Lecturas.Implementaciones;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
namespace LecturasWeb.Pages.Account;

public class RegistrarModel : PageModel
{
    private readonly UserManager<IdentityUser> _userManager;
    private readonly SignInManager<IdentityUser> _signInManager;
    private readonly Conexion _context;

    public RegistrarModel(
        UserManager<IdentityUser> userManager,
        SignInManager<IdentityUser> signInManager,
        Conexion context)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _context = context;
    }

    [BindProperty] public string Nombre { get; set; }
    [BindProperty] public string Email { get; set; }
    [BindProperty] public string Password { get; set; }
    [BindProperty] public string ConfirmPassword { get; set; }

    public async Task<IActionResult> OnPostAsync()
    {
        if (Password != ConfirmPassword)
        {
            ModelState.AddModelError("", "Las contraseñas no coinciden");
            return Page();
        }

        var identityUser = new IdentityUser { UserName = Email, Email = Email };
        var resultado = await _userManager.CreateAsync(identityUser, Password);

        if (resultado.Succeeded)
        {
            await _userManager.AddToRoleAsync(identityUser, "Usuario");

            _context.Usuarios.Add(new Usuarios
            {
                Nombre = Nombre,
                Email = Email,
                FechaRegistro = DateTime.UtcNow
            });
            await _context.SaveChangesAsync();

            await _signInManager.SignInAsync(identityUser, false);
            return RedirectToPage("/Index");
        }

        foreach (var error in resultado.Errors)
            ModelState.AddModelError("", error.Description);

        return Page();
    }
}