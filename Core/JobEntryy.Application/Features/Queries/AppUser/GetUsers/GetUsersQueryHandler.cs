using JobEntryy.Application.Abstracts.ServiceContracts;
using JobEntryy.Application.Constants;
using JobEntryy.Application.DTOs;
using JobEntryy.Application.Parametres.ResponseParametres;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace JobEntryy.Application.Features.Queries.AppUser.GetUsers
{
    public class GetUsersQueryHandler : IRequestHandler<GetUsersQueryRequest, GetUsersQueryResponse>
    {
        private readonly IUserService userService;
        public GetUsersQueryHandler(IUserService userService)
        {
            this.userService = userService;
        }



        public async Task<GetUsersQueryResponse> Handle(GetUsersQueryRequest request, CancellationToken cancellationToken)
        {
            List<UserDto> users = await userService.GetUsers();
            return new() { Users = users, Result = SuccessResult.Create(Messages.SuccessListed) };
        }
    }
}
