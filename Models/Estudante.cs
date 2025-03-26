namespace AulaEntity.Models
{
    public class Estudante
    {
        public Guid Id { get; set; }

        public string Nome { get; set; }

        public bool Ativo { get; set; }

        public Estudante()
        {
            Nome = GerarNomeAleatorio();
            Id = Guid.NewGuid();
            Ativo = true;

            string GerarNomeAleatorio()
            {
                string[] nomes = { "João", "Maria", "Pedro", "Ana", "Lucas", "Juliana", "Carlos", "Beatriz", "Rafael", "Fernanda" };
                string[] sobrenomes = { "Silva", "Santos", "Oliveira", "Souza", "Pereira", "Costa", "Rodrigues", "Almeida", "Nascimento", "Lima" };

                Random random = new Random();
                string nomeAleatorio = nomes[random.Next(nomes.Length)] + " " + sobrenomes[random.Next(sobrenomes.Length)];

                return nomeAleatorio;
            }
        }
       
    }
}