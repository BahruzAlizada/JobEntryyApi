using JobEntryy.Application.Abstracts.ServiceContracts;
using JobEntryy.Application.Constants;
using JobEntryy.Application.DTOs;
using JobEntryy.Application.Parametres.ResponseParametres;
using MediatR;

namespace JobEntryy.Application.Features.Queries.AppUser.GetUser
{
    public class GetUserQueryHandler : IRequestHandler<GetUserQueryRequest, GetUserQueryResponse>
    {
        private readonly IUserService userService;
        public GetUserQueryHandler(IUserService userService)
        {
            this.userService = userService;
        }


        public async Task<GetUserQueryResponse> Handle(GetUserQueryRequest request, CancellationToken cancellationToken)
        {
            UserDto user = await userService.GetUser(request.Id);
            return new() { User = user, Result = SuccessResult.Create(Messages.SuccessGetFiltered) };
        }
    }
}
