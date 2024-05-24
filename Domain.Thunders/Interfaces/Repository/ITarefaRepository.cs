using Domain.Thunders.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Thunders.Interfaces.Repository
{    
    public interface ITarefaRepository
    {
        Task<Tarefa> GetById(int id);
        Task Insert(Tarefa postagem);
        Task Update(Tarefa postagem);
        Task Delete(int id);
        Task<IEnumerable<Tarefa>> GetAll();
    }
}
