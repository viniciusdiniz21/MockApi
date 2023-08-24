using ExemploAPI.Models.Validations;

namespace ExemploAPI.Models
{
	public class Usuario
	{
		public string Nome { get; set; }
		public int Idade { get; set; }
		public string Login { get; set; }
		public string Senha { get; set; }

		[CpfValidation(ErrorMessage = "CPF inválido.")]
		public string Cpf { get; set; }
	}

}
