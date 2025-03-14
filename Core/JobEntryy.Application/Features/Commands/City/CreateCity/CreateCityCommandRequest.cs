using MediatR;

namespace JobEntryy.Application.Features.Commands.City.CreateCity
{
    public class CreateCityCommandRequest : IRequest<CreateCityCommandResponse>
    {
        public string Name { get; set; }
    }
}