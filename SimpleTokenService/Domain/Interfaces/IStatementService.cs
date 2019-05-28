﻿using SimpleTokenService.Data.Entities;
using System.Threading.Tasks;

namespace SimpleTokenService.Domain
{
    public interface IStatementService
    {
        Task Add(string email, Statement statement);
    }
}