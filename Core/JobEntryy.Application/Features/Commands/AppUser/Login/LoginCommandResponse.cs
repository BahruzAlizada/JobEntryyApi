﻿using JobEntryy.Application.DTOs;
using JobEntryy.Application.Parametres.ResponseParametres;

namespace JobEntryy.Application.Features.Commands.AppUser.Login
{
    public class LoginCommandResponse
    {
        public Result Result { get; set; }
        public TokenDto Token { get; set; }
    }
}