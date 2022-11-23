using Domain.Validators;

namespace Domain.Entities
{
    public sealed class Pessoa
    {
        public int Id { get; private set; }
        public string Documento { get; private set; }
        public string Nome { get; private set; }
        public string Telefone { get; private set; }

        public Pessoa(string documento, string nome, string telefone)
        {
            Validation(documento, nome, telefone);
        }

        public Pessoa(int id, string documento, string nome, string telefone)
        {
            ValidationException.When(id < 0, "Id invalido");
            Id = id;
            Validation(documento, nome, telefone);
        }

        private void Validation(string documento, string nome, string telefone)
        {
            ValidationException.When(string.IsNullOrEmpty(documento), "Documento deve ser informado!");
            ValidationException.When(string.IsNullOrEmpty(nome), "Nome deve ser informado!");
            ValidationException.When(string.IsNullOrEmpty(telefone), "Phone deve ser informado!");

            Nome = nome;
            Documento = documento;
            Telefone = telefone;
        }
    }
}
