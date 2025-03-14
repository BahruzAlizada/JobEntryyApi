using MediatR;

namespace JobEntryy.Application.Features.Commands.Category.UpdateCategory
{
    public class UpdateCategoryCommandRequest : IRequest<UpdateCategoryCommandResponse>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}