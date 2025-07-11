using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Donation.Models;

namespace Donation.ViewModel
{
    public class TrocaResponseVM
    {
        public Guid TrocaId { get; set; }

        public DateTime DataCriacao { get; set; }

        public TrocaStatus Status { get; set; }

        public int UsuarioId { get; set; }

        public ProdutoResponseVM Produto1 { get; set; }

        public ProdutoResponseVM Produto2 { get; set; }
    }
}