using Domain.Validators;

namespace Domain.Entities
{
    public class Categoria
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public Categoria()
        { }

        public Categoria(string nome)
        {
            Validation(nome);
        }

        public Categoria(int id, string nome)
        {
            ValidationException.When(id < 0, "Id deve ser maior que 0.");
            Id = id;
            Validation(nome);
        }

        private void Validation(string nome)
        {
            ValidationException.When(string.IsNullOrEmpty(nome), "Nome deve ser informada.");
            Nome = nome;

        }
    }
}
