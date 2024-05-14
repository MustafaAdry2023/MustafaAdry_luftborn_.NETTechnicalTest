using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Abstractions
{
    public interface ICurrentUserService
    {
        Guid Id { get; }
        string Email { get; }
        string Name { get; }
    }
}
