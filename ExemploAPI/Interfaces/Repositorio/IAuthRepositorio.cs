using ExemploAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace ExemploAPI.Interfaces.Repositorio
{
    public interface IAuthRepositorio
    {
        Task<ActionResult<Usuario>> Cadastrar(Usuario usuario);
        Usuario BuscarUsuario(string usuario);
    }
}
