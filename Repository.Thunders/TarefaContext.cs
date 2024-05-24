using Domain.Thunders.Entities;
using Microsoft.EntityFrameworkCore;


namespace Repository.Thunders
{    
    public class TarefaContext : DbContext
    {
        public TarefaContext(DbContextOptions<TarefaContext> options) : base(options) { }

        public DbSet<Tarefa> Tarefas { get; set; }
    }
}
