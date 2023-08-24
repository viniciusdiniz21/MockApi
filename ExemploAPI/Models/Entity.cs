namespace ExemploAPI.Models
{
    public abstract class Entity
    {

        public int Id { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime? DataAlteracao { get; set; }
        public DateTime? DataExclusao { get; set; }

    }
}
