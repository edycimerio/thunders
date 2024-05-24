using Domain.Thunders.Entities;
using Domain.Thunders.Request;
using Domain.Thunders.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Thunders.Interfaces.Services
{
    public interface ITarefaService
    {
        Task<TarefaResponse> GetById(int id);
        Task Insert(TarefaRequest postagem);
        Task Update(TarefaRequest postagem);
        Task Delete(int id);
        Task<IEnumerable<TarefaResponse>> GetAll();
    }
}
