using ExemploAPI.Context;
using ExemploAPI.Interfaces.Repositorio;
using ExemploAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace ExemploAPI.Repositorio
{
    public class AuthRepositorio : IAuthRepositorio
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public AuthRepositorio(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public Usuario BuscarUsuario(string usuario)
        {
            return _applicationDbContext.Usuario.Where(u => u.Nome == usuario).FirstOrDefault();
        }

        public async Task<ActionResult<Usuario>> Cadastrar(Usuario usuario)
        {
            _applicationDbContext.Usuario.Add(usuario);
            await _applicationDbContext.SaveChangesAsync();
            return usuario;
        }

    }
}
