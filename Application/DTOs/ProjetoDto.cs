using Domain.Enuns;

namespace Application.DTOs
{
    public class ProjetoDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Links { get; set; }
        public string Meta { get; set; }
        public string ImagemPerfil { get; set; }
        public string ImagemCapa { get; set; }
        public Categoria Categoria { get; set; }

        public ProjetoDto()
        { }
    }
}
