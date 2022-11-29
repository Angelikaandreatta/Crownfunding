

using Domain.Validators;

namespace Domain.Entities
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }

        public Usuario()
        { }

        public Usuario(string nome, string telefone, string email, string senha)
        {
            Validation(nome, telefone, email, senha);
        }

        public Usuario(int id, string nome, string telefone, string email, string senha)
        {
            ValidationException.When(id < 0, "Id deve ser maior que 0.");
            Id = id;
            Validation(nome, telefone, email, senha);
        }

        private void Validation(string nome, string telefone, string email, string senha)
        {
            ValidationException.When(string.IsNullOrEmpty(nome), "Nome deve ser informado.");
            ValidationException.When(string.IsNullOrEmpty(telefone), "Telefone deve ser informado.");
            ValidationException.When(string.IsNullOrEmpty(email), "Email deve ser informado.");
            ValidationException.When(string.IsNullOrEmpty(senha), "Senha deve ser informada.");
            Nome = nome;
            Telefone = telefone;
            Email = email;
            Senha = senha;
        }
    }
}
