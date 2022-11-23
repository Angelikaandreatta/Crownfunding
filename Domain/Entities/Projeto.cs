using Domain.Enuns;
using Domain.Validators;

namespace Domain.Entities
{
    public class Projeto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Links { get; set; }
        public string ImagemPerfil { get; set; }
        public string ImagemCapa { get; set; }
        public string Meta { get; set; }
        public Categoria Categoria { get; set; }

        public Projeto()
        { }

        public Projeto(string nome, string descricao, string links, string imagemPerfil, string imagemCapa, string metaFinanceira, Categoria categoria)
        {
            Validation(nome, descricao, links, imagemPerfil, imagemCapa, metaFinanceira, categoria);
        }

        public Projeto(int id, string nome, string descricao, string links, string imagemPerfil, string imagemCapa, string metaFinanceira, Categoria categoria)
        {
            ValidationException.When(id < 0, "Id deve ser maior que 0.");
            Id = id;
            Validation(nome, descricao, links, imagemPerfil, imagemCapa, metaFinanceira, categoria);
        }

        private void Validation(string nome, string descricao, string links, string imagemPerfil, string imagemCapa, string metaFinanceira, Categoria categoria)
        {
            ValidationException.When(string.IsNullOrEmpty(nome), "Nome deve ser informado.");
            Nome = nome;
            Descricao = descricao;
            Links = links;
            ImagemPerfil = imagemPerfil;
            ImagemCapa = imagemCapa;
            Meta = metaFinanceira;
            Categoria = categoria;
        }
    }
}
