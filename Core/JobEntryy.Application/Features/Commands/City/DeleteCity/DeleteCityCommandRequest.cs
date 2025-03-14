using MediatR;

namespace JobEntryy.Application.Features.Commands.City.DeleteCity
{
    public class DeleteCityCommandRequest : IRequest<DeleteCityCommandResponse>
    {
        public Guid Id { get; set; }    
    }
}