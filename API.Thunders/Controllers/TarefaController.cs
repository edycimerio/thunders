using Azure.Core;
using Domain.Thunders.Interfaces.Services;
using Domain.Thunders.Request;
using Microsoft.AspNetCore.Mvc;

namespace API.Thunders.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class TarefaController : ControllerBase
    {
        private readonly ITarefaService _tarefaService;

        public TarefaController(ITarefaService tarefaService)
        {
            _tarefaService = tarefaService;
        }



        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var tarefa = await _tarefaService.GetById(id);
            
            if (tarefa == null || tarefa.IdTarefa == 0)
                return BadRequest("Tarefa não encontrada! Informe uma tarefa válida.");
            return Ok(tarefa);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var tarefa = await _tarefaService.GetAll();
            if (tarefa == null)
                return NotFound();
            return Ok(tarefa);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] TarefaRequest request)
        {
            await _tarefaService.Insert(request);
            return CreatedAtAction(nameof(Get), new { id = request.IdTarefa }, request);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] TarefaRequest request)
        {
            var tarefa = await _tarefaService.GetById(request.IdTarefa);
                       

            if (tarefa == null || tarefa.IdTarefa == 0)
                return BadRequest("Tarefa não encontrada! Informe uma tarefa válida para ser alterada");

            await _tarefaService.Update(request);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var tarefa = await _tarefaService.GetById(id);
            if (tarefa == null || tarefa.IdTarefa == 0)
                return BadRequest("Tarefa não encontrada! Informe uma tarefa válida para ser excluída.");
            await _tarefaService.Delete(id);
            return NoContent();
        }
    }
}
