using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Donation.Models
{

    [Table("Produto")]
    public class ProdutoModel
    {
        
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProdutoId { get; set; }

        [StringLength(50)]
        public string Nome { get; set; }

        public bool Disponivel { get; set; }

        [StringLength(150)]
        public string Descricao { get; set; }

        [StringLength(200)]
        public string SugestaoTroca { get; set; }

        public double Valor { get; set; }

        public DateTime DataCadastro { get; set; } = DateTime.Now;

        public DateTime DataExpiracao { get; set; }


        //Foreing Key
        public int UsuarioId { get; set; }

        //Navigation Property
        [ForeignKey(nameof(UsuarioId))]
        public UsuarioModel Usuario { get; set; }

        //Foreign Key
        public int CategoriaId { get; set; }

        //Navigation Property
        [ForeignKey(nameof(CategoriaId))]
        public CategoriaModel Categoria { get; set; }
    }
}