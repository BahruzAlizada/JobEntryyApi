using JobEntryy.Application.Abstracts.Services.EntityFramework;
using JobEntryy.Application.Constants;
using JobEntryy.Application.Parametres.ResponseParametres;
using MediatR;

namespace JobEntryy.Application.Features.Commands.City.DeleteCity
{
    public class DeleteCityCommandHandler : IRequestHandler<DeleteCityCommandRequest, DeleteCityCommandResponse>
    {
        private readonly ICityWriteRepository cityWriteRepository;
        public DeleteCityCommandHandler(ICityWriteRepository cityWriteRepository)
        {
            this.cityWriteRepository = cityWriteRepository;
        }


        public async Task<DeleteCityCommandResponse> Handle(DeleteCityCommandRequest request, CancellationToken cancellationToken)
        {
            await cityWriteRepository.RemoveAsync(request.Id.ToString());
            return new() { Result = SuccessResult.Create(Messages.SuccessDeleted) };
        }
    }
}
