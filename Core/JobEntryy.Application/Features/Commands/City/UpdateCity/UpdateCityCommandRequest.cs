using MediatR;

namespace JobEntryy.Application.Features.Commands.City.UpdateCity
{
    public class UpdateCityCommandRequest : IRequest<UpdateCityCommandResponse>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}