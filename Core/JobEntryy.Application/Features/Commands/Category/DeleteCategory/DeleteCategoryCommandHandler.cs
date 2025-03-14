using JobEntryy.Application.Abstracts.Services.EntityFramework;
using JobEntryy.Application.Constants;
using JobEntryy.Application.Parametres.ResponseParametres;
using MediatR;

namespace JobEntryy.Application.Features.Commands.Category.DeleteCategory
{
    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommandRequest, DeleteCategoryCommandResponse>
    {
        private readonly ICategoryWriteRepository categoryWriteRepository;
        public DeleteCategoryCommandHandler(ICategoryWriteRepository categoryWriteRepository)
        {
            this.categoryWriteRepository = categoryWriteRepository;
        }


        public async Task<DeleteCategoryCommandResponse> Handle(DeleteCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            await categoryWriteRepository.RemoveAsync(request.Id.ToString());
            return new() { Result = SuccessResult.Create(Messages.SuccessDeleted) };
        }
    }
}
