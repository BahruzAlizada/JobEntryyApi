﻿using MediatR;

namespace JobEntryy.Application.Features.Commands.AppRole.UpdateRole
{
    public class UpdateRoleCommandRequest : IRequest<UpdateRoleCommandResponse>
    {
        public Guid Id { get; set; }
        public string Name { get;set; }
    }
}