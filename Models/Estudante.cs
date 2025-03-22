namespace AulaEntity.Models
{
    public class Estudante
    {
        public Guid Id { get; set; } 
        public string Nome { get; set; } 
        public bool Ativo { get; set; } 

        public Estudante(string nome)
        {
            Nome = nome;
            Id = new Guid();
            Ativo = true;
        }
    }
}
