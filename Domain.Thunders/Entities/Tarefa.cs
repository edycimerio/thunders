using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Thunders.Entities
{
    public class Tarefa
    {
        public int Id { get; set; }

        [MaxLength(20)]
        public string Nome { get; set; }
        [MaxLength(30)]
        public string Descricao { get; set; }
        public Boolean Ativo { get; set; }

        [Column(TypeName = "date")]
        public DateTime DataCriacao { get; set; }

    }
}
