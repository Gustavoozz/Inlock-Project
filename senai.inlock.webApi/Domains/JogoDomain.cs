using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;

namespace senai.inlock.webApi.Domains
{
    public class JogoDomain
    {
        public int IdJogo { get; set; }

        public int IdEstudio { get; set; }


        [Required(ErrorMessage = "O nome do jogo é obrigatório!")]
        public string? Nome { get; set; }


        [Required(ErrorMessage = "A descrição do jogo é obrigatória!")]
        public string? Descricao { get; set; }


        [Required(ErrorMessage = "A data de lançamento do jogo é obrigatória!")]
        public DateTime DataLancamento { get; set; }


        [Required(ErrorMessage = "O valor do jogo é obrigatório!")]
        public float Valor{ get; set; }


        public EstudioDomain Estudio { get; set; }
    }
}
