using ExemploAPI.Models.Validations;

namespace ExemploAPI.ViewModel
{
    public class UsuarioViewModel : EntityViewModel
    {
        public string Nome { get; set; }
        public int Idade { get; set; }
        public string Login { get; set; }
        public string Cpf { get; set; }
    }
}
