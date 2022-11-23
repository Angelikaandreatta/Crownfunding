using Domain.Validators;

namespace Domain.Entities
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }


        public Usuario()
        { }

        public Usuario(string email, string senha)
        {
            Validation(email, senha);
        }

        public Usuario(int id, string email, string senha)
        {
            ValidationException.When(id < 0, "Id deve ser maior que 0.");
            Id = id;
            Validation(email, senha);
        }

        private void Validation(string email, string senha)
        {
            ValidationException.When(string.IsNullOrEmpty(email), "Email deve ser informado.");
            ValidationException.When(string.IsNullOrEmpty(senha), "Senha deve ser informado.");

            Email = email;
            Senha = senha;
        }
    }
}
