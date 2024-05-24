using Domain.Thunders.Entities;
using Domain.Thunders.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Thunders
{
    public class TarefaRepository : ITarefaRepository
    {
        private readonly TarefaContext _context;

        public TarefaRepository(TarefaContext context)
        {
            _context = context;
        }

        public async Task<Tarefa> GetById(int id)
        {
            var ret = await _context.Tarefas.FindAsync(id);
            if (ret != null)
            {
                _context.Entry(ret).State = EntityState.Detached;
            }

            return ret;


        }

        public async Task<IEnumerable<Tarefa>> GetAll()
        {
            return await _context.Tarefas.ToListAsync();
        }

        public async Task Insert(Tarefa post)
        {
            _context.Tarefas.Add(post);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Tarefa tarefa)
        {
            _context.Entry(tarefa).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var post = await _context.Tarefas.FindAsync(id);
            if (post != null)
            {
                _context.Tarefas.Remove(post);
                await _context.SaveChangesAsync();
            }
        }
    }
}
