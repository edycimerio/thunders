using Domain.Thunders.Entities;
using Domain.Thunders.Interfaces.Repository;
using Domain.Thunders.Interfaces.Services;
using Domain.Thunders.Request;
using Domain.Thunders.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Thunders.Services
{

    public class TarefaService : ITarefaService
    {
        private readonly ITarefaRepository _tarefaRepository;
        public TarefaService(ITarefaRepository tarefaRepository)
        {
            _tarefaRepository = tarefaRepository;
        }

        public async Task<TarefaResponse> GetById(int id)
        {
            var tarefa = await _tarefaRepository.GetById(id);

            TarefaResponse request = new TarefaResponse();
            if (tarefa != null)
            {
                request.IdTarefa = tarefa.Id;
                request.NomeTarefa = tarefa.Nome;
                request.DescricaoTarefa = tarefa.Descricao;
                request.AtivoTarefa = tarefa.Ativo;
                request.DataCriacaoTarefa = tarefa.DataCriacao;
            }

            return request;
        }

        public async Task Insert(TarefaRequest request)
        {
            Tarefa tarefa = new Tarefa();
            tarefa.Nome = request.NomeTarefa;
            tarefa.Descricao = request.DescricaoTarefa;
            tarefa.Ativo = request.AtivoTarefa;
            tarefa.DataCriacao = DateTime.Now;

            await _tarefaRepository.Insert(tarefa);
        }

        public async Task Update(TarefaRequest request)
        {
            Tarefa tarefa = new Tarefa();
            tarefa.Id = request.IdTarefa;
            tarefa.Nome = request.NomeTarefa;
            tarefa.Descricao = request.DescricaoTarefa;
            tarefa.Ativo = request.AtivoTarefa;
            tarefa.DataCriacao = DateTime.Now;

            await _tarefaRepository.Update(tarefa);
        }

        public async Task Delete(int id)
        {
            await _tarefaRepository.Delete(id);
        }

        public async Task<IEnumerable<TarefaResponse>> GetAll()
        {
            var tarefa = await _tarefaRepository.GetAll();

            IList<TarefaResponse> lista = new List<TarefaResponse>();
            IEnumerable<TarefaResponse> retorno = null;

            foreach (var item in tarefa)
            {
                TarefaResponse response = new TarefaResponse();

                response.IdTarefa = item.Id;
                response.NomeTarefa = item.Nome;
                response.DescricaoTarefa = item.Descricao;
                response.AtivoTarefa = item.Ativo;
                response.DataCriacaoTarefa = item.DataCriacao;

                lista.Add(response);
            }

            retorno = lista;

            return retorno;
        }
    }
}
