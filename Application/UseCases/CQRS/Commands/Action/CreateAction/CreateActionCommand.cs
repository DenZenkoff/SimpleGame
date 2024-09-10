using Application.Enums;
using MediatR;

namespace Application.UseCases.CQRS.Commands.Action.CreateAction;

public class CreateActionCommand : IRequest<bool>
{
    public string Name { get; set; }
    public string Description { get; set; }
    public ActionType Type { get; set; }
    
    public int MinExp { get; set; }
    public int MaxExp { get; set; }
    public ushort MinEnergyCost { get; set; } 
    public ushort MaxEnergyCost { get; set; }
    public ushort MinDamage { get; set; }
    public ushort MaxDamage { get; set; }
}