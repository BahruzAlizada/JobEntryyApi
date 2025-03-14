using MediatR;

namespace JobEntryy.Application.Features.Commands.Category.CreateCategory
{
    public class CreateCategoryCommandRequest : IRequest<CreateCategoryCommandResponse>
    {
        public string Name { get; set; }
    }
}