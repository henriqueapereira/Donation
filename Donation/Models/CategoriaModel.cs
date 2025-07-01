using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Donation.Models
{
    [Table("Categoria")]
    public class CategoriaModel 
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CategoriaId { get; set; }
            
        [Required(ErrorMessage = "O nome para categoria é obrigatório.")]
        [StringLength(55)]
        [MinLength(3)]
        public string Nome { get; set; } 
            
        [Required]
        [StringLength(256)]
        public string? Descricao { get; set; } 
            
        [NotMapped]
        public string? Token { get; set; }

        public CategoriaModel()
        {
            
        }

        public CategoriaModel(int categoriaId, string nome, string? descricao)
        {
            CategoriaId = categoriaId;
            Nome = nome;
            Descricao = descricao;
        }

        public CategoriaModel(int categoriaId, string nome, string? descricao, string? token)
        {
            CategoriaId = categoriaId;
            Nome = nome;
            Descricao = descricao;
            Token = token;
        }
    }
}
