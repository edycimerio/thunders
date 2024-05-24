using Domain.Thunders.Request;
using FluentValidation;

namespace API.Thunders.Validacao
{

    public class TarefaValidator : AbstractValidator<TarefaRequest>
    {
        public TarefaValidator()
        {
            RuleFor(tarefa => tarefa.NomeTarefa).NotEmpty().WithMessage("Tarefa é obrigatória.");
            RuleFor(tarefa => tarefa.NomeTarefa).Length(5,20).WithMessage("O nome da tarefa não pode passar de 20 caracteres.");
            RuleFor(tarefa => tarefa.DescricaoTarefa).NotEmpty().WithMessage("Descrição da tarefa é obrigatória.");
            RuleFor(tarefa => tarefa.DescricaoTarefa).Length(10,30).WithMessage("A descrição da tarefa não pode passar de 30 caracteres.");
            RuleFor(tarefa => tarefa.AtivoTarefa).Must(x => x == false || x == true).WithMessage("Situação ativa da tarefa é obrigatótia.");
            

        }
    }
}
