using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Donation.Models
{
    [Table("Usuario")]
    public class UsuarioModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UsuarioId { get; set; }

        [Required]
        [MaxLength(30)]
        public string NomeUsuario { get; set; }

        [Required]
        [MaxLength(80)]
        public string EmailUsuario { get; set; }

        [Required]
        [MaxLength(30)]
        public string Senha { get; set; }

        [Required]
        [MaxLength(30)]
        public string Regra { get; set; }
        
        public UsuarioModel()
        {
        }

        public UsuarioModel(int usuarioId, string email, string nomeUsuario, string senha, string regra)
        {
            UsuarioId = usuarioId;
            NomeUsuario = nomeUsuario;
            EmailUsuario = email;
            Senha = senha;
            Regra = regra;
        }
    }
}
