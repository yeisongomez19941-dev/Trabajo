using Libreria_Lecturas.Entidades;
using Libreria_Lecturas.Implementaciones;
using Microsoft.AspNetCore.Identity;

namespace LecturasWeb.Data
{
    public static class SeedData
    {
        public static async Task InicializarAsync(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();
            var context = serviceProvider.GetRequiredService<Conexion>();

            // Crear roles
            string[] roles = { "Admin", "Usuario" };
            foreach (var rol in roles)
            {
                if (!await roleManager.RoleExistsAsync(rol))
                    await roleManager.CreateAsync(new IdentityRole(rol));
            }

            // Crear Admin
            var adminEmail = "admin@lecturas.com";
            if (await userManager.FindByEmailAsync(adminEmail) == null)
            {
                var admin = new IdentityUser { UserName = adminEmail, Email = adminEmail };
                await userManager.CreateAsync(admin, "Admin123!");
                await userManager.AddToRoleAsync(admin, "Admin");

                // Crear en tabla Usuarios
                if (!context.Usuarios.Any(u => u.Email == adminEmail))
                {
                    context.Usuarios.Add(new Usuarios
                    {
                        Nombre = "Admin",
                        Email = adminEmail,
                        FechaRegistro = DateTime.UtcNow
                    });
                    await context.SaveChangesAsync();
                }
            }

            // Crear Usuario
            var usuarioEmail = "usuario@lecturas.com";
            if (await userManager.FindByEmailAsync(usuarioEmail) == null)
            {
                var usuario = new IdentityUser { UserName = usuarioEmail, Email = usuarioEmail };
                await userManager.CreateAsync(usuario, "Usuario123!");
                await userManager.AddToRoleAsync(usuario, "Usuario"); 

                // Crear en tabla Usuarios
                if (!context.Usuarios.Any(u => u.Email == usuarioEmail))
                {
                    context.Usuarios.Add(new Usuarios
                    {
                        Nombre = "Usuario",
                        Email = usuarioEmail,
                        FechaRegistro = DateTime.UtcNow
                    });
                    await context.SaveChangesAsync();
                }
            }
        }
    }
}