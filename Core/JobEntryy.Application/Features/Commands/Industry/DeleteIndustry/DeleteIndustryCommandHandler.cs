using JobEntryy.Application.Abstracts.Services.EntityFramework;
using JobEntryy.Application.Constants;
using JobEntryy.Application.Parametres.ResponseParametres;
using MediatR;

namespace JobEntryy.Application.Features.Commands.Industry.DeleteIndustry
{
    public class DeleteIndustryCommandHandler : IRequestHandler<DeleteIndustryCommandRequest, DeleteIndustryCommandResponse>
    {
        private readonly IIndustryWriteRepository industryWriteRepository;
        public DeleteIndustryCommandHandler(IIndustryWriteRepository industryWriteRepository)
        {
            this.industryWriteRepository = industryWriteRepository;
        }


        public async Task<DeleteIndustryCommandResponse> Handle(DeleteIndustryCommandRequest request, CancellationToken cancellationToken)
        {
            await industryWriteRepository.RemoveAsync(request.Id.ToString());
            return new() { Result = SuccessResult.Create(Messages.SuccessDeleted) };
        }
    }
}
