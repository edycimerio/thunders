using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Thunders.Request
{
    public class TarefaRequest
    {
        public int IdTarefa { get; set; }
        public string NomeTarefa { get; set; }
        public string DescricaoTarefa { get; set; }
        public Boolean AtivoTarefa { get; set; }
        public DateTime DataCriacaoTarefa { get; set; }
    }
}
