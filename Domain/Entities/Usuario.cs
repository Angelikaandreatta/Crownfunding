using Domain.Validators;

namespace Domain.Entities
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }


        public Usuario()
        { }

        public Usuario(string nome, string email, string telefone)
        {
            Validation(nome, email, telefone);
        }

        public Usuario(int id, string nome, string email, string telefone)
        {
            ValidationException.When(id < 0, "Id deve ser maior que 0.");
            Id = id;
            Validation(nome, email, telefone);
        }

        private void Validation(string nome, string email, string telefone)
        {
            ValidationException.When(string.IsNullOrEmpty(nome), "Nome deve ser informado.");
            ValidationException.When(string.IsNullOrEmpty(email), "Email deve ser informado.");
            ValidationException.When(string.IsNullOrEmpty(telefone), "Telefone deve ser informado.");
            Nome = nome;
            Email = email;
            Telefone = telefone;
        }
    }
}
