using System.ComponentModel.DataAnnotations;

namespace ExemploAPI.Models.Request
{
	public class NovoProdutoViewModel	{
		[Required(ErrorMessage = "A descrição é obrigatória.")]
		[MinLength(3, ErrorMessage = "A descrição deve ter no mínimo 3 caracteres.")]
		public string Descricao { get; set; }

		[Required(ErrorMessage = "O preço é obrigatório.")]
		[Range(0, double.MaxValue, ErrorMessage = "O preço deve ser maior ou igual a 0.")]
		public decimal Preco { get; set; }

		[Required(ErrorMessage = "O estoque é obrigatório.")]
		[Range(0, int.MaxValue, ErrorMessage = "O estoque deve ser maior ou igual a 0.")]
		public int Estoque { get; set; }
	}
}
