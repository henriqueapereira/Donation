using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Donation.ViewModel
{
    public class UsuarioRequestVM
    {
        public int UsuarioId { get; set; }

        public string EmailUsuario { get; set; }

        public string NomeUsuario { get; set; }

        public string? Regra { get; set; }

        public string Senha { get; set; }
    }
}