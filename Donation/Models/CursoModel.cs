using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Donation.Models
{
    public class CursoModel
    {
        [JsonProperty("nome")]
        public string Nome { get; set; }

        [JsonProperty("nivel")]
        public string Nivel { get; set; }

        [JsonProperty("preco")]
        public string Preco { get; set; }

        [JsonProperty("conteudo")]
        public string Conteudo { get; set; }

        [JsonProperty("percentualConclusao")]
        public int PercentualConclusao { get; set; }

        [JsonProperty("concluido")]
        public bool Concluido { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }
    }
}